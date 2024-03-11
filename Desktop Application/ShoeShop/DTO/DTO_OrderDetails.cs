using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]

    public class DTO_OrderDetails
    {
        public string OrdID { get; set; }
        public string ProdID { get; set; }

        public int Amount { get; set; }

        public DTO_OrderDetails(string ordID, string prodID, int amount)
        {
            OrdID = ordID;
            ProdID = prodID;
            Amount = amount;
        }

        public DTO_OrderDetails() { }
    }
}
