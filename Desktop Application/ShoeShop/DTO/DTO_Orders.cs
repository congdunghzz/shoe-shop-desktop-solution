using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public interface IBLL_Orders
    {
        bool AddOrder(DTO_Orders ord);
        bool UpdateOrder(DTO_Orders ord);
        bool UpdateOrderWithTotal(DTO_Orders ord);
        bool DeleteOrder(DTO_Orders ord);
        bool AddOrderDetail(DTO_OrderDetails ord);
        bool UpdateOrderDetail(DTO_OrderDetails ord);
        bool DeleteOrderDetail(DTO_OrderDetails ord);
        List<DTO_Orders> LoadOrders();

        List<DTO_OrderDetails> LoadOrderDetails();

    }
    [Serializable]

    public class DTO_Orders
    {
        public string OrdID { get; set; }
        public DateTime DateOrd { get; set; }
        public string CusName { get; set; }
        public string CusNumPhone { get; set; }
        
        public float Total { get; set; }
        public string EmpID { get; set; }

        public DTO_Orders(string ordID, DateTime dateOrd, string cusName, string cusNumPhone, int total, string empID)
        {
            OrdID = ordID;
            DateOrd = dateOrd;
            CusName = cusName;
            CusNumPhone = cusNumPhone;
            Total = total;
            EmpID = empID;
        }
        public DTO_Orders() { }

    }
}
