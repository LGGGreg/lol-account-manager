namespace LoLAccountManagerLGG
{
    partial class DebugDisplay
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2debug = new System.Windows.Forms.TextBox();
            this.button1clearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(111, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "LoL Account Manager";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(71, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "By LGG";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(151, 31);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "lordgreggreg@gmail.com";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2debug
            // 
            this.textBox2debug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.textBox2debug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2debug.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2debug.ForeColor = System.Drawing.Color.White;
            this.textBox2debug.Location = new System.Drawing.Point(9, 60);
            this.textBox2debug.Multiline = true;
            this.textBox2debug.Name = "textBox2debug";
            this.textBox2debug.ReadOnly = true;
            this.textBox2debug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2debug.Size = new System.Drawing.Size(359, 360);
            this.textBox2debug.TabIndex = 3;
            this.textBox2debug.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1clearLog
            // 
            this.button1clearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1clearLog.Location = new System.Drawing.Point(12, 426);
            this.button1clearLog.Name = "button1clearLog";
            this.button1clearLog.Size = new System.Drawing.Size(352, 24);
            this.button1clearLog.TabIndex = 4;
            this.button1clearLog.Text = "Clear";
            this.button1clearLog.UseVisualStyleBackColor = true;
            this.button1clearLog.Click += new System.EventHandler(this.button1clearLog_Click);
            // 
            // DebugDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.BackgroundImage = global::LoLAccountManagerLGG.Properties.Resources.iconIMG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(376, 455);
            this.Controls.Add(this.button1clearLog);
            this.Controls.Add(this.textBox2debug);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DebugDisplay";
            this.Text = "LoL Account Manager LGG Debug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2debug;
        private System.Windows.Forms.Button button1clearLog;
    }
}