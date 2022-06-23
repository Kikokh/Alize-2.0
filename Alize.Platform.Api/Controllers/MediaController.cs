using Alize.Platform.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/Applications/{applicationId}/[controller]")]
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
        public async Task<IActionResult> UploadImage(Guid applicationId, IFormFile file)
        {
            if (file.ContentType != "image/jpeg")
                return BadRequest(GetValidationProblem("image/jpeg"));

            using var stream = file.OpenReadStream();

            var hash = await _imageRepository.UploadImageAsync(applicationId, stream, file.FileName);

            return CreatedAtAction(nameof(GetImage), new { fileName = file.FileName }, hash);
        }

        [HttpGet("Images")]
        [Produces("image/jpeg")]
        [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetImage(Guid applicationId, string fileName)
        {
            var stream = await _imageRepository.DownloadImageAsync(applicationId, fileName);

            return File(stream, "image/jpeg");
        }

        [HttpPost("Video")]
        public async Task<IActionResult> UploadVideo(Guid applicationId, [FromForm] IFormFile file)
        {
            if (file.ContentType != "video/mp4")
                return BadRequest(GetValidationProblem("video/mp4"));

            using var stream = file.OpenReadStream();

            var hash = await _videoRepository.UploadVideoAsync(applicationId, stream, file.FileName);

            return CreatedAtAction(nameof(GetVideo), new { fileName = file.FileName }, hash);
        }

        [HttpGet("Video")]
        [Produces("video/mp4")]
        [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVideo(Guid applicationId, string fileName)
        {
            var stream = await _videoRepository.DownloadVideoAsync(applicationId, fileName);

            return File(stream, "video/mp4");
        }

        private ValidationProblemDetails GetValidationProblem(string validType)
        {
            var errors = new Dictionary<string, string[]>();
            errors.Add("File", new [] { $"Invalid media type. Only {validType} is supported at the moment" });

            return new ValidationProblemDetails(errors);
        }
    }
}
