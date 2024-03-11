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
    public class DAL_ImportDetailsAccess
    {
        DAL_DataConnect dataConnect = new DAL_DataConnect();
        SqlCommand cmd;
        SqlConnection conn;
        
        public List<DTO_ImportDetails> ImportDetails_LoadData()
        {
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            List<DTO_ImportDetails> listData = new List<DTO_ImportDetails>();
            SqlDataReader reader;

            cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from ImportDetails";
            try
            {
                dataConnect.OpenConnect(conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DTO_ImportDetails imp = new DTO_ImportDetails();
                    imp.ImpID = reader.GetString(0).Trim();
                    imp.Supplier = reader.GetString(1).Trim();
                    imp.Price = reader.GetInt32(2);
                    imp.DateImp = reader.GetDateTime(3);
                    imp.AmountImp = reader.GetInt32(4);
                    imp.EmpID = reader.GetString(5).Trim();
                    imp.ProdID = reader.GetString(6).Trim();

                    listData.Add(imp);
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

        public bool ImportDetails_Insert(DTO_ImportDetails imp)
        {
            string sql = "INSERT INTO ImportDetails(ImpID, Supplier, Price, DateImp, AmountImp, EmpID, ProdID) VALUES(@ImpID, @Supplier, @Price, @DateImp, @AmountImp, @EmpID, @ProdID)";
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("@ImpID", SqlDbType.Char).Value = imp.ImpID;
                cmd.Parameters.Add("@Supplier", SqlDbType.NVarChar).Value = imp.Supplier;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = imp.Price;
                cmd.Parameters.Add("@DateImp", SqlDbType.Date).Value = imp.DateImp;
                cmd.Parameters.Add("@AmountImp", SqlDbType.Int).Value = imp.AmountImp;
                cmd.Parameters.Add("@EmpID", SqlDbType.Char).Value = imp.EmpID;
                cmd.Parameters.Add("@ProdID", SqlDbType.Char).Value = imp.ProdID;

                cmd.ExecuteNonQuery();
                dataConnect.CloseConnect(conn);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool ImportDetails_Update(DTO_ImportDetails imp)
        {
            string sql = "UPDATE ImportDetails SET Supplier = @Supplier, Price = @Price, DateImp = @DateImp, AmountImp = @AmountImp, EmpID = @EmpID, ProdID =@ProdID Where ImpID = @ImpID and ProdID = @ProdID";
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("@ImpID", SqlDbType.Char).Value = imp.ImpID;
                cmd.Parameters.Add("@Supplier", SqlDbType.NVarChar).Value = imp.Supplier;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = imp.Price;
                cmd.Parameters.Add("@DateImp", SqlDbType.Date).Value = imp.DateImp;
                cmd.Parameters.Add("@AmountImp", SqlDbType.Int).Value = imp.AmountImp;
                cmd.Parameters.Add("@EmpID", SqlDbType.Char).Value = imp.EmpID;
                cmd.Parameters.Add("@ProdID", SqlDbType.Char).Value = imp.ProdID;
                cmd.ExecuteNonQuery();

                dataConnect.CloseConnect(conn);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool ImportDetails_Delete(DTO_ImportDetails imp)
        {
            conn = dataConnect.Connect();

            cmd = new SqlCommand();
            string sql = "DELETE ImportDetails WHERE ImpID = @ImpID and ProdID = @ProdID";
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("ImpID", SqlDbType.Char).Value = imp.ImpID;
                cmd.Parameters.Add("ProdID", SqlDbType.Char).Value = imp.ProdID;
                cmd.ExecuteNonQuery();

                dataConnect.CloseConnect(conn);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Imports_Delete(string ImpID)
        {
            cmd = new SqlCommand();
            conn = dataConnect.Connect();

            string sql = "DELETE ImportDetails WHERE ImpID = @ImpID";
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("ImpID", SqlDbType.Char).Value = ImpID;
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
