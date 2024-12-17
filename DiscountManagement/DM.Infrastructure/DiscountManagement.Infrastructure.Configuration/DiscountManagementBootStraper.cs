using Microsoft.Extensions.DependencyInjection;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Application;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
namespace DiscountManagement.Infrastructure.Configuration
{
    public class DiscountManagementBootStraper
    {
        public static void Configure(IServiceCollection services,string ConnectionString){
            services.AddTransient<ICustomerDiscountApplication,CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountRepository,CustomerDiscountRepository>();
            
            services.AddTransient<IColleagueDiscountApplication,ColleagueDiscountApplication>();
            services.AddTransient<IColleagueDiscountRepository,ColleagueDiscountRepository>();
            
            services.AddDbContext<DiscountContext>(x=>x.UseSqlServer(ConnectionString));
        }
    }
}

