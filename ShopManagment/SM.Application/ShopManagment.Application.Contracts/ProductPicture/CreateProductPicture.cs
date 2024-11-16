using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framwork.Application;
using ShopManagment.Application.Contracts.Product;
namespace ShopManagment.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1,1000,ErrorMessage=ValidationMessages.IsRequired)]
        public long ProductId { get; set; }
        [Required(ErrorMessage=ValidationMessages.IsRequired)]
        public string Picture { get; set; }
        [Required(ErrorMessage=ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage=ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}

