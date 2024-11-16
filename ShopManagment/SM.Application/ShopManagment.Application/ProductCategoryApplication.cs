using ShopManagment.Application.Contracts.ProductCategory;
using System.Collections.Generic;
using ShopManagment.Domain.ProductCategoryAgg;
using _0_Framwork.Application;
using _0_Framwork;
using _0_Framework.Application;


namespace ShopManagment.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var OperationResult = new OperationResult();
            if (productCategoryRepository.IsExist(x => x.Name == command.Name))
                return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var ProductCategory = new ProductCategory(command.Name, command.Description, command.Picture,
            command.PictureAlt, command.PictureTitle,
            command.Keywords, command.MetaDescription, slug);

            productCategoryRepository.Create(ProductCategory);
            productCategoryRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        

        public OperationResult Edit(EditProductCategory command)
        {
            var OperationResult = new OperationResult();
            var productCategory = productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                return OperationResult.Failed(ApplicationMessages.RecordNotFound);

            if (productCategoryRepository.IsExist(x => x.Name == command.Name && x.Id != command.Id))
                return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            productCategory.Edit(command.Name, command.Description, command.Picture, command.PictureAlt,
            command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            productCategoryRepository.SaveChanges();
            return OperationResult.Succedded();
        }

     

        public EditProductCategory GetDetails(long id)
        {
            return productCategoryRepository.GetDetails(id);
        }
        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel model)
        {
            return productCategoryRepository.Search(model);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return productCategoryRepository.GetProductCategories();
        }
    }
}
