using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_OrdersAccess
    {
        DAL_DataConnect dataConnect = new DAL_DataConnect();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd;
        SqlConnection conn;

        public List<DTO_Orders> Ord_LoadData()
        {
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            List<DTO_Orders> listData = new List<DTO_Orders>();
            SqlDataReader reader;

            cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from Orders";
            try
            {
                dataConnect.OpenConnect(conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DTO_Orders ord = new DTO_Orders();
                    ord.OrdID = reader.GetString(0).Trim();
                    ord.DateOrd = reader.GetDateTime(1);
                    ord.CusName = reader.GetString(2).Trim();
                    ord.CusNumPhone = reader.GetString(3).Trim();
                    ord.EmpID = reader.GetString(4).Trim();
                    ord.Total = reader.GetInt32(5);

                    listData.Add(ord);
                }
                reader.Close();
                dataConnect.CloseConnect(conn);
                return listData;

            }
            catch
            {
                dataConnect.CloseConnect(conn);
                return null;
            }
        }

        public bool Ord_Insert(DTO_Orders ord)
        {
            string sql = "INSERT INTO Orders(OrdID, DateOrd, CusName, CusNumPhone, EmpID, Total) VALUES(@OrdID, @DateOrd, @CusName, @CusNumPhone, @EmpID, @Total)";
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("@OrdID", SqlDbType.Char).Value = ord.OrdID;
                cmd.Parameters.Add("@DateOrd", SqlDbType.Date).Value = ord.DateOrd;
                cmd.Parameters.Add("@CusName", SqlDbType.NVarChar).Value = ord.CusName;
                cmd.Parameters.Add("@CusNumPhone", SqlDbType.VarChar).Value = ord.CusNumPhone;
                cmd.Parameters.Add("@EmpID", SqlDbType.Char).Value = ord.EmpID;
                cmd.Parameters.Add("@Total", SqlDbType.Int).Value = ord.Total;
                cmd.ExecuteNonQuery();
                dataConnect.CloseConnect(conn);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Ord_Update(DTO_Orders ord)
        {
            string sql = "UPDATE Orders SET DateOrd = @DateOrd, CusName = @CusName, CusNumPhone = @CusNumPhone, EmpID = @EmpID, Total = @Total Where OrdID = @OrdID";
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("@OrdID", SqlDbType.Char).Value = ord.OrdID;
                cmd.Parameters.Add("@DateOrd", SqlDbType.Date).Value = ord.DateOrd;
                cmd.Parameters.Add("@CusName", SqlDbType.NVarChar).Value = ord.CusName;
                cmd.Parameters.Add("@CusNumPhone", SqlDbType.VarChar).Value = ord.CusNumPhone;
                cmd.Parameters.Add("@EmpID", SqlDbType.Char).Value = ord.EmpID;
                cmd.Parameters.Add("@Total", SqlDbType.Int).Value = ord.Total;
                cmd.ExecuteNonQuery();

                dataConnect.CloseConnect(conn);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Ord_Delete(DTO_Orders ord)
        {
            cmd = new SqlCommand();
            conn = dataConnect.Connect();

            string sql = "DELETE Orders WHERE OrdID = @OrdID";
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("OrdID", SqlDbType.Char).Value = ord.OrdID;
                cmd.ExecuteNonQuery();

                dataConnect.CloseConnect(conn);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
