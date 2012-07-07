using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace LoLAccountManagerLGG
{
    public partial class MainLoginForm : Form
    {
        #region vars
        private Rectangle loginWindowRect = new Rectangle(1,1,1,1);
        private IntPtr loginWindowHandle = IntPtr.Zero;
        private IntPtr myHandle = IntPtr.Zero;
        private bool bigSize = true;
        private bool loggingIn=false;
        private bool getOutOfMyWay = false;
        private bool sizePending = false;
        private DebugDisplay debugDisp;
        private Dictionary<String, String> userPass = new Dictionary<String, String>();
        private StringBuilder logBuilder;
        const string saveFileName = "LoLLogins.txt";
        private searchableImage bigSearchImage;
        private searchableImage smallSearchImage;
        #endregion
        public MainLoginForm()
        {
            bigSearchImage = new searchableImage(
                   new List<pointAndColorPair>(new pointAndColorPair[] {
                    new pointAndColorPair(1011, 90, 1192999),
                    new pointAndColorPair(953, 195, 3167817),
                    new pointAndColorPair(1099, 194, 2511169),
                }),new Point(-182,186));
            smallSearchImage = new searchableImage(
                new List<pointAndColorPair>(new pointAndColorPair[] {
                    new pointAndColorPair(808, 72, 2375220),
                    new pointAndColorPair(749, 155, 3959907),
                    new pointAndColorPair(910, 100, 3094067),
                }),new Point(-182-165,186-55));
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //background worker watches for the login screen to overlay
            backgroundWorkerWatchLoL.RunWorkerAsync();
            
            updateSize();
            updateVisibility();
            load();
        }
        #region lolWatching
        private void trackLoginWindow()
        {
            //update vars for size and position.
            //if something changes, trigger event
            WindowExternalHelpers.BasicRect _basicRect;
            if (WindowExternalHelpers.GetWindowRect(new HandleRef(this, loginWindowHandle), out _basicRect))
            {
                Rectangle newloginWindowRect = new Rectangle();
                newloginWindowRect.X = _basicRect.Left;
                newloginWindowRect.Y = _basicRect.Top;
                newloginWindowRect.Width = _basicRect.Right - _basicRect.Left;
                newloginWindowRect.Height = _basicRect.Bottom - _basicRect.Top;
                if (newloginWindowRect.Width <= 160 || newloginWindowRect.Width > 10000) return;

                bool newBigSize = newloginWindowRect.Width >= 1280;
                if (newBigSize != bigSize) 
                {
                    bigSize = newBigSize;
                    addLog("Size changed because windows was detected at size " + newloginWindowRect.Width.ToString());
                    backgroundWorkerWatchLoL.ReportProgress(0, "Update Size");

                }

                if (!loginWindowRect.Equals(newloginWindowRect))
                { loginWindowRect = newloginWindowRect; backgroundWorkerWatchLoL.ReportProgress(0, "Update Pos"); }
                
            }
        }

        private int getColor(int x, int y)
        {
            int toReturn =-1;
            IntPtr dc = WindowExternalHelpers.GetDC(loginWindowHandle);
            toReturn=WindowExternalHelpers.GetPixel(dc, x, y);
            WindowExternalHelpers.ReleaseDC(loginWindowHandle, dc);
            return toReturn;
        }
        private Bitmap getScreenArea()
        {
            IntPtr hBmp;
            IntPtr dc = WindowExternalHelpers.GetDC(loginWindowHandle);
            IntPtr hdcCompatible = WindowExternalHelpers.CreateCompatibleDC(dc);
            hBmp = WindowExternalHelpers.CreateCompatibleBitmap(dc, loginWindowRect.Width, loginWindowRect.Height);

            if (hBmp != IntPtr.Zero)
            {
                IntPtr hOldBmp = (IntPtr)WindowExternalHelpers.SelectObject(hdcCompatible, hBmp);
                WindowExternalHelpers.BitBlt(hdcCompatible, 0, 0, loginWindowRect.Width, loginWindowRect.Height, dc, 0, 0, 13369376);

                WindowExternalHelpers.SelectObject(hdcCompatible, hOldBmp);
                WindowExternalHelpers.DeleteDC(hdcCompatible);
                WindowExternalHelpers.ReleaseDC(loginWindowHandle, dc);

                Bitmap bmp = System.Drawing.Image.FromHbitmap(hBmp);

                WindowExternalHelpers.DeleteObject(hBmp);
                GC.Collect();

                return bmp;
            }
            return null;
        }
        private void saveScreenArea(String fileName = "")
        {
            Bitmap bitmap = getScreenArea();
            if (fileName == "") fileName = "SnapText" + System.Environment.TickCount + ".jpeg";
            String FilePath = fileName;

            bitmap.Save(FilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
           
        private bool isLoggingInNow()
        {
            // check if the user can actually see the window >.>
            
            if (!(WindowExternalHelpers.isTopWindow(loginWindowHandle) ||
                WindowExternalHelpers.isTopWindow(myHandle))) return false;

                                
            // check colors of lol window to determine if the login screen is visible
            if (bigSize)
            {
                return bigSearchImage.foundInScreen(loginWindowHandle, loginWindowRect);
            }
            else
            {
                return smallSearchImage.foundInScreen(loginWindowHandle, loginWindowRect);
            }
        }

        private void backgroundWorkerWatchLoL_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorkerWatchLoL.CancellationPending)
            {
                if (!WindowExternalHelpers.IsWindow(myHandle))
                    myHandle = WindowExternalHelpers.FindWindowByCaption(IntPtr.Zero, "LoL Account Manager");

                //constantly check if lol login screen exists and its size/pos
                bool loggingInNow = false;
                if (WindowExternalHelpers.IsWindow(loginWindowHandle))
                {
                    trackLoginWindow();
                    if (WindowExternalHelpers.IsWindowVisible(loginWindowHandle))
                    {
                        loggingInNow = isLoggingInNow();
                    }
                }
                else
                {
                    loginWindowHandle = WindowExternalHelpers.FindWindowByCaption(IntPtr.Zero, "PVP.net Client");
                }
                
                if (loggingInNow != loggingIn) 
                { loggingIn = loggingInNow; backgroundWorkerWatchLoL.ReportProgress(0, "Update Visible"); }

                Thread.Sleep(200);
            }
        }        
        private void backgroundWorkerWatchLoL_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //handle events asked for by the lol window tracking
            string command = (string)e.UserState;
            switch (command)
            {
                case "Update Visible":
                    updateVisibility();
                    updatePos();
                    return;

                case "Update Size":
                    updateSize();
                    updatePos();
                    return;
                case "Update Pos":
                    updatePos();
                    return;
            }
        }
        private void updatePos()
        {
            if (bigSize)
                Location = //new Point(loginWindowRect.X + 827, loginWindowRect.Y + 274);
                    new Point(loginWindowRect.X+bigSearchImage.getLastFoundPosition().X,
                        loginWindowRect.Y+bigSearchImage.getLastFoundPosition().Y);
            else
                Location = new Point(loginWindowRect.X + 662, loginWindowRect.Y + 219);

            addLog("Finished Updating Location to " + Location.X.ToString()+","+Location.Y.ToString());
        }
        private void updateSize(bool force=false,bool forceTo=false)
        {
            bool sizeToSet = bigSize;
            if (force)
            {
                sizeToSet = forceTo;
            }
            if (!Visible) sizePending = true;
            else if (sizePending)
            {
                sizePending = false;
            }

            //move form fields to match login screen.
            if (sizeToSet)
            {
                Size = new Size(365, 192);
                this.label1UserName.Location=new Point(27, 12);
                this.label1UserName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label1UserName.Size = new System.Drawing.Size(80, 22);
                this.comboBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.comboBox1.Location = new System.Drawing.Point(27, 36);
                this.comboBox1.Size = new System.Drawing.Size(303, 30);
                this.label1Password.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label1Password.Location = new System.Drawing.Point(27, 69);
                this.label1Password.Size = new System.Drawing.Size(74, 22);
                this.textBox1Password.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.textBox1Password.Location = new System.Drawing.Point(27, 94);
                this.textBox1Password.Size = new System.Drawing.Size(303, 29);
                this.checkBox1RemeberUsername.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.checkBox1RemeberUsername.Location = new System.Drawing.Point(27, 129);
                this.checkBox1RemeberUsername.Size = new System.Drawing.Size(176, 26);
                this.checkBox1RemeberPass.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.checkBox1RemeberPass.Location = new System.Drawing.Point(27, 155);
                this.checkBox1RemeberPass.Size = new System.Drawing.Size(170, 26);
                this.button1LogIn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button1LogIn.Location = new System.Drawing.Point(231, 131);
                this.button1LogIn.Size = new System.Drawing.Size(99, 35);
                this.button1deleteentry.Location = new System.Drawing.Point(334, 38);
                this.button1deleteentry.Size = new System.Drawing.Size(26, 25);               
                
            }
            else
            {
                Size= new Size(291,153);
                this.label1UserName.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label1UserName.Location = new System.Drawing.Point(21, 10);
                this.label1UserName.Size = new System.Drawing.Size(57, 16);            
                this.comboBox1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.comboBox1.Location = new System.Drawing.Point(21, 28);
                this.comboBox1.Size = new System.Drawing.Size(240, 24);
                this.label1Password.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label1Password.Location = new System.Drawing.Point(21, 57);
                this.label1Password.Size = new System.Drawing.Size(56, 16);
                this.textBox1Password.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.textBox1Password.Location = new System.Drawing.Point(21, 76);
                this.textBox1Password.Size = new System.Drawing.Size(240, 22);
                this.checkBox1RemeberUsername.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.checkBox1RemeberUsername.Location = new System.Drawing.Point(21, 104);
                this.checkBox1RemeberUsername.Size = new System.Drawing.Size(131, 20);
                this.checkBox1RemeberPass.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.checkBox1RemeberPass.Location = new System.Drawing.Point(21, 130);
                this.checkBox1RemeberPass.Size = new System.Drawing.Size(130, 20);
                this.button1LogIn.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button1LogIn.Location = new System.Drawing.Point(181, 105);
                this.button1LogIn.Size = new System.Drawing.Size(80, 28);
                this.button1deleteentry.Location = new System.Drawing.Point(181+80+4, 28);
                this.button1deleteentry.Size = new System.Drawing.Size(20, 20);               
            }

            addLog("Finished Updating Size to " + (sizeToSet ? "Big" : "Small"));
            Hide();
            this.Refresh();
            this.Invalidate(true);
            Application.DoEvents();
            updateVisibility();
        }
        private void updateVisibility()
        {
            if (loggingIn && !getOutOfMyWay)
            {
                Show();
                Visible = true;
                if (sizePending) updateSize();
                WindowState = FormWindowState.Normal;
            }
            else
            {
                Hide();
                Visible = false;
                WindowState = FormWindowState.Minimized;
            }
            addLog("Finished Updating visibility to " + (Visible ? "True" : "false"));
            Application.DoEvents();
        }
        #endregion
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1Password_TextChanged(object sender, EventArgs e)
        {
            //change the login button's enabled if we can log in
            if ((textBox1Password.Text.Length > 0 && comboBox1.Text.Length > 0) && !button1LogIn.Enabled)
            {
                this.button1LogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(118)))), ((int)(((byte)(0)))));
                button1LogIn.Enabled = true;
            }
            if ((textBox1Password.Text.Length <= 0 || comboBox1.Text.Length <= 0) && button1LogIn.Enabled)
            {
                this.button1LogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
                button1LogIn.Enabled = false;
            }
        }

        private void button1LogIn_Click(object sender, EventArgs e)
        {
            //login button was clicked

            //flag to hide the window till we are done typing
            getOutOfMyWay = true;
            updateVisibility();

            WindowExternalHelpers.SetForegroundWindow(loginWindowHandle);
            Thread.Sleep(500);
            //click the middle of the username field, delete old contents, type in new
            WindowExternalHelpers.clickHere(
                Location.X + comboBox1.Location.X + (comboBox1.Width / 2),
                Location.Y + comboBox1.Location.Y + (comboBox1.Height / 2));
            SendKeys.SendWait("{DEL 50}");
            SendKeys.SendWait("{BS 50}");
            SendKeys.SendWait(comboBox1.Text);
            //click the middle of the password field, delete old contents, type in new
            WindowExternalHelpers.clickHere(
                Location.X + textBox1Password.Location.X + (textBox1Password.Width / 2),
                 Location.Y + textBox1Password.Location.Y + (textBox1Password.Height / 2));
            SendKeys.SendWait("{DEL 50}");
            SendKeys.SendWait("{BS 50}");
            SendKeys.SendWait(textBox1Password.Text);
            //press enter to log in
            SendKeys.SendWait("{ENTER}");

            if (checkBox1RemeberUsername.Checked)
            {
                //save username and password
                if (!comboBox1.Items.Contains(comboBox1.Text))
                    comboBox1.Items.Add(comboBox1.Text);
                string passToSave = "";
                if (checkBox1RemeberPass.Checked)
                    passToSave = textBox1Password.Text;

                KeyValuePair<String, String> foundUser = userPass.FirstOrDefault(m => m.Key.ToLower() == comboBox1.Text.ToLower());
                if (foundUser.Key != null)
                {
                    userPass[foundUser.Key] = passToSave;
                }
                else
                {
                    userPass.Add(comboBox1.Text, passToSave);
                }
            }
            save();
            Thread.Sleep(1000);
            getOutOfMyWay = false;
            updateVisibility();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //new item selected from drop down, set the password as well
            string passToSet = "";
            KeyValuePair<String, String> foundUser = userPass.FirstOrDefault(m => m.Key.ToLower() == comboBox1.Text.ToLower());
            if (foundUser.Key != null)
            {
                passToSet=foundUser.Value;
            }
            textBox1Password.Text = passToSet;
        }

        private void button1deleteentry_Click(object sender, EventArgs e)
        {
            //remove entry
            if (comboBox1.Items.Contains(comboBox1.Text))
            {
                comboBox1.Items.Remove(comboBox1.Text);
                if (userPass.ContainsKey(comboBox1.Text))
                    userPass.Remove(comboBox1.Text);
                comboBox1.Text = textBox1Password.Text = "";
                save();
            }
        }

        private void load()
        {
            if (!File.Exists(Application.StartupPath + "\\" + saveFileName)) return;
            userPass.Clear();
            comboBox1.Items.Clear();
            textBox1Password.Text = comboBox1.Text = "";
            TextReader tr = new StreamReader(Application.StartupPath + "\\" + saveFileName);
            tr.ReadLine();//ignore intro
            string savedDate = tr.ReadLine();
            checkBox1RemeberUsername.Checked = (tr.ReadLine().Contains("true"));
            checkBox1RemeberPass.Checked = (tr.ReadLine().Contains("true"));
            string line = tr.ReadLine();
            string[] lastparts = line.Split(':');
            if (lastparts.Length > 1)
            {
                line = tr.ReadLine();
            }            
            while (line != null)
            {
                line = Crypto.DecryptStringAES(line, savedDate);
                string [] parts = line.Split(new string[] {"{{<LGG>}}"},StringSplitOptions.None);
                string userName = parts[0];
                string pass = "";
                if (parts.Length > 1) pass = parts[1];
                userPass.Add(userName, pass);
                comboBox1.Items.Add(userName);
                line = tr.ReadLine();
            }
            if (lastparts.Length > 1)
            {
                comboBox1.Text = lastparts[1];
                comboBox1_SelectionChangeCommitted(null, null);                
            }
            tr.Close();
        }
        
        private void save()
        {
            TextWriter tw = new StreamWriter(Application.StartupPath+"\\"+saveFileName);
            string currentDate = DateTime.Now.ToLongDateString();
            tw.WriteLine("This data is used by the program \"Lol Account Manager LGG\"");
            tw.WriteLine(currentDate);
            tw.WriteLine("Save Usernames: " + ((checkBox1RemeberUsername.Checked ? "true" : "false")));
            tw.WriteLine("Save Passwords: " + ((checkBox1RemeberPass.Checked ? "true" : "false")));
            tw.WriteLine("Last Selected Name:" + comboBox1.Text);
            foreach (KeyValuePair<String,String> userData in userPass)
            {
                string saveLine = userData.Key + "{{<LGG>}}" + userData.Value;
                //I know this is open source, but we don't want to make things too easy      
                saveLine = Crypto.EncryptStringAES(saveLine,currentDate);
                tw.WriteLine(saveLine);
            }
            tw.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm1 form = new AboutForm1();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void button1LogDisplay_Click(object sender, EventArgs e)
        {
            if (debugDisp == null)debugDisp = new DebugDisplay(this);
            if (debugDisp.IsDisposed) debugDisp = new DebugDisplay(this);
            debugDisp.StartPosition = FormStartPosition.Manual;
            debugDisp.Location = new Point(0, 0);
            debugDisp.Visible = true;
        }

        private void addLog(String textLine)
        {
            if (logBuilder == null) logBuilder = new StringBuilder("");
            logBuilder.AppendLine(textLine);

            if (logBuilder.Length > 10000) logBuilder = new StringBuilder("Log Erased to save memory.");


            if (debugDisp == null) return;
            if (debugDisp.IsDisposed) return;
            debugDisp.textBox2debug.Text = logBuilder.ToString();

        }
        public void clearLog()
        {
            logBuilder = new StringBuilder("");
            addLog("Log Cleared.");
        }

        private void button1getBig_Click(object sender, EventArgs e)
        {
            updateSize(true, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateSize(true, false);
        }

        private void snapTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveScreenArea("");
        }
        
    }    
}
