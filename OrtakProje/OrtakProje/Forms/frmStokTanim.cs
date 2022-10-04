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
using Connection;
namespace OrtakProje.Forms
{
    public partial class frmStokTanim : BaseForm.frmBaseTanim
    {
        #region Objects
        SqlConnection con = null;
        myDataAdapter da = null;
        connection connection = new connection();
        #endregion
        #region Constructor
        public frmStokTanim()
        {
            grdList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            XdtMain.Columns.Add(new DataColumn("xref", typeof(int)));
            XdtMain.Columns.Add(new DataColumn("kod", typeof(string)));
            XdtMain.Columns.Add(new DataColumn("aciklama", typeof(string)));
            InitializeComponent();
        }
        #endregion
        #region Overridden
        protected override void LoadData()
        {
          connection.Open();
            //con = new SqlConnection("Data Source=.;Initial Catalog=gamateks;Integrated Security=True");
            //con.Open();
            SqlCommand cmm = new SqlCommand();
            //cmm.Connection = con;
            cmm.Connection = connection.Conobjcet;
            cmm.CommandText = "select a.xref, a.kod, a.aciklama from stoktanim a ";
            da = new myDataAdapter();
            da.SelectCommand = cmm;
            da.Fill(XdtMain);
            da.CreateCommand();
            grdList.DataSource = XdtMain;
            grdList.Columns[0].HeaderText = "XREF";
            grdList.Columns[0].Visible = false;
            grdList.Columns[1].HeaderText = "KOD";
            grdList.Columns[2].HeaderText = "AÇIKLAMA";
            //con.Close();
            connection.Close();
            base.LoadData();
        }
        protected override bool Validate()
        {
            foreach (DataRow r in XdtMain.Select("", "", DataViewRowState.CurrentRows))
            {
                if (helperClass.GetString(r, "kod", "").Trim() == "")
                {
                    MessageBox.Show("Kod Boş Olamaz");
                    return false;
                }
            }
            return base.Validate();
        }
        protected override void SaveData()
        {
            connection.Open();
            //con.Open();
            //SqlTransaction trans = con.BeginTransaction();
            SqlTransaction trans = connection.Conobjcet.BeginTransaction();
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
                connection.Close();
                //con.Close();
            }
        }
        protected override void XdtMain_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Add)
            {
                if (e.Row["xref"] == DBNull.Value || e.Row["xref"] == null)
                    e.Row["xref"] = helperClass.GetId("stoktanim");

            }

        }


        #endregion

        private void frmStokTanim_Load(object sender, EventArgs e)
        {

        }
    }
}
