using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class Main : Form
    {
        private readonly Dictionary<Process, List<Clicker>> instanceClickers = new Dictionary<Process, List<Clicker>>();
        private static readonly List<string> WindowTitles = new List<string>
        {
            "Minecraft",
            "RLCraft",
            "Client"
        };
        private Keys _key = Keys.F6;
        private bool _waitingForKey = false;
        KeyboardHook hook = new KeyboardHook();
        private bool _isRunning = false;

        public Main()
        {
            InitializeComponent();
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            var processes = Process.GetProcesses().Where(b => b.ProcessName.StartsWith("java") && b.MainWindowTitle != "").OrderBy(b => b.MainWindowTitle).Select(b => b.MainWindowTitle).ToArray();
            cmbProcess.Items.Clear();
            cmbProcess.Items.AddRange(processes);

            // if there is only 1 item, may as well select it for the, as it is probably the window they want
            if (cmbProcess.Items.Count == 1)
                cmbProcess.SelectedItem = cmbProcess.Items[0];
            
        }

        private async void Btn_action_Click(object sender, EventArgs e)
        {
            try
            {
                EnableElements(false);
                var mainHandle = Handle;
                var mcProcesses = GetMcProcesses();

                if (!mcProcesses.Any())
                {
                    // if we first don't find any windows matching an expected name, give the user the ability to override
                    string title = cmbProcess.SelectedItem.ToString();

                    if (!string.IsNullOrEmpty(title))
                        mcProcesses = Process.GetProcesses().Where(b => b.MainWindowTitle == title).ToList();
                }

                if (!mcProcesses.Any())
                {
                    MessageBox.Show(@"Unable to find Minecraft process!", @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EnableElements(true);
                    return;
                }

                if (mcProcesses.Count > 1)
                {
                    using (var instancesForm = new MultipleInstances(mcProcesses))
                    {
                        if (instancesForm.ShowDialog() != DialogResult.OK)
                        {
                            EnableElements(true);
                            return;
                        }   

                        mcProcesses = instancesForm.SelectedInstances.Select(Process.GetProcessById).ToList();
                    }
                }

                lblStartTime.Text = DateTime.Now.ToString("MMMM dd HH:mm tt");
                lblStarted.Visible = true;
                lblStartTime.Visible = true;
                btn_stop.Enabled = false;
                
                foreach (var mcProcess in mcProcesses)
                {
                    var minecraftHandle = mcProcess.MainWindowHandle;
                    FocusToggle(minecraftHandle);

                    await Task.Run(() => CountDown(mainHandle));

                    // Right click needs to be ahead of left click for concrete mining
                    if (biRightMouse.Needed)
                    {
                        var clicker = biRightMouse.StartClicking(minecraftHandle);
                        AddToInstanceClickers(mcProcess, clicker);
                    }

                    /*
                     * This sleep is needed, because if you want to mine concrete, then Minecraft starts to hold left click first
                     * and it won't place the block in your second hand for some reason...
                     */
                    Thread.Sleep(100);

                    if (biLeftMouse.Needed)
                    {
                        var clicker = biLeftMouse.StartClicking(minecraftHandle);
                        AddToInstanceClickers(mcProcess, clicker);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Stop();
            }
        }

        private static List<Process> GetMcProcesses()
        {
            return Process.GetProcesses().Where(b => b.ProcessName.StartsWith("java") && WindowTitles.Any(title => b.MainWindowTitle.Contains(title))).ToList();
        }

        private void CountDown(IntPtr mainHandle)
        {
            SetControlPropertyThreadSafe(btn_start, "Text", @"Starting in: ");
            Thread.Sleep(750);

            for (var i = 3; i > 0; i--)
            {
                SetControlPropertyThreadSafe(btn_start, "Text", i.ToString());
                Thread.Sleep(750);
            }

            FocusToggle(mainHandle);
            SetControlPropertyThreadSafe(btn_start, "Text", @"Running...");
            Thread.Sleep(750);
            SetControlPropertyThreadSafe(btn_stop, "Enabled", true);
            _isRunning = true;
        }

        private void AddToInstanceClickers(Process mcProcess, Clicker clicker)
        {
            if (instanceClickers.ContainsKey(mcProcess))
                instanceClickers[mcProcess].Add(clicker);
            else
                instanceClickers.Add(mcProcess, new List<Clicker> { clicker });
        }

        private void Btn_stop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            btn_stop.Enabled = false;
            _isRunning = false;

            foreach (var clickers in instanceClickers.Values)
            {
                foreach (var clicker in clickers)
                {
                    clicker?.Dispose();
                }
            }

            instanceClickers.Clear();

            lblStarted.Visible = false;
            lblStartTime.Visible = false;

            btn_start.Text = "START";
            EnableElements(true);
        }

        private void EnableElements(bool enable)
        {
            btn_start.Enabled = enable;
            biLeftMouse.Enabled = enable;
            biRightMouse.Enabled = enable;
            btn_stop.Enabled = !enable;
        }

        private static void FocusToggle(IntPtr hwnd)
        {
            Thread.Sleep(200);
            Win32Api.SetForegroundWindow(hwnd);
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), control, propertyName, propertyValue);
            else
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new[] { propertyValue });
        }//end SetControlPropertyThreadSafe

        private void refresh_button_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void hotkey_button_Click(object sender, EventArgs e)
        {
            _waitingForKey = true;
            hotkey_button.Text = @"Press a key";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Loaded!");
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(ModifierKeysHook.None,
                _key);
        }

        private void Main_keyDown(object sender, KeyEventArgs e)
        {
            if (_waitingForKey)
            {
                hook.Dispose();
                _key = e.KeyCode;
                hotkey_button.Text = _key.ToString();
                _waitingForKey = false;
                hook = new KeyboardHook();
                hook.KeyPressed +=
                    new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
                hook.RegisterHotKey(ModifierKeysHook.None,
                    _key);
            }
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (_waitingForKey)
            {
                return;
            }

            if (_isRunning && btn_stop.Enabled)
            {
                Stop();
            }
            else if (btn_start.Enabled)
            {
                Btn_action_Click(sender, e);
            }
        }
    }
}
