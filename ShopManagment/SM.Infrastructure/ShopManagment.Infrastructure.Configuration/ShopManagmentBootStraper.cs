using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Application;
using _01_LampShadeQuery.Contracts.Slide;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagment.Application.Contracts.Slide;
using ShopManagment.Domain;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Infrastructure.EFCore;
using ShopManagment.Infrastructure.EFCore.Repository;
using _01_LampShadeQuery.Query;
using _01_LampShadeQuery.Contracts.ProductCategory;
using _01_LampShadeQuery;

namespace ShopManagment.Infrastructure.Configuration
{
    public class ShopManagmentBootStraper
    {
        public static void configure(IServiceCollection services, string ConnectionString)
        {

            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            services.AddTransient<IProductApplication,ProductApplication>();
            services.AddTransient<IProductRepository,ProductRepository>();

            services.AddTransient<IProductPictureApplication,ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository,ProductPictureRepository>();

            services.AddTransient<ISlideApplication,SlideApplication>();
            services.AddTransient<ISlideRepository,SlideRepository>();

            services.AddTransient<ISlideQuery,SlideQuery>();
            services.AddTransient<IProductCategoryQuery,ProductCategoryQuery>();
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(ConnectionString));
        }
    }
}
