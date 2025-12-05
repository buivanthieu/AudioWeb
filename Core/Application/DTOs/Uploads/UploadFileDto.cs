using System.ComponentModel.DataAnnotations;

namespace AudioWeb.Core.Application.DTOs.Uploads
{
    public class UploadFileDto
    {
        [Required]
        public IFormFile File { get; set; } = null!;
    }
}
