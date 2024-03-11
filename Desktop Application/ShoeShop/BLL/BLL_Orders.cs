using DTO;
using OrdersDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    

    public class BLL_Orders : MarshalByRefObject, IBLL_Orders
    {
        Orders_Dll order = new Orders_Dll();
        public bool AddOrder(DTO_Orders ord)
        {
            return order.AddOrder(ord);
        }
        public bool AddOrderDetail(DTO_OrderDetails ord)
        {
            return order.AddOrderDetail(ord);
        }
        public bool UpdateOrder(DTO_Orders ord)
        {
            return order.UpdateOrder(ord);
        }
        public bool UpdateOrderWithTotal(DTO_Orders ord)
        {
            return order.UpdateOrderWithTotal(ord);
        }
        public bool UpdateOrderDetail(DTO_OrderDetails ord)
        {
            return order.UpdateOrderDetail(ord);
        }
        public bool DeleteOrder(DTO_Orders ord)
        {
            return order.deleteOrders(ord);
        }
        public bool DeleteOrderDetail(DTO_OrderDetails ord)
        {
            return order.deleteOrderDetail(ord);
        }
        public List<DTO_Orders> LoadOrders()
        {
            return order.LoadOrder();
        }
        public List<DTO_OrderDetails> LoadOrderDetails()
        {
            return order.LoadOrderDetails();
        }

    }
}
