using OrtakProje.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtakProje.Classes
{
    internal class stokHareketClass
    {
        SqlConnection conn=DBAddress.GetDBConnection();
        
        public void Init()
        {
            
        }
        public Result LoadData()
        {
            return new Result { resultbool=true,resultmessage=""};
        }
        public Result Validate() 
        {
            conn.Open();
            conn.Close();
            return null; 
        }
        public Result ValidateDelete() 
        {
            return null; 
        }
        public Result Save()
        {
            return null;
        }
        public Result Delete()
        {
            return null;
        }




    }
    public class Result
    {
        public  bool resultbool { get ; set ; }
        public string resultmessage { get; set; }
    }
}
