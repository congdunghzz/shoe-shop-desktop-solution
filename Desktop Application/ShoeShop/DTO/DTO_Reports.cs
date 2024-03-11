using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public interface IReport
    {
        double Turnover(DateTime date);
        double Cost(DateTime date);
        double Profit(DateTime date);
        List<DTO_OrderDetails> ShowOrders(DateTime date);
        List<DTO_ImportDetails> ShowImports(DateTime date);

    }
}
