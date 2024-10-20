using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagment.Domain;

namespace ServiceHost.Areas.Adminstration.Pages.shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public bool isInStock;
        public ProductPictureSearchModel SearchModel;
        public List<ProductPictureViewModel> ProductPictures;
        public SelectList Products;
        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _ProductPictureApplication;
        private readonly IProductPictureRepository _ProductPictureRepository;

        public IndexModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication, IProductPictureRepository productPictureRepository)
        {
            _productApplication = productApplication;
            _ProductPictureApplication = productPictureApplication;
            _ProductPictureRepository = productPictureRepository;
        }




        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ProductPictures = _ProductPictureApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture()
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = _ProductPictureApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var Product = _ProductPictureApplication.GetDetails(id);
            Product.Products = _productApplication.GetProducts(); 
            return Partial("Edit", Product);
        }
        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var result = _ProductPictureApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            var result = _ProductPictureApplication.Remove(id);
            isInStock = _ProductPictureRepository.Get(id).IsRemoved;
            if (result.IsSuccedded)
            {
                Message = $"محصول {_ProductPictureRepository.Get(id).PictureTitle} ناموجود شد .";
                return RedirectToPage("./Index");
            }
            else
            {
                Message = result.Message;
                return RedirectToPage("./Index");
            }
        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _ProductPictureApplication.Restore(id);
            isInStock = _ProductPictureRepository.Get(id).IsRemoved;
            if (result.IsSuccedded)
            {
                Message = $"محصول {_ProductPictureRepository.Get(id).PictureTitle} موجود شد .";
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
