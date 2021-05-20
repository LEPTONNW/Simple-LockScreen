using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockScreen_FN
{
    public partial class SSV : Form
    {
        public SSV()
        {
            InitializeComponent();
        }

        private void SSV_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void SSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            var myForm = new Alert();
            myForm.Show();
        }
    }
}
