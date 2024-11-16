using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framwork.Application;
using ShopManagment.Application.Contracts.ProductCategory;

namespace ShopManagment.Application.Contracts.Product
{

    public class CreateProduct
{
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string Name { get; set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string Code { get; set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public double UnitPrice { get; set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string Slug { get; set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string Keywords { get; set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string MetaDescription { get; set; }
    [Range(1,1000,ErrorMessage =ValidationMessages.IsRequired)]
    public long CategoryId { get; set; }
    public List<ProductCategoryViewModel> Categories { get; set; }
}

}
