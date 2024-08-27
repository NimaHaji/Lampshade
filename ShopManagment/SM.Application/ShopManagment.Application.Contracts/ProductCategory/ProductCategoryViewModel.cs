using System;

namespace ShopManagment.Application.Contracts.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public long ProductsCount { get; set; }
    }
}
