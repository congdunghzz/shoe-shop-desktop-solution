using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public interface IBLL_Employees
    {
        bool AddEmployee(DTO_Employees e);
        bool UpdateEmployee(DTO_Employees e);
        bool DeleteEmployee(DTO_Employees e);
        List<DTO_Employees> LoadEmployee();

    }
    [Serializable]

    public class DTO_Employees
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public string PhoneNum { get; set; }
        public long Salary { get; set; }

        public DTO_Employees() { }

        public DTO_Employees(string empID, string empName, string position, string email, DateTime birth, string phoneNum, long salary)
        {
            EmpID = empID;
            EmpName = empName;
            Position = position;
            Email = email;
            Birth = birth;
            PhoneNum = phoneNum;
            Salary = salary;
        }
    }
}
