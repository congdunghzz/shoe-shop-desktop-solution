using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public interface IBLL_Productions

    { 
        bool AddProduct(DTO_Productions product);
        bool UpdateProduct(DTO_Productions product);
        bool DeleteProduct(DTO_Productions product);
        List<DTO_Productions> LoadProduct();
    }
    [Serializable]

    public class DTO_Productions
    {

        public string ProdID { get; set; }
        public string ProdName { get; set; }
        public int Price { get; set; }
        public string Material { get; set; }
        public float Discount { get; set; }
        public int Amount { get; set; }
        

        public DTO_Productions(string prodID, string prodName, int price, string material, float discount, int amount)
        {
            ProdID = prodID;
            ProdName = prodName;
            Price = price;
            Material = material;
            Discount = discount;
            Amount = amount;
        }

        public DTO_Productions() { }
    }
}
