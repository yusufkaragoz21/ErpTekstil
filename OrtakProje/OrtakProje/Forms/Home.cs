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


        FormStokTanim frmstoktanim;
        private void mnStokTanim_Click(object sender, EventArgs e)
        {
            //acik olan sayfanin tekrar acilmasini engelledik
            //sadf
            if (frmstoktanim == null || frmstoktanim.IsDisposed)
            {
                frmstoktanim = new FormStokTanim();
                frmstoktanim.MdiParent = this;
                frmstoktanim.WindowState = FormWindowState.Maximized;
                frmstoktanim.Show();
            }
        }

        FormRenkTanim frmrenktanim;
        private void mnRenkTanim_Click(object sender, EventArgs e)
        {
            if (frmrenktanim == null || frmrenktanim.IsDisposed)
            {
                frmrenktanim = new FormRenkTanim();
                frmrenktanim.MdiParent = this;
                frmrenktanim.WindowState = FormWindowState.Maximized;
                frmrenktanim.Show();
            }
        }
        FormBirimTanim frmbirimtanim;
        private void mnBirimTanim_Click(object sender, EventArgs e)
        {
            if (frmbirimtanim == null || frmbirimtanim.IsDisposed)
            {
                frmbirimtanim = new FormBirimTanim();
                frmbirimtanim.MdiParent = this;
                frmbirimtanim.WindowState = FormWindowState.Maximized;
                frmbirimtanim.Show();
            }
        }
        FormFirmaTanim frmfirmatanim;
        private void mnFirmaTanim_Click(object sender, EventArgs e)
        {
            if (frmfirmatanim == null || frmfirmatanim.IsDisposed)
            {
                frmfirmatanim = new FormFirmaTanim();
                frmfirmatanim.MdiParent = this;
                frmfirmatanim.WindowState = FormWindowState.Maximized;
                frmfirmatanim.Show();
            }
        }
        FormDepoTanim frmdepotanim;
        private void mnDepoTanim_Click(object sender, EventArgs e)
        {
            if (frmdepotanim == null || frmdepotanim.IsDisposed)
            {
                frmdepotanim = new FormDepoTanim();
                frmdepotanim.MdiParent = this;
                frmdepotanim.WindowState = FormWindowState.Maximized;
                frmdepotanim.Show();
            }
        }
    }
}
