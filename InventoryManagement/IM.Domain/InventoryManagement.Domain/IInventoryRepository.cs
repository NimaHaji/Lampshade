using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framwork.Domain;
using InventoryManagement.Application.contracts;

namespace InventoryManagement.Domain
{
    internal interface IInventoryRepository:IRepository<long,Inventory>
    {
        EditInventory GetDetail(long id);
        Inventory GetBy(long id);
        List<InventoryViewModel> Search(IncventorySearchModel searchModel);
    }
}
