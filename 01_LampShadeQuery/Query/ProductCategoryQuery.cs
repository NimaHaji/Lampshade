using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain;
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
            return _context.ProductCategories.Select(x => new ProductCategoryQueryModel
            {
                Name = x.Name,
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            return _context.ProductCategories.Include(x => x.Products).ThenInclude(x=>x.Category).Select(x => new ProductCategoryQueryModel
            {
                Name = x.Name,
                Id = x.Id,
                Products = MapProducts(x.Products)
            }).ToList();
        }


        public List<ProductQueryModel> MapProducts(List<Product> products)
        {
            var result=new List<ProductQueryModel>();
            foreach (var product in products) {
                var item = new ProductQueryModel
                {
                    Id = product.Id,
                    Category = product.Category.Name,
                    Name = product.Name,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Slug = product.Slug
                };
                result.Add(item);
            }
            return result;
        }
    }
}


