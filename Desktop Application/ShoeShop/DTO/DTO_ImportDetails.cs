using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public interface IBLL_ImportDetails
    {
        bool AddImportDetails(DTO_ImportDetails imp);
        bool UpdateImportDetails(DTO_ImportDetails imp);
        bool DeleteImportDetails(DTO_ImportDetails imp);
        bool DeleteImport(string impID);
        long TotalCost(string ImpID);
        List<DTO_ImportDetails> LoadImportDetails();
    }
    [Serializable]

    public class DTO_ImportDetails
    {
        public string ImpID { get; set; }
        public string Supplier { get; set; }
        public long Price { get; set; }
        public DateTime DateImp { get; set; }
        public int AmountImp { get; set; }
        public string EmpID { get; set; }
        public string ProdID { get; set; }

        public DTO_ImportDetails(string impID, string supplier, long price, DateTime dateImp, int amountImp, string empID, string prodID)
        {
            ImpID = impID;
            Supplier = supplier;
            Price = price;
            DateImp = dateImp;
            AmountImp = amountImp;
            EmpID = empID;
            ProdID = prodID;
        }

        public DTO_ImportDetails() { }

    }
}
