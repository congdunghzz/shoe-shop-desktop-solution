using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace WarehouseDll
{
    public class Warehouse_Dll
    {
        private DAL_WarehouseAccess ware;
         
        public Warehouse_Dll()
        {
            ware = new DAL_WarehouseAccess();

        }

        public bool CheckData(DTO_Warehouse ware)
        {
            if (string.IsNullOrEmpty(ware.WareID) || string.IsNullOrEmpty(ware.ProdID))
                
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool InsertWarehouse(DTO_Warehouse w)
        {
            if (CheckData(w))
            {
                try
                {
                    return ware.Ware_Insert(w);
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        public bool UpdateWarehouse(DTO_Warehouse w)
        {
            if (CheckData(w))
            {
                try
                {
                    return ware.Ware_Update(w);

                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        public bool DeleteWarehouse(DTO_Warehouse w)
        {
            if (CheckData(w))
            { 
                try
                {
                    return ware.Ware_Delete(w);
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        public List<DTO_Warehouse> LoadWarehouse()
        {
            return ware.Ware_LoadData();
        }
    }
}
