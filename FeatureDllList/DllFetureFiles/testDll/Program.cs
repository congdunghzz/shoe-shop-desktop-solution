using DTO;
using OrdersDll;
using ImportDetailsDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Orders_Dll data = new Orders_Dll();
            ImportDetails_Dll import = new ImportDetails_Dll();
            DTO_OrderDetails orderDetail = new DTO_OrderDetails("ord001", "pro01", 1);
            Console.WriteLine(import.TotalCost("imp001"));
           /* List<DTO_Orders> ord = data.LoadOrder();
            foreach(DTO_Orders item in ord)
            {
                 Console.WriteLine(item.CusName);
            }*/
        }
    }
}
