using _01_LampShadeQuery.Contracts.ProductCategory;
using ShopManagment.Infrastructure.EFCore;

namespace _01_LampShadeQuery
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x=>new ProductCategoryQueryModel{
                Name=x.Name,
                Id=x.Id,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Slug=x.Slug    
            }).ToList();
        }
    }

}

