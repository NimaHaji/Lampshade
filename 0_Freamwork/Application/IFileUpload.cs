using Microsoft.AspNetCore.Http;

namespace _0_Freamwork.Application
{
public interface IFileUpload
{
    string Upload(IFormFile file,string path);
}

}

