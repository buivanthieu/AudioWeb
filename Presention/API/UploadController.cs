using AudioWeb.Core.Application.DTOs.Uploads;
using AudioWeb.Core.Domain.Interfaces;
using AudioWeb.Shared.DTOs;
using AudioWeb.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioWeb.Presention.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IFileService _fileService;

        public UploadController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("track-audio")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<BaseResponse<string>>> UploadTrackAudio([FromForm] UploadFileDto model)
        {
            try
            {
                var fileUrl = await _fileService.SaveFileAsync(model.File, "tracks");
                return this.SuccessResponse(fileUrl, "Audio uploaded successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<string>(ex.Message);
            }
        }

        [HttpPost("image")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<BaseResponse<string>>> UploadImage([FromForm] UploadFileDto model)
        {
            try
            {
                var fileUrl = await _fileService.SaveFileAsync(model.File, "images");
                return this.SuccessResponse(fileUrl, "Image uploaded successfully.");
            }
            catch (Exception ex)
            {
                return this.BadRequestResponse<string>(ex.Message);
            }
        }
    }
}