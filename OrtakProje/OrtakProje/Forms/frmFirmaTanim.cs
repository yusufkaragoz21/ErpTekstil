using OrtakProje.BaseClasses;
using OrtakProje.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrtakProje.Forms
{
    public partial class frmTanimFirma : BaseForm.frmBaseTanim
    {
        #region Objects
        //SqlDataAdapter da = null;
        SqlConnection con = null;
        myDataAdapter da = null;
        #endregion

        #region Constructor
        public frmTanimFirma()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        #endregion

        #region Overridden
        protected override void LoadData()
        {

            con = new SqlConnection("Data Source=.;Initial Catalog=gamateks;Integrated Security=True");
            con.Open();
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = con;
            cmm.CommandText = "select a.xref, a.kod, a.aciklama from firmatanim a ";
            da = new myDataAdapter();
            da.SelectCommand = cmm;
            da.Fill(XdtMain);         
            da.CreateCommand();  
            grdList.DataSource = XdtMain;
            con.Close();
            base.LoadData();
        }
        protected override bool Validate()
        {
            if(XdtMain.Select("kod is null or kod = ''","",DataViewRowState.CurrentRows).Length > 0)
            {
                MessageBox.Show("Kod Boş Olamaz");
                return false;
            }

            return base.Validate();
        }

        protected override void SaveData()
        {
            con.Open();
            SqlTransaction trans = con.BeginTransaction();

            try
            {
                
                da.Update(XdtMain, trans);               
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                
            }
            finally
            {
                con.Close();
            }

           



          
        }

        protected override void XdtMain_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Add)
            {
                if (e.Row["xref"] == DBNull.Value || e.Row["xref"] == null)
                    e.Row["xref"] = helperClass.GetId("firmatanim");
           
            }

        }



        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion

        #region Events
        #endregion

        #region Nested
        #endregion

        private void frmTanimFirma_Load(object sender, EventArgs e)
        {

        }
    }
}
