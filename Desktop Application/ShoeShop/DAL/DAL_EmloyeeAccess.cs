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
    public class DAL_EmloyeeAccess
    {
        DAL_DataConnect dataConnect = new DAL_DataConnect();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd;
        SqlConnection conn;

        public List<DTO_Employees> Emp_LoadData()
        {
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            List<DTO_Employees> listData = new List<DTO_Employees>();
            SqlDataReader reader;

            cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from Employees";
            try
            {
                dataConnect.OpenConnect(conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DTO_Employees emp = new DTO_Employees();
                    emp.EmpID = reader.GetString(0).Trim();
                    emp.EmpName = reader.GetString(1).Trim();
                    emp.Position = reader.GetString(2).Trim();
                    emp.Email = reader.GetString(3).Trim();
                    emp.Birth = reader.GetDateTime(4);
                    emp.PhoneNum = reader.GetString(5).Trim();
                    emp.Salary = reader.GetInt32(6);


                    listData.Add(emp);
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

        public bool Emp_Insert(DTO_Employees emp)
        {
            string sql = "Insert into Employees(EmpID, EmpName, Position, Email, Birth, PhoneNum, Salary) values(@EmpID, @EmpName, @Position, @Email, @Birth, @PhoneNum, @Salary)";
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("@EmpID", SqlDbType.Char).Value = emp.EmpID;
                cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = emp.EmpName;
                cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = emp.Position;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = emp.Email;
                cmd.Parameters.Add("@Birth", SqlDbType.Date).Value = emp.Birth;
                cmd.Parameters.Add("@PhoneNum", SqlDbType.VarChar).Value = emp.PhoneNum;
                cmd.Parameters.Add("@Salary", SqlDbType.Int).Value = emp.Salary;
                cmd.ExecuteNonQuery();
                dataConnect.CloseConnect(conn);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Emp_Update(DTO_Employees emp)
        {
            string sql = "UPDATE Employees SET  EmpName = @EmpName, Position = @Position, Email = @Email, Birth = @Birth, PhoneNum = @PhoneNum, Salary = @Salary where EmpID = @EmpID";
            conn = dataConnect.Connect();
            cmd = new SqlCommand();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("@EmpID", SqlDbType.Char).Value = emp.EmpID;
                cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = emp.EmpName;
                cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = emp.Position;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = emp.Email;
                cmd.Parameters.Add("@Birth", SqlDbType.Date).Value = emp.Birth;
                cmd.Parameters.Add("@PhoneNum", SqlDbType.VarChar).Value = emp.PhoneNum;
                cmd.Parameters.Add("@Salary", SqlDbType.Int).Value = emp.Salary;
                cmd.ExecuteNonQuery();

                dataConnect.CloseConnect(conn);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Emp_Delete(DTO_Employees emp)
        {
            cmd = new SqlCommand();
            conn = dataConnect.Connect();

            string sql = "DELETE Employees WHERE EmpID = @EmpID";
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dataConnect.OpenConnect(conn);
                cmd.Parameters.Add("EmpID", SqlDbType.Char).Value = emp.EmpID;
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
