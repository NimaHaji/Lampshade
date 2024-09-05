using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Infrastructure.EFCore.Mapping;
using System;

namespace ShopManagment.Infrastructure.EFCore
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
