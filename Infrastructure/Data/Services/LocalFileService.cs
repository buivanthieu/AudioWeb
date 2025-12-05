using AudioWeb.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace AudioWeb.Infrastructure.Data.Services
{
    public class LocalFileService : IFileService
    {
        private readonly string _basePath;
        private readonly string _baseUrl;
        private readonly IWebHostEnvironment _env;

        public LocalFileService(IConfiguration configuration, IWebHostEnvironment env)
        {
        
            _basePath = configuration["LocalFileStorage:BasePath"] ?? "wwwroot/uploads";
            _baseUrl = configuration["LocalFileStorage:BaseUrl"] ?? "https://localhost:7138/uploads";
            _env = env;

       
            var rootPath = Path.Combine(_env.ContentRootPath, _basePath);
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty or null.");
            }

            var uploadFolder = Path.Combine(_basePath, folder);
            var absoluteFolder = Path.Combine(_env.ContentRootPath, uploadFolder);

            if (!Directory.Exists(absoluteFolder))
            {
                Directory.CreateDirectory(absoluteFolder);
            }


            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var absoluteFilePath = Path.Combine(absoluteFolder, fileName);

            using (var stream = new FileStream(absoluteFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUrl = $"{_baseUrl.TrimEnd('/')}/{folder.Trim('/')}/{fileName}";
            return fileUrl;
        }

        public Task<bool> DeleteFileAsync(string fileUrl)
        {
            
            //return Task.FromResult(true);
            throw new NotImplementedException();
        }
    }
}