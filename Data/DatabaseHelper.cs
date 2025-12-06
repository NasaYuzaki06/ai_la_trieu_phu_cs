using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_la_trieu_phu.Data
{
    internal class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyConnect"].ConnectionString;
        }

        public static SqlConnection GetConnection()
        {
            string stringConnect = GetConnectionString();
            return new SqlConnection(stringConnect);
        }
    }
}
