using System.Collections.Generic;
using ShopManagment.Application.Contracts.Product;

namespace InventoryManagement.Application.contracts
{
    public class CreateInventory
    {
        public long ProductId { get; set; }
        public double Price { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
