using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoLAccountManagerLGG
{
    public partial class DebugDisplay : Form
    {
        private MainLoginForm acm;
        public DebugDisplay(MainLoginForm in_acm)
        {
            acm = in_acm;
            InitializeComponent();
        }

        private void button1clearLog_Click(object sender, EventArgs e)
        {
            acm.clearLog();
        }
    }
}
