using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDll
{
    public class Empolyees_Dll
    {

        private DAL_EmloyeeAccess emp;

        public Empolyees_Dll()
        {
            emp = new DAL_EmloyeeAccess();

        }

        public bool CheckData(DTO_Employees employee)
        {
            if (string.IsNullOrEmpty(employee.EmpID) || string.IsNullOrEmpty(employee.EmpName) || string.IsNullOrEmpty(employee.Position) ||
                string.IsNullOrEmpty(employee.Email) || employee.Birth == DateTime.MinValue || string.IsNullOrEmpty(employee.PhoneNum) ||
                employee.Salary <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool InsertEmployee(DTO_Employees employee)
        {
            if (CheckData(employee))
            {
                try
                {
                    return emp.Emp_Insert(employee);
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        public bool UpdateEmployee(DTO_Employees employee)
        {
            if (CheckData(employee))
            {
                try
                {
                    return emp.Emp_Update(employee);
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        public bool DeleteEmployee(DTO_Employees employee)
        {

            try
            {
                return emp.Emp_Delete(employee);
            }
            catch
            {
                return false;
            }

        }

        public List<DTO_Employees> LoadEmployee()
        {
            return emp.Emp_LoadData();
        }
    }
}
