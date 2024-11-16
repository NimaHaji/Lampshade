using System.Collections.Generic;
using _0_Framwork.Application;

namespace ShopManagment.Application.Contracts.Product
{

    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetProducts();
        OperationResult NotInStock(long Id);
        OperationResult InStock(long Id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}