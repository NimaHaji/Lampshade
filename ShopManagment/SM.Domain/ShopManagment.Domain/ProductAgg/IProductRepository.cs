using System.Collections.Generic;
using _0_Freamwork.Domain;
using ShopManagment.Application.Contracts.Product;
namespace ShopManagment.Domain
{
    public interface IProductRepository : IRepository<long, Product>
    {
        EditProduct GetDetails(long id);
        Product GetProductWithCategory(long id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}

