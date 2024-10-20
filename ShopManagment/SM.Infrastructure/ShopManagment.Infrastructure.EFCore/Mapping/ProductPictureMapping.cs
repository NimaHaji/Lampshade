using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain;

namespace ShopManagment.Infrastructure.EFCore
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPicture");
            builder.HasKey(p => p.Id);

            builder.Property(p=>p.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(p=>p.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(p=>p.PictureAlt).HasMaxLength(500).IsRequired();

            builder.HasOne(x=>x.Product).WithMany(x=>x.ProductPictures).HasForeignKey(x=>x.ProductId);
        }
    }
}


