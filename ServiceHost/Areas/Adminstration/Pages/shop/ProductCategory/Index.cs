using _0_Framwork.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopManagment.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Adminstration.Pages.shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel;
        public List<ProductCategoryViewModel> ProductCategories;
        private readonly IProductCategoryApplication _productCategoryApplication;
        
        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories= _productCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create",new CreateProductCategory());
        }
        public JsonResult OnPostCreate(CreateProductCategory command){
            var result=_productCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id){
            var productCategory=_productCategoryApplication.GetDetails(id);
            return Partial("Edit",productCategory);
        }
        public IActionResult OnPostEdit(EditProductCategory command){
            
            var result=_productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
