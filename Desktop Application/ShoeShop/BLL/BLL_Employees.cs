using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesDll;
namespace BLL
{

    public class BLL_Employees : MarshalByRefObject, IBLL_Employees
    {
        Empolyees_Dll emp = new Empolyees_Dll();
        public bool AddEmployee(DTO_Employees e)
        {
            return emp.InsertEmployee(e);
        }
        public bool UpdateEmployee(DTO_Employees e)
        {
            return emp.UpdateEmployee(e);
        }
        public bool DeleteEmployee(DTO_Employees e)
        {
            return emp.DeleteEmployee(e);
        }
        public List<DTO_Employees> LoadEmployee()
        {
            return emp.LoadEmployee();
        }
    }
}

