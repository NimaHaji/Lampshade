namespace InventoryManagement.Application.contracts
{
    public class ReduceInventory
    {
        public long InventoryId { get; set; }
        public long ProductId { get; set; }
        public long Count { get; set; }
        public long OrderId { get; set; }
        public string Description { get; set; }
    }
}
