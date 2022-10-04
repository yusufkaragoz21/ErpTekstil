using OrtakProje.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrtakProje
{
    public partial class Home : Form
    {
        #region Object
        #endregion
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void tanımlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void mnFirmaTanim_Click(object sender, EventArgs e)
        {
            frmTanimFirma frm = new frmTanimFirma();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
