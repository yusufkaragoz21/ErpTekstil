using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ClassLibrary
{
    public class connection
    {

        SqlConnection connect = null;
        public SqlConnection Conobjcet
        {
            get { return connect; }
        }
        public connection()
        {
            this.connect = new SqlConnection(System.IO.File.ReadAllText(@"C:\serverGamateks.txt"));
        }

        public void Open()
        {
            if (connect != null)
            {
                connect.Open();
            }
        }
        public void Close()
        {
            connect.Close();
        }

    }
}
