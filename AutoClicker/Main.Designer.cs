namespace AutoClicker
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.biLeftMouse = new AutoClicker.ButtonInputs("Left mouse button", Win32Api.WmLbuttonDown, Win32Api.WmLbuttonDown + 1);
            this.biRightMouse = new AutoClicker.ButtonInputs("Right mouse button", Win32Api.WmRbuttonDown, Win32Api.WmRbuttonDown + 1);
            this.btn_start = new System.Windows.Forms.Button();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.btn_stop = new System.Windows.Forms.Button();
            this.lblStarted = new System.Windows.Forms.Label();
            this.lblGameWindow = new System.Windows.Forms.Label();
            this.cmbProcess = new System.Windows.Forms.ComboBox();
            this.hotkey_button = new System.Windows.Forms.Button();
            this.hotkey_label = new System.Windows.Forms.Label();
            this.refresh_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // biLeftMouse
            // 
            this.biLeftMouse.Location = new System.Drawing.Point(12, 18);
            this.biLeftMouse.Name = "biLeftMouse";
            this.biLeftMouse.Size = new System.Drawing.Size(240, 130);
            this.biLeftMouse.TabIndex = 4;
            // 
            // biRightMouse
            // 
            this.biRightMouse.Location = new System.Drawing.Point(258, 18);
            this.biRightMouse.Name = "biRightMouse";
            this.biRightMouse.Size = new System.Drawing.Size(240, 130);
            this.biRightMouse.TabIndex = 5;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(270, 230);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(88, 51);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "START!";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.Btn_action_Click);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStartTime.Location = new System.Drawing.Point(234, 292);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(34, 17);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "time";
            this.lblStartTime.Visible = false;
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(166, 230);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(88, 51);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "STOP!";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.Btn_stop_Click);
            // 
            // lblStarted
            // 
            this.lblStarted.AutoSize = true;
            this.lblStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStarted.Location = new System.Drawing.Point(163, 292);
            this.lblStarted.Name = "lblStarted";
            this.lblStarted.Size = new System.Drawing.Size(74, 17);
            this.lblStarted.TabIndex = 6;
            this.lblStarted.Text = "Started at:";
            this.lblStarted.Visible = false;
            // 
            // lblGameWindow
            // 
            this.lblGameWindow.AutoSize = true;
            this.lblGameWindow.Location = new System.Drawing.Point(60, 145);
            this.lblGameWindow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGameWindow.Name = "lblGameWindow";
            this.lblGameWindow.Size = new System.Drawing.Size(80, 13);
            this.lblGameWindow.TabIndex = 8;
            this.lblGameWindow.Text = "Game Window:";
            // 
            // cmbProcess
            // 
            this.cmbProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProcess.FormattingEnabled = true;
            this.cmbProcess.Location = new System.Drawing.Point(142, 143);
            this.cmbProcess.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProcess.MaxDropDownItems = 50;
            this.cmbProcess.Name = "cmbProcess";
            this.cmbProcess.Size = new System.Drawing.Size(321, 21);
            this.cmbProcess.TabIndex = 7;
            // 
            // hotkey_button
            // 
            this.hotkey_button.Location = new System.Drawing.Point(270, 181);
            this.hotkey_button.Name = "hotkey_button";
            this.hotkey_button.Size = new System.Drawing.Size(88, 43);
            this.hotkey_button.TabIndex = 9;
            this.hotkey_button.Text = "F6";
            this.hotkey_button.UseVisualStyleBackColor = true;
            this.hotkey_button.Click += new System.EventHandler(this.hotkey_button_Click);
            this.hotkey_button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_keyDown);
            // 
            // hotkey_label
            // 
            this.hotkey_label.AutoSize = true;
            this.hotkey_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.hotkey_label.Location = new System.Drawing.Point(169, 190);
            this.hotkey_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hotkey_label.Name = "hotkey_label";
            this.hotkey_label.Size = new System.Drawing.Size(85, 25);
            this.hotkey_label.TabIndex = 10;
            this.hotkey_label.Text = "Hotkey:";
            // 
            // refresh_button
            // 
            this.refresh_button.Location = new System.Drawing.Point(468, 141);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(29, 23);
            this.refresh_button.TabIndex = 11;
            this.refresh_button.Text = "⟳";
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 320);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.hotkey_label);
            this.Controls.Add(this.hotkey_button);
            this.Controls.Add(this.lblGameWindow);
            this.Controls.Add(this.cmbProcess);
            this.Controls.Add(this.lblStarted);
            this.Controls.Add(this.biRightMouse);
            this.Controls.Add(this.biLeftMouse);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.btn_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Auto-Clicker";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Button btn_stop;
        private ButtonInputs biLeftMouse;
        private ButtonInputs biRightMouse;
        private System.Windows.Forms.Label lblStarted;
        private System.Windows.Forms.Label lblGameWindow;
        private System.Windows.Forms.ComboBox cmbProcess;
        private System.Windows.Forms.Button hotkey_button;
        private System.Windows.Forms.Label hotkey_label;
        private System.Windows.Forms.Button refresh_button;
    }
}

