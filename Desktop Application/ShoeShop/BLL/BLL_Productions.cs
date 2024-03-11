using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using ProductionsDll;
using System.Runtime.Remoting.Channels.Tcp;

namespace BLL
{




    public class BLL_Productions : MarshalByRefObject, IBLL_Productions
    {
        Productions_Dll pro = new Productions_Dll();

        public BLL_Productions()
        {
         

        }
        public bool AddProduct(DTO_Productions production)
        {
            return pro.AddProduct(production);
        }
        public bool UpdateProduct(DTO_Productions production)
        {
            return pro.UpdateProduct(production);
        }
        public bool DeleteProduct(DTO_Productions production)
        {
            return pro.DeleteProduct(production);
        }
        public List<DTO_Productions> LoadProduct()
        {
            return pro.LoadProducts();
        }
    }
}
