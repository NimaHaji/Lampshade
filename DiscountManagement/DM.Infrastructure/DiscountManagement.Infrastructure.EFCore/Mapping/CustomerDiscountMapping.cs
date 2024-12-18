﻿using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.EFCore.Mapping
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.ToTable("CustomerDiscount");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.StartDate).IsRequired();
            builder.Property(x=>x.EndDate).IsRequired();
            builder.Property(x=>x.DiscountRate).IsRequired();
            builder.Property(x=>x.ProductId).IsRequired();
            builder.Property(x=>x.Reason).IsRequired().HasMaxLength(500);
        }
    }

}

