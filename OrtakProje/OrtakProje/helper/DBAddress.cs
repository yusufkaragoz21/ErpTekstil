using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtakProje.helper
{
    public static class DBAddress
    {
        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=gamateks;Integrated Security=True");
             return conn;
        } 
    }
}
