﻿using _0_Framework.Application;
using _0_Framwork.Infrastructure;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Domain.ProductCategoryAgg;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopManagment.Infrastructure.EFCore.Repository
{

    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }
        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(c => new EditProductCategory
            {
                Id = c.Id,
                Description = c.Description,
                Name = c.Name,
                Keywords = c.Keywords,
                MetaDescription = c.MetaDescription,
                // Picture = c.Picture,
                PictureTitle = c.PictureTitle,
                PictureAlt = c.PictureAlt,
                Slug = c.Slug
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel model)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name=x.Name,
                Picture=x.Picture,
                CreationDate=x.CreationDate.ToFarsi()
            });
            if (!string.IsNullOrWhiteSpace(model.Name))
                query = query.Where(x => x.Name.Contains(model.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public string GetCategoryWithSlugBy(long id)
        {
            return _context.ProductCategories.Include(x=>x.Products).Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == x.Id).Slug;
        }
        
    }
}
