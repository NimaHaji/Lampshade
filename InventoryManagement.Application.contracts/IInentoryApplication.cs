using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framwork.Application;

namespace InventoryManagement.Application.contracts
{
    public interface IInentoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Reduse(List<ReduceInventory> command);
        OperationResult Reduse(ReduceInventory command);
        EditInventory GetDeatils(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long InventoryId);
    }
}
