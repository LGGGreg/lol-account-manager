using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoLAccountManagerLGG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IntPtr search = WindowExternalHelpers.FindWindowByCaption(IntPtr.Zero, "LoL Account Manager");
            if (WindowExternalHelpers.IsWindow(search))
            {
                if (MessageBox.Show("LoL Account Manager is already running\r\nDo you want to stop it and use this one instead?", "LoL Account Manager Already Running", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    WindowExternalHelpers.SendMessage(search, WindowExternalHelpers.WM_SYSCOMMAND, WindowExternalHelpers.SC_CLOSE, 0);
                else
                    return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainLoginForm());
        }
    }
}
