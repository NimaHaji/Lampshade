using ShopManagment.Application.Contracts.ProductCategory;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ShopManagment.Domain.ProductCategoryAgg;
using _0_Framwork.Application;
using _0_Framwork;
using _0_Framework.Application;
using _0_Freamwork.Application;
using ShopManagment.Domain;


namespace ShopManagment.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IFileUpload _fileUpload;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUpload fileUpload)
        {
            this.productCategoryRepository = productCategoryRepository;
            _fileUpload = fileUpload;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var OperationResult = new OperationResult();
            if (productCategoryRepository.IsExist(x => x.Name == command.Name))
                return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var ProductCategory = new ProductCategory(command.Name, command.Description, "",
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

            // if (command.Picture == null || !FileFormatIsValid(command.Picture.FileName))
            //     return OperationResult.Failed(ValidationMessages.FileFormat);
            
            var slug = command.Slug.Slugify();
            var filepath = $"{command.Slug}";
            var filename=_fileUpload.Upload(command.Picture,filepath);
            
            productCategory.Edit(command.Name, command.Description,filename, command.PictureAlt,
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

        public bool FileFormatIsValid(string filename)
        {
            var validForamts=new []{".jpg", ".jpeg", ".png"};
            return validForamts.Contains(Path.GetExtension(filename).ToLower());
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return productCategoryRepository.GetProductCategories();
        }
    }
}
