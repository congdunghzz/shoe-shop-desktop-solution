using DAL;
using DTO;
using ProductionsDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportDetailsDll
{
    public class ImportDetails_Dll
    {
        private DAL_ImportDetailsAccess imp;
        private DAL_ProductionAccess pro;
        private Productions_Dll proDll;
        public ImportDetails_Dll()
        {
            imp = new DAL_ImportDetailsAccess();
            proDll = new Productions_Dll();
        }

        public bool CheckData(DTO_ImportDetails i)
        {
            if (string.IsNullOrEmpty(i.ImpID) || string.IsNullOrEmpty(i.Supplier) ||
                string.IsNullOrEmpty(i.EmpID) || string.IsNullOrEmpty(i.ProdID) || i.Price <= 0 || 
                i.AmountImp <= 0 || i.DateImp == DateTime.MinValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private DTO_Productions GetPro(string proID)
        {
            List<DTO_Productions> pros = proDll.LoadProducts();
            
            foreach (DTO_Productions p in pros)
            {
                if(p.ProdID == proID)
                {
                    DTO_Productions result = p;
                    return result;
                }
            }
            return null;
        }

        private DTO_ImportDetails GetImportDetail(string impID, string proID)
        {
            List<DTO_ImportDetails> imps = this.LoadImportDetails();

            foreach (DTO_ImportDetails i in imps)
            {
                if (i.ProdID == proID && i.ImpID == impID)
                {
                    DTO_ImportDetails result = i;
                    return result;
                }
            }
            return null;
        }

        public bool InsertImportDetails(DTO_ImportDetails i)
        {
            
            if (CheckData(i))
            {
                try
                {
                    DTO_Productions p = GetPro(i.ProdID);
                    p.Amount += i.AmountImp;
                    if (imp.ImportDetails_Insert(i))
                    {
                        return proDll.UpdateProduct(p);

                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        public bool UpdateImportDetails(DTO_ImportDetails i)
        {
            if (CheckData(i))
            {
                try
                {
                    DTO_Productions p;
                    DTO_ImportDetails befor = GetImportDetail(i.ImpID, i.ProdID);
                    if (imp.ImportDetails_Update(i))
                    {
                        p = GetPro(i.ProdID);
                        int temp = (i.AmountImp - befor.AmountImp);
                        p.Amount += temp;

                        return proDll.UpdateProduct(p);

                    }
                    else return false;

                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        public bool DeletetImportDetails(DTO_ImportDetails i)
        {
            if (CheckData(i))
            {
                try
                {
                    DTO_Productions p = GetPro(i.ProdID);
                    DTO_ImportDetails befor = GetImportDetail(i.ImpID, i.ProdID);

                    p.Amount -= befor.AmountImp;
                    return imp.ImportDetails_Delete(i) && proDll.UpdateProduct(p);
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        public bool DeletetImport(string ImpID)
        {
            List<DTO_ImportDetails> list = imp.ImportDetails_LoadData();
            try
            {
                foreach (DTO_ImportDetails item in list)
                {
                    if (item.ImpID == ImpID) DeletetImportDetails(item);
                }
                return true;
            }
            catch { return false; }
        }
        public List<DTO_ImportDetails> LoadImportDetails()
        {
            return imp.ImportDetails_LoadData();
        }

        public long TotalCost(string ImpID)
        {
            long resutl = 0;
            List<DTO_ImportDetails> list = LoadImportDetails();
            foreach(DTO_ImportDetails item in list)
            {
                if (item.ImpID == ImpID) resutl += item.Price * item.AmountImp;
            }
            return resutl;  
        }
    }
}
