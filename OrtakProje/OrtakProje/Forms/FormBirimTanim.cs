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
//using ClassLibrary;


namespace OrtakProje.Forms
{
    public partial class FormBirimTanim : BaseForm.FormBaseTanim
    {

        #region Objects
        SqlConnection con = null;
        myDataAdapter da = null;
        //connection conn = new connection();

        #endregion

        #region Constructor
        public FormBirimTanim()
        {
            grdList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            xdt.Columns.Add(new DataColumn("xref", typeof(int)));
            xdt.Columns.Add(new DataColumn("kod", typeof(string)));
            xdt.Columns.Add(new DataColumn("aciklama", typeof(string)));
            InitializeComponent();
        }
        #endregion

        #region Properties
        #endregion

        #region Overridden
        protected override void LoadData()
        {
            //conn.Open();

            con = new SqlConnection("Data Source=.;Initial Catalog=gamateks;Integrated Security=True");
            con.Open();
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = con;
            cmm.CommandText = "select a.xref, a.kod, a.aciklama from birimtanim a ";
            da = new myDataAdapter();
            da.SelectCommand = cmm;
            da.Fill(xdt);
            da.CreateCommand();
            con.Close();
            base.LoadData();
        }
        protected override void ControlConfigure()
        {
            grdList.DataSource = xdt;
            grdList.Columns[0].HeaderText = "XREF";
            grdList.Columns[0].Visible = false;
            grdList.Columns[1].HeaderText = "KOD";
            grdList.Columns[2].HeaderText = "AÇIKLAMA";
            base.ControlConfigure();
        }
        protected override bool Validate()
        {
            foreach (DataRow r in xdt.Select("", "", DataViewRowState.CurrentRows))
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
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                da.Update(xdt, trans);
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
                    e.Row["xref"] = helperClass.GetId("birimtanim");

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
    }
}
