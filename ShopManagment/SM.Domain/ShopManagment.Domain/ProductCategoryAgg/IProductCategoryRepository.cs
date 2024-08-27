using _0_Freamwork.Domain;
using System;
using System.Collections.Generic;
using ShopManagment.Application.Contracts.ProductCategory;
namespace ShopManagment.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {

        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel model);

    }
}
