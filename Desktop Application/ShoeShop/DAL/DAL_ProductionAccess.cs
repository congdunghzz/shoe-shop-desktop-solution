using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL

{
    public class DAL_ProductionAccess
    {
        DAL_DataConnect dataConnect = new DAL_DataConnect();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(DAL_DataConnect.connString);
        public List<DTO_Productions> Pro_LoadData()
        {
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            List<DTO_Productions> listData = new List<DTO_Productions>();
            SqlDataReader reader;
             
            cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from Productions";
            try
            {
                dataConnect.OpenConnect(conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DTO_Productions pro = new DTO_Productions();
                    pro.ProdID = reader.GetString(0).Trim();
                    pro.ProdName = reader.GetString(1).Trim();
                    pro.Price = reader.GetInt32(2);
                    pro.Material = reader.GetString(3).Trim();
                    pro.Discount = float.Parse(reader["Discount"].ToString());
                    pro.Amount = reader.GetInt32(5);

                    listData.Add(pro);
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

        public bool Pro_Insert(DTO_Productions pro)
        {
            string sql = "INSERT INTO Productions(ProdID, ProdName, Price, Material, Discount, Amount) VALUES(@ProdID, @ProdName, @Price, @Material, @Discount, @Amount)";
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("@ProdID", SqlDbType.Char).Value = pro.ProdID;
                cmd.Parameters.Add("@ProdName", SqlDbType.NVarChar).Value = pro.ProdName;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = pro.Price;
                cmd.Parameters.Add("@Material", SqlDbType.NVarChar).Value = pro.Material;
                cmd.Parameters.Add("@Discount", SqlDbType.Float).Value = pro.Discount;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = pro.Amount;
                cmd.ExecuteNonQuery();
                dataConnect.CloseConnect(conn);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Pro_Delete(DTO_Productions pro)
        {
            cmd = new SqlCommand();
            conn = dataConnect.Connect();

            string sql = "DELETE Productions WHERE ProdID = @ProdID";
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("ProdID", SqlDbType.Char).Value = pro.ProdID;
                cmd.ExecuteNonQuery();

                dataConnect.CloseConnect(conn);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Pro_Update(DTO_Productions pro)
        {
            string sql = "UPDATE Productions SET ProdName = @ProdName, Price = @Price, Material = @Material, Discount = @Discount, Amount = @Amount WHERE ProdID = @ProdID";
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("@ProdID", SqlDbType.Char).Value = pro.ProdID;
                cmd.Parameters.Add("@ProdName", SqlDbType.NVarChar).Value = pro.ProdName;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = pro.Price;
                cmd.Parameters.Add("@Material", SqlDbType.NVarChar).Value = pro.Material;
                cmd.Parameters.Add("@Discount", SqlDbType.Float).Value = pro.Discount;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = pro.Amount;

                cmd.ExecuteNonQuery();

                dataConnect.CloseConnect(conn);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

