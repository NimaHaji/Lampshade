using _0_Framework.Application;
using _0_Freamwork.Application;

namespace ServiceHost
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileUpload(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string Upload(IFormFile file, string path)
        {
            if (file == null) return " ";

            var DirectoryPath = $"{_hostingEnvironment.WebRootPath}\\ProductPictures\\{path}";

            if (!Directory.Exists(DirectoryPath))
                Directory.CreateDirectory(DirectoryPath);
            var Filename = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{DirectoryPath}\\{Filename}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{Filename}";
        }
    }
}