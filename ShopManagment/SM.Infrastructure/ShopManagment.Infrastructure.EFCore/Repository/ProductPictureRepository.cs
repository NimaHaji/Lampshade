using System.Collections.Generic;
using System.Linq;
using _0_Freamwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagment.Domain;

namespace ShopManagment.Infrastructure.EFCore
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.productPictures.Select(x=>new EditProductPicture{
                Id=x.Id,
                Picture=x.Picture,
                PictureTitle=x.PictureTitle,
                PictureAlt=x.PictureAlt,
                ProductId=x.ProductId,
                
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query=_context.productPictures.Include(x=>x.Product).Select(x=>new ProductPictureViewModel{
                Id=x.Id,
                Product=x.Product.Name,
                CreationDate=x.CreationDate.ToString(),
                Picture=x.Picture,
                ProductId=x.ProductId,
                IsRemoved=x.IsRemoved
            });

            if(searchModel.ProductId!=0)
            query=query.Where(x=>x.ProductId==searchModel.ProductId);

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
 
