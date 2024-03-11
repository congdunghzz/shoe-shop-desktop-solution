using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using DAL;
using DTO;
using System.ComponentModel;
using System.Security.Cryptography;
using ProductionsDll;

namespace OrdersDll
{
    public class Orders_Dll
    {
        
        private DAL_OrdersAccess ord;
        private DAL_OrderDetailsAccess ordDetails;
        private DAL_ProductionAccess pro;
        private Productions_Dll proDll;
        public Orders_Dll()
        {
            pro = new DAL_ProductionAccess();
            ord = new DAL_OrdersAccess();
            ordDetails = new DAL_OrderDetailsAccess();
            proDll = new Productions_Dll();
        }

        public bool CheckDataOrders (DTO_Orders o)
        {
            if (string.IsNullOrEmpty(o.OrdID) || string.IsNullOrEmpty(o.CusName) ||
                string.IsNullOrEmpty(o.EmpID) || 
                o.DateOrd == DateTime.MinValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckDataOrderDetails(DTO_OrderDetails o)
        {
            if (string.IsNullOrEmpty(o.OrdID) || string.IsNullOrEmpty(o.ProdID) ||
                o.Amount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private List<DTO_OrderDetails> ordWithID(string OrdID)
        {
            List<DTO_OrderDetails> listOrderDetails = ordDetails.OrdDetails_LoadData();
            List<DTO_OrderDetails> result = new List<DTO_OrderDetails>();
            foreach(DTO_OrderDetails o in listOrderDetails)
            {
                if(o.OrdID == OrdID)
                {
                    result.Add(o);
                }
            }
            return result;
        }
        public float Total(string OrdID)
        {
            
            float result = 0;
            List<DTO_OrderDetails> listOrderDetails = ordWithID(OrdID);
            List<DTO_Productions> listProductions = pro.Pro_LoadData();

            var newList = from orderDetail in listOrderDetails
                         join production in listProductions on orderDetail.ProdID equals production.ProdID
                         select new
                         {
                             orderDetail.OrdID,
                             orderDetail.ProdID,
                             orderDetail.Amount,
                             production.Price,
                             production.Discount
                         };
            foreach(var item in newList)
            {
                result += item.Price * item.Amount * (1-item.Discount);
            }
            return result;
        }

        private DTO_Productions GetPro(string proID)
        {
            List<DTO_Productions> listPro = pro.Pro_LoadData();
            foreach(var item in listPro)
            {
                if(item.ProdID == proID) return item;
            }
            return null;
        }

        private DTO_OrderDetails GetOrderDetail(string ordID, string prodID)
        {
            List<DTO_OrderDetails> listOrdDetails = this.LoadOrderDetails();
            foreach (DTO_OrderDetails item in listOrdDetails)
            {
                if (item.OrdID == ordID && item.ProdID == prodID)
                {
                    return item;

                }
            }
            return null;
        }

        private DTO_Orders GetOrder(string ordID)
        {
            List<DTO_Orders> listOrdDetails = this.LoadOrder();
            foreach (DTO_Orders item in listOrdDetails)
            {
                if (item.OrdID == ordID)
                {
                    return item;

                }
            }
            return null;
        }

        public bool AddOrder(DTO_Orders o)
        {
            if (CheckDataOrders(o))
            {
                try
                {
                    o.Total = 0;
                    return ord.Ord_Insert(o);
                }
                catch
                {
                    return false;
                }
            }
            else { return false; }

        }

        public bool AddOrderDetail(DTO_OrderDetails o)
        {
            if (CheckDataOrderDetails(o))
            {
                try
                {
                    DTO_Productions p = GetPro(o.ProdID);
                    int temp = p.Amount - o.Amount;
                    if(temp < 0)
                    {
                        return false;

                    }
                    else
                    {
                        p.Amount -= o.Amount;
                        DTO_Orders newOrd = GetOrder(o.OrdID);
                        if (ordDetails.OrdDetails_Insert(o))
                        {
                            return proDll.UpdateProduct(p) && UpdateOrder(newOrd);

                        }
                        else return false;
                    }
                    
                }
                catch
                {
                    return false;
                }
            }
            else { return false; }

        }

        public bool UpdateOrderDetail(DTO_OrderDetails o)
        {
            if (CheckDataOrderDetails(o))
            {
                try
                {
                    DTO_OrderDetails before = GetOrderDetail(o.OrdID, o.ProdID);
                    DTO_Productions p = GetPro(o.ProdID);
                    int temp = p.Amount - (o.Amount - before.Amount);
                    if(temp < 0)
                    {
                        return false;
                    }
                    else
                    {

                        if (ordDetails.Ord_Update(o))
                        {
                            p.Amount -= (o.Amount - before.Amount);
                            DTO_Orders newOrd = GetOrder(o.OrdID);
                            UpdateOrder(newOrd);

                            return proDll.UpdateProduct(p);
                        }
                        else return false;
                    }
                    
                }
                catch
                {
                    return false;
                }
            }
            else { return false; }

        }

        public bool UpdateOrder(DTO_Orders o)
        {
            if (CheckDataOrders(o))
            {
                try
                {

                  
                        o.Total = Total(o.OrdID);
                    

                    return ord.Ord_Update(o);
                }
                catch
                {
                    return false;
                }
            }
            else { return false; }

        }

        public bool UpdateOrderWithTotal(DTO_Orders o)
        {
            if (CheckDataOrders(o))
            {
                try
                {
                    o.Total = Total(o.OrdID);
                    return ord.Ord_Update(o);
                }
                catch
                {
                    return false;
                }
            }
            else { return false; }

        }

        public bool deleteOrderDetail(DTO_OrderDetails o)
        {
            if (CheckDataOrderDetails(o))
            {
                try
                {

                    DTO_Productions p = GetPro(o.ProdID);
                    DTO_OrderDetails before = GetOrderDetail(o.OrdID, o.ProdID);
                    p.Amount += before.Amount;
                    DTO_Orders newOrd = GetOrder(o.OrdID);
                    if (ordDetails.Ord_Delete(o))
                    {
                        return proDll.UpdateProduct(p) && UpdateOrder(newOrd);

                    }else return false;
                }
                catch
                {
                    return false;
                }
            }
            else { return false; }

        }

        public bool deleteOrders(DTO_Orders o)
        {
            if (CheckDataOrders(o))
            {
                try
                {

                    return ord.Ord_Delete(o);
                }
                catch
                {
                    return false;
                }
            }
            else { return false; }

        }

        public List<DTO_Orders> LoadOrder()
        {
            return ord.Ord_LoadData();
        }

        public List<DTO_OrderDetails> LoadOrderDetails()
        {
            return ordDetails.OrdDetails_LoadData();
        }
    }



    
}
