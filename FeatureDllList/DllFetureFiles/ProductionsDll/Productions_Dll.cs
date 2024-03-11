using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

namespace ProductionsDll
{ 

    

    public class Productions_Dll 

    {
        private DAL_ProductionAccess pro;
        

        public Productions_Dll()
        {
            pro = new DAL_ProductionAccess();


        }

        public bool CheckData(DTO_Productions productions)
        {
            if (string.IsNullOrEmpty(productions.ProdID) || string.IsNullOrEmpty(productions.ProdName) || productions.Price <= 0 || string.IsNullOrEmpty(productions.Material) || (productions.Discount < 0 || productions.Discount >1) || productions.Amount < 0)
            {
                return false; 
            }
            else
            {
                return true; 
            }
        }

        public bool AddProduct(DTO_Productions production)
        {
            if (CheckData(production))
            {
                try
                {
                    
                    return pro.Pro_Insert(production);
                }
                catch
                {
                    return false;
                }
            }else { return false; }
            
        }

        public bool UpdateProduct(DTO_Productions production)
        {
            if (CheckData(production))
            {
                try
                {
                    
                    return pro.Pro_Update(production);
                }
                catch
                {
                    return false;
                }
            }
            else return false;
           
        }

        public bool DeleteProduct(DTO_Productions production)
        {
            try
            {
                
                return pro.Pro_Delete(production);
            }
            catch
            {
                return false;
            }
        }

        public List<DTO_Productions> LoadProducts()
        {
            
            List<DTO_Productions> result = pro.Pro_LoadData();
            
            
            return result;
        }


    }
}

