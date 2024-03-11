using DTO;
using ImportDetailsDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class BLL_ImportDetails : MarshalByRefObject, IBLL_ImportDetails
    {
        ImportDetails_Dll importDetails = new ImportDetails_Dll();
        public bool AddImportDetails (DTO_ImportDetails imp)
        {
            return importDetails.InsertImportDetails (imp);
        }
        public bool UpdateImportDetails(DTO_ImportDetails imp)
        {
            return importDetails.UpdateImportDetails(imp);
        }
        public bool DeleteImportDetails(DTO_ImportDetails imp)
        {
            return importDetails.DeletetImportDetails(imp);
        }
        public bool DeleteImport(string impID)
        {
            return importDetails.DeletetImport(impID);
        }
        public List<DTO_ImportDetails> LoadImportDetails()
        {
            return importDetails.LoadImportDetails();
        }
        public long TotalCost(string ImpID)
        {
            return importDetails.TotalCost(ImpID);
        }
    }
}
