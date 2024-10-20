using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Domain;

namespace ServiceHost.Areas.Adminstration.Pages.shop.Product
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public bool isInStock;
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly IProductRepository _productRepository;
        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication, IProductRepository productRepository)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
            _productRepository = productRepository;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Products = _productApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct()
            {
                Categories = _productCategoryApplication.GetProductCategories()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var Product = _productApplication.GetDetails(id);
            Product.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("Edit", Product);
        }
        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetNotInStock(long id)
        {
            var result = _productApplication.NotInStock(id);
            isInStock = _productRepository.Get(id).IsInStock;
            if (result.IsSuccedded)
            {
                Message = $"محصول {_productRepository.Get(id).Name} ناموجود شد .";
                return RedirectToPage("./Index");
            }
            else
            {
                Message = result.Message;
                return RedirectToPage("./Index");
            }
        }
        public IActionResult OnGetInStock(long id)
        {
            var result = _productApplication.InStock(id);
            isInStock = _productRepository.Get(id).IsInStock;
            if (result.IsSuccedded)
            {
                Message = $"محصول {_productRepository.Get(id).Name} موجود شد .";
                return RedirectToPage("./Index");
            }
            else
            {
                Message = result.Message;
                return RedirectToPage("./Index");
            }
        }
    }
}
