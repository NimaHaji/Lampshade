using Microsoft.Extensions.DependencyInjection;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Application.CustomerDiscounts;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
namespace DiscountManagement.Infrastructure.Configuration
{
    public class DiscountManagementBootStraper
    {
        public static void Configure(IServiceCollection services,string Connection){
            services.AddTransient<ICustomerDiscountApplication,CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountRepository,CustomerDiscountRepository>();

            services.AddDbContext<DiscountContext>(x=>x.UseSqlServer(Connection));
        }
    }
}

