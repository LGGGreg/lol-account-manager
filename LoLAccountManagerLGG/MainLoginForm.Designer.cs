namespace LoLAccountManagerLGG
{
    partial class MainLoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainLoginForm));
            this.backgroundWorkerWatchLoL = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loLAccountManagerLGGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snapTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1UserName = new System.Windows.Forms.Label();
            this.label1Password = new System.Windows.Forms.Label();
            this.textBox1Password = new System.Windows.Forms.TextBox();
            this.checkBox1RemeberUsername = new System.Windows.Forms.CheckBox();
            this.checkBox1RemeberPass = new System.Windows.Forms.CheckBox();
            this.button1LogIn = new System.Windows.Forms.Button();
            this.button1deleteentry = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1LogDisplay = new System.Windows.Forms.Button();
            this.button1getBig = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerWatchLoL
            // 
            this.backgroundWorkerWatchLoL.WorkerReportsProgress = true;
            this.backgroundWorkerWatchLoL.WorkerSupportsCancellation = true;
            this.backgroundWorkerWatchLoL.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerWatchLoL_DoWork);
            this.backgroundWorkerWatchLoL.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerWatchLoL_ProgressChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "LoL Account Manager - LGG";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ForeColor = System.Drawing.Color.White;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loLAccountManagerLGGToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.snapTestToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(380, 156);
            this.contextMenuStrip1.Text = "LoL Account Manager LGG";
            // 
            // loLAccountManagerLGGToolStripMenuItem
            // 
            this.loLAccountManagerLGGToolStripMenuItem.Enabled = false;
            this.loLAccountManagerLGGToolStripMenuItem.Name = "loLAccountManagerLGGToolStripMenuItem";
            this.loLAccountManagerLGGToolStripMenuItem.Size = new System.Drawing.Size(379, 26);
            this.loLAccountManagerLGGToolStripMenuItem.Text = "LoL Account Manager LGG";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(379, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(379, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // snapTestToolStripMenuItem
            // 
            this.snapTestToolStripMenuItem.Name = "snapTestToolStripMenuItem";
            this.snapTestToolStripMenuItem.Size = new System.Drawing.Size(379, 26);
            this.snapTestToolStripMenuItem.Text = "Snap Test";
            this.snapTestToolStripMenuItem.Visible = false;
            this.snapTestToolStripMenuItem.Click += new System.EventHandler(this.snapTestToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(27, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(303, 30);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.TextChanged += new System.EventHandler(this.textBox1Password_TextChanged);
            // 
            // label1UserName
            // 
            this.label1UserName.AutoSize = true;
            this.label1UserName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1UserName.ForeColor = System.Drawing.Color.White;
            this.label1UserName.Location = new System.Drawing.Point(27, 12);
            this.label1UserName.Name = "label1UserName";
            this.label1UserName.Size = new System.Drawing.Size(80, 22);
            this.label1UserName.TabIndex = 2;
            this.label1UserName.Text = "Username";
            // 
            // label1Password
            // 
            this.label1Password.AutoSize = true;
            this.label1Password.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1Password.ForeColor = System.Drawing.Color.White;
            this.label1Password.Location = new System.Drawing.Point(27, 69);
            this.label1Password.Name = "label1Password";
            this.label1Password.Size = new System.Drawing.Size(74, 22);
            this.label1Password.TabIndex = 3;
            this.label1Password.Text = "Password";
            // 
            // textBox1Password
            // 
            this.textBox1Password.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1Password.Location = new System.Drawing.Point(27, 94);
            this.textBox1Password.Name = "textBox1Password";
            this.textBox1Password.Size = new System.Drawing.Size(303, 29);
            this.textBox1Password.TabIndex = 4;
            this.textBox1Password.UseSystemPasswordChar = true;
            this.textBox1Password.TextChanged += new System.EventHandler(this.textBox1Password_TextChanged);
            // 
            // checkBox1RemeberUsername
            // 
            this.checkBox1RemeberUsername.AutoSize = true;
            this.checkBox1RemeberUsername.Checked = true;
            this.checkBox1RemeberUsername.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1RemeberUsername.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1RemeberUsername.ForeColor = System.Drawing.Color.White;
            this.checkBox1RemeberUsername.Location = new System.Drawing.Point(27, 129);
            this.checkBox1RemeberUsername.Name = "checkBox1RemeberUsername";
            this.checkBox1RemeberUsername.Size = new System.Drawing.Size(176, 26);
            this.checkBox1RemeberUsername.TabIndex = 5;
            this.checkBox1RemeberUsername.Text = "Remember Username";
            this.checkBox1RemeberUsername.UseVisualStyleBackColor = true;
            // 
            // checkBox1RemeberPass
            // 
            this.checkBox1RemeberPass.AutoSize = true;
            this.checkBox1RemeberPass.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1RemeberPass.ForeColor = System.Drawing.Color.White;
            this.checkBox1RemeberPass.Location = new System.Drawing.Point(27, 155);
            this.checkBox1RemeberPass.Name = "checkBox1RemeberPass";
            this.checkBox1RemeberPass.Size = new System.Drawing.Size(170, 26);
            this.checkBox1RemeberPass.TabIndex = 6;
            this.checkBox1RemeberPass.Text = "Remember Password";
            this.checkBox1RemeberPass.UseVisualStyleBackColor = true;
            // 
            // button1LogIn
            // 
            this.button1LogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(118)))), ((int)(((byte)(0)))));
            this.button1LogIn.Enabled = false;
            this.button1LogIn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1LogIn.ForeColor = System.Drawing.Color.White;
            this.button1LogIn.Location = new System.Drawing.Point(231, 131);
            this.button1LogIn.Name = "button1LogIn";
            this.button1LogIn.Size = new System.Drawing.Size(99, 35);
            this.button1LogIn.TabIndex = 7;
            this.button1LogIn.Text = "Log In";
            this.button1LogIn.UseVisualStyleBackColor = false;
            this.button1LogIn.Click += new System.EventHandler(this.button1LogIn_Click);
            // 
            // button1deleteentry
            // 
            this.button1deleteentry.BackColor = System.Drawing.Color.Transparent;
            this.button1deleteentry.BackgroundImage = global::LoLAccountManagerLGG.Properties.Resources.remove;
            this.button1deleteentry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1deleteentry.FlatAppearance.BorderSize = 0;
            this.button1deleteentry.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.button1deleteentry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1deleteentry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1deleteentry.Location = new System.Drawing.Point(334, 38);
            this.button1deleteentry.Name = "button1deleteentry";
            this.button1deleteentry.Size = new System.Drawing.Size(26, 25);
            this.button1deleteentry.TabIndex = 8;
            this.toolTip1.SetToolTip(this.button1deleteentry, "Remove Saved Entry");
            this.button1deleteentry.UseVisualStyleBackColor = false;
            this.button1deleteentry.Click += new System.EventHandler(this.button1deleteentry_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 100;
            // 
            // button1LogDisplay
            // 
            this.button1LogDisplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1LogDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1LogDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.button1LogDisplay.Location = new System.Drawing.Point(0, 0);
            this.button1LogDisplay.Name = "button1LogDisplay";
            this.button1LogDisplay.Size = new System.Drawing.Size(12, 10);
            this.button1LogDisplay.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button1LogDisplay, "Show Log");
            this.button1LogDisplay.UseVisualStyleBackColor = true;
            this.button1LogDisplay.Click += new System.EventHandler(this.button1LogDisplay_Click);
            // 
            // button1getBig
            // 
            this.button1getBig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1getBig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1getBig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.button1getBig.Location = new System.Drawing.Point(11, 0);
            this.button1getBig.Name = "button1getBig";
            this.button1getBig.Size = new System.Drawing.Size(12, 10);
            this.button1getBig.TabIndex = 10;
            this.toolTip1.SetToolTip(this.button1getBig, "Get Big");
            this.button1getBig.UseVisualStyleBackColor = true;
            this.button1getBig.Click += new System.EventHandler(this.button1getBig_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.button1.Location = new System.Drawing.Point(22, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(12, 10);
            this.button1.TabIndex = 11;
            this.toolTip1.SetToolTip(this.button1, "Get Small");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(379, 26);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Visible = false;
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // MainLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(365, 192);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button1getBig);
            this.Controls.Add(this.button1LogDisplay);
            this.Controls.Add(this.button1LogIn);
            this.Controls.Add(this.checkBox1RemeberPass);
            this.Controls.Add(this.checkBox1RemeberUsername);
            this.Controls.Add(this.textBox1Password);
            this.Controls.Add(this.button1deleteentry);
            this.Controls.Add(this.label1Password);
            this.Controls.Add(this.label1UserName);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainLoginForm";
            this.ShowInTaskbar = false;
            this.Text = "LoL Account Manager";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerWatchLoL;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1UserName;
        private System.Windows.Forms.Label label1Password;
        private System.Windows.Forms.TextBox textBox1Password;
        private System.Windows.Forms.CheckBox checkBox1RemeberUsername;
        private System.Windows.Forms.CheckBox checkBox1RemeberPass;
        private System.Windows.Forms.Button button1LogIn;
        private System.Windows.Forms.Button button1deleteentry;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem loLAccountManagerLGGToolStripMenuItem;
        private System.Windows.Forms.Button button1LogDisplay;
        private System.Windows.Forms.Button button1getBig;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem snapTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
    }
}

