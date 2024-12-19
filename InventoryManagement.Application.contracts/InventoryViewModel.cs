﻿namespace InventoryManagement.Application.contracts
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string Prodct { get; set; }
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }
        public bool IsInStock { get; set; }
        public long CurrentCount { get; set; }
    }
}
