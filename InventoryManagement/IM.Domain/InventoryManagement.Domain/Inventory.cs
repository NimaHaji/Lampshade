﻿using _0_Framwork.Domain;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Domain
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }
        public Inventory(long productId, double price)
        {
            ProductId = productId;
            UnitPrice = price;
            InStock = false;
        }
        public Inventory()
        {
            
        }
        public void Edit(long productId, double price)
        {
            ProductId = productId;
            UnitPrice = price;
        }
        public long CalculateCurrentInventoryStock()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }
        public void Increase(long count, long operatorId, string Description)
        {
            var currentCount = CalculateCurrentInventoryStock() + count;
            var operation = new InventoryOperation(true, count, operatorId, currentCount, Description, 0, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
        public void Reduce(long count, long operatorId, string description, long orderId)
        {
            var currentCount = CalculateCurrentInventoryStock() - count;
            var operation = new InventoryOperation(false, count, operatorId, currentCount, description, orderId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
        public class InventoryOperation
        {
            public long Id { get; private set; }
            public bool Operation { get; private set; }
            public long Count { get; private set; }
            public long OperatorId { get; private set; }
            public DateTime OperationDate { get; private set; }
            public long CurrentCount { get; private set; }
            public string Description { get; private set; }
            public long OrderId { get; private set; }
            public long InventoryId { get; private set; }
            public Inventory Inventory { get; private set; }

            public InventoryOperation(bool operation, long count, long operatorId, long currentCount, string description, long orderId, long inventoryId)
            {
                this.Operation = operation;
                this.Count = count;
                this.OperatorId = operatorId;
                this.CurrentCount = currentCount;
                this.Description = description;
                this.OrderId = orderId;
                this.InventoryId = inventoryId;
                this.OperationDate = DateTime.Now;
            }
        }
    }
}


