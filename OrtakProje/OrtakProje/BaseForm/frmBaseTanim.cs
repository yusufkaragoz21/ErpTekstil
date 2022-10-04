using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrtakProje.BaseForm
{
    public partial class frmBaseTanim : Form
    {


        #region Objects
        protected DataTable XdtMain = new DataTable();
        #endregion

        #region Constructor
        public frmBaseTanim()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        #endregion

       

        #region Private Methods
        protected virtual void LoadData()
        {

        }
        protected virtual bool Validate() { return true; }
        protected virtual void SaveData() { }
       
       
        #endregion

        #region Public Methods
        protected virtual void ControlConfigure()
        {

        }

        #endregion

        #region Events
        private void frmBaseTanim_Load(object sender, EventArgs e)
        {
            XdtMain.RowChanging += XdtMain_RowChanging;
            XdtMain.RowChanged += XdtMain_RowChanged;
            ControlConfigure();
                LoadData();

        }

        protected virtual void XdtMain_RowChanged(object sender, DataRowChangeEventArgs e)
        {
           
        }

        protected virtual void XdtMain_RowChanging(object sender, DataRowChangeEventArgs e)
        {
           
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                SaveData();
            }
        }


        private void frmBaseTanim_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Değişikler Kaydedilsin mi?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validate())
                {
                    SaveData();
                }
            }
           
        }

        #endregion


    }
}
