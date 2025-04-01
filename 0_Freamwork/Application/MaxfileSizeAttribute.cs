using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _0_Freamwork.Application;

public class MaxfileSizeAttribute:ValidationAttribute,IClientModelValidator
{
    private readonly int _maxFileSize;

    public MaxfileSizeAttribute(int maxFileSize)
    {
        _maxFileSize = maxFileSize;
    }

    public override bool IsValid(object value)
    {
        var file=value as IFormFile;
        if (file == null) return false;
        return file.Length >= _maxFileSize;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.Add("data-val", "true");
        context.Attributes.Add("data-val-maxfilesize", ErrorMessage);
    }
}