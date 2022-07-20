using Alize.Platform.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/Applications/{applicationId}/Assets/{assetId}/[controller]")]
    [ApiController]
    [Authorize]
    public class MediaController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IVideoRepository _videoRepository;

        public MediaController(IImageRepository imageRepository, IVideoRepository videoRepository)
        {
            _imageRepository = imageRepository;
            _videoRepository = videoRepository;
        }

        [HttpPost("Images")]
        public async Task<IActionResult> UploadImage(Guid applicationId, string assetId, IFormFile file)
        {
            if (file.ContentType != "image/jpeg")
                return BadRequest(GetValidationProblem("image/jpeg"));

            using var stream = file.OpenReadStream();

            var hash = await _imageRepository.UploadImageAsync(applicationId, assetId, stream);

            return CreatedAtAction(nameof(GetImage), new { applicationId, assetId }, hash);
        }

        [HttpGet("Images")]
        [Produces("image/jpeg")]
        [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetImage(Guid applicationId, string assetId)
        {
            var stream = await _imageRepository.DownloadImageAsync(applicationId, assetId);

            return File(stream, "image/jpeg");
        }

        [HttpPost("Video")]
        public async Task<IActionResult> UploadVideo(Guid applicationId, string assetId, IFormFile file)
        {
            if (file.ContentType != "video/mp4")
                return BadRequest(GetValidationProblem("video/mp4"));

            using var stream = file.OpenReadStream();

            var hash = await _videoRepository.UploadVideoAsync(applicationId, assetId, stream);

            return CreatedAtAction(nameof(GetVideo), new { applicationId, assetId }, hash);
        }

        [HttpGet("Video")]
        public async Task<IActionResult> GetVideo(Guid applicationId, string assetId)
        {
            var uri = _videoRepository.GetVideoUri(applicationId, assetId);

            return Ok(uri);
        }

        private ValidationProblemDetails GetValidationProblem(string validType)
        {
            var errors = new Dictionary<string, string[]>();
            errors.Add("File", new [] { $"Invalid media type. Only {validType} is supported at the moment" });

            return new ValidationProblemDetails(errors);
        }
    }
}
