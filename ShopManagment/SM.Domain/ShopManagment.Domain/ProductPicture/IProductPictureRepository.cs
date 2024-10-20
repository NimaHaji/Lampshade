using System.Collections.Generic;
using _0_Freamwork.Domain;
using ShopManagment.Application.Contracts.ProductPicture;

namespace ShopManagment.Domain
{
    public interface IProductPictureRepository:IRepository<long,ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}


