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
    public class DAL_OrderDetailsAccess
    {
        DAL_DataConnect dataConnect = new DAL_DataConnect();
        
        SqlCommand cmd;
        SqlConnection conn;

        public List<DTO_OrderDetails> OrdDetails_LoadData()
        {
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            List<DTO_OrderDetails> listData = new List<DTO_OrderDetails>();
            SqlDataReader reader;

            cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from OrderDetails";
            try
            {
                dataConnect.OpenConnect(conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DTO_OrderDetails ord = new DTO_OrderDetails();
                    ord.OrdID = reader.GetString(0).Trim();
                    ord.ProdID = reader.GetString(1).Trim();
                    ord.Amount = reader.GetInt32(2);

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

        public bool OrdDetails_Insert(DTO_OrderDetails ord)
        {
            string sql = "INSERT INTO OrderDetails(OrdID, ProdID, Amount) VALUES(@OrdID, @ProdID, @Amount)";
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("@OrdID", SqlDbType.Char).Value = ord.OrdID;
                cmd.Parameters.Add("@ProdID", SqlDbType.Char).Value = ord.ProdID;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = ord.Amount;
                cmd.ExecuteNonQuery();
                dataConnect.CloseConnect(conn);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Ord_Update(DTO_OrderDetails ord)
        {
            string sql = "UPDATE OrderDetails SET Amount = @Amount where OrdID = @OrdID and ProdID = @ProdID";
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("@OrdID", SqlDbType.Char).Value = ord.OrdID;
                cmd.Parameters.Add("@ProdID", SqlDbType.Char).Value = ord.ProdID;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = ord.Amount;
                cmd.ExecuteNonQuery();

                dataConnect.CloseConnect(conn);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Ord_Delete(DTO_OrderDetails ord)
        {
            cmd = new SqlCommand();
            conn = dataConnect.Connect();

            string sql = "DELETE OrderDetails WHERE OrdID = @OrdID and ProdID = @ProdID";
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("OrdID", SqlDbType.Char).Value = ord.OrdID;
                cmd.Parameters.Add("@ProdID", SqlDbType.Char).Value = ord.ProdID;
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
