using DTO;
using ImportDetailsDll;
using OrdersDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    public class Report 
    {
        public double turnover { get; set; }
        public double profit { get; set; }
        public double cost { get; set; }
        public DateTime DateRp { get; set; }

        ImportDetails_Dll imports;
        Orders_Dll orders;

        public Report()
        {
             imports = new ImportDetails_Dll();
             orders = new Orders_Dll();
        }
        public double Turnover (DateTime date)
        {
            double turnover = 0;

            List<DTO_Orders> listOrd = orders.LoadOrder();
            
            foreach(DTO_Orders o in listOrd)
            {
                if(o.DateOrd.Month == date.Month && o.DateOrd.Year == date.Year)
                {
                    turnover += orders.Total(o.OrdID);

                }
            }

            return turnover;
        }

        public double Cost (DateTime date)
        {
            double cost = 0;
            List<DTO_ImportDetails>listImports = imports.LoadImportDetails();
            List<DTO_ImportDetails> listImportResult = new List<DTO_ImportDetails>();
            HashSet<string> listID = new HashSet<string>();
            foreach(DTO_ImportDetails imp in listImports)
            {
                if(imp.DateImp.Month == date.Month && imp.DateImp.Year == date.Year && !listID.Contains(imp.ImpID))
                {
                    cost += imports.TotalCost(imp.ImpID);
                    listID.Add(imp.ImpID);
                }
            }

            return cost;
        }

        public double Profit (DateTime date)
        {
            return Turnover(date) - Cost(date);
        }

        public List<DTO_OrderDetails> ShowOrders(DateTime date)
        {

            List<DTO_Orders> listOrder = orders.LoadOrder();
            List<DTO_OrderDetails> listOrderDetails = orders.LoadOrderDetails();
            List<DTO_OrderDetails> listResult = new List<DTO_OrderDetails>(); 
            foreach (DTO_Orders ord in listOrder)
            {
                if(ord.DateOrd.Month == date.Month && ord.DateOrd.Year == date.Year)
                {
                    foreach(DTO_OrderDetails o in listOrderDetails)
                    {
                        if (ord.OrdID == o.OrdID) listResult.Add(o);
                    }
                }
            }
            return listResult;
        }

        public List<DTO_ImportDetails> ShowImports(DateTime date)
        {
            List<DTO_ImportDetails> listImport = imports.LoadImportDetails();
            List<DTO_ImportDetails> listResult = new List<DTO_ImportDetails>();
            foreach(DTO_ImportDetails i in listImport)
            {
                if(i.DateImp.Month == date.Month && i.DateImp.Year == date.Year) listResult.Add(i);
            }

            return listResult;
        }
    }
}
