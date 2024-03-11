using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_DataConnect
    {
        internal static string connString = "Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=DesktopApp;Integrated Security=True";

        public SqlConnection Connect()
        {
            SqlConnection conn;
            conn = new SqlConnection(connString);
            return conn;
        }

        public void OpenConnect(SqlConnection conn)
        {
            if(conn == null || conn.ConnectionString == null)
            {
                conn = new SqlConnection(connString);
                conn.Open();
            }
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void CloseConnect(SqlConnection conn)
        {
            if(conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

    }
}
