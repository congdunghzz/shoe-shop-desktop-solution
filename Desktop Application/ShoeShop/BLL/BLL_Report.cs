using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Report;
namespace BLL
{
    public class BLL_Report : MarshalByRefObject, IReport
    {
        Report.Report report = new Report.Report();

        public double Turnover(DateTime date)
        {
            return report.Turnover(date);
        }
        public double Cost(DateTime date)
        {
            return report.Cost(date);
        }
        public double Profit(DateTime date)
        {
            return report.Profit(date);
        }

        public List<DTO_OrderDetails> ShowOrders(DateTime date)
        {
            return report.ShowOrders(date);
        }

        public List<DTO_ImportDetails> ShowImports(DateTime date)
        {
            return report.ShowImports(date);
        }
    }
}
