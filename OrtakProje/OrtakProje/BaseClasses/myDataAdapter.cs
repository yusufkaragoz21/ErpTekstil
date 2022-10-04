using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtakProje.BaseClasses
{
    public  class myDataAdapter
    {
        #region Objects
        SqlDataAdapter da = null;
        #endregion

        #region Constructor
        public myDataAdapter()
        {
            da = new SqlDataAdapter();
        }
        #endregion

        #region Properties
        public SqlCommand SelectCommand { get { return da.SelectCommand; } set { da.SelectCommand = value; } }
        public SqlDataAdapter propDa { get { return da; } set { da = value; } }
        #endregion

        #region Overridden
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods       
        public void Fill(DataTable dt)
        {
            da.Fill(dt);
        }
        public void Update(DataTable dt)
        {
            da.Update(dt);
            dt.AcceptChanges(); 
        }
        public void Update(DataSet ds, string tablename)
        {

        }
        public void Update(DataTable dt, SqlTransaction trans)
        {
            da.UpdateCommand.Transaction = trans;
            da.DeleteCommand.Transaction = trans;
            da.InsertCommand.Transaction = trans;
            this.Update(dt);
        }
        public void CreateCommand(SqlCommandBuilder cb)
        {
            da.InsertCommand = cb.GetInsertCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
            da.DeleteCommand = cb.GetDeleteCommand();
        }
        public void CreateCommand()
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
            da.DeleteCommand = cb.GetDeleteCommand();
        }
        #endregion

        #region Events
        #endregion

        #region Nested
        #endregion





    }
}
