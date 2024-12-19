using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framwork.Application;

namespace InventoryManagement.Application.contracts
{
    internal interface IInentoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Decrease(List<DecreaseInventory> command);
        EditInventory GetDeatils(long id);
        List<InventoryViewModel> Search(IncventorySearchModel searchModel);
    }
}
