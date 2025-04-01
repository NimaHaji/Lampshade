using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using _0_Framwork.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _0_Freamwork.Application
{
    public class FileFormatAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _formats;

        public FileFormatAttribute(string[] formats)
        {
            _formats = formats;
            ErrorMessage =ValidationMessages.FileFormat;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) return true;
            
            var fileExtension = Path.GetExtension(file.FileName);
            
            return _formats.Contains(fileExtension);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-FileFormat",ErrorMessage);
            if (_formats != null && _formats.Any())
            {
                context.Attributes.Add("data-val-formats", string.Join(",", _formats.Select(f => f.ToLower())));
            }
        }

    }
}