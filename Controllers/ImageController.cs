using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeakerManagerApi.Data;
using SpeakerManagerApi.Models;

namespace SpeakerManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("logo")]
        public async Task<IActionResult> UploadLogo(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var image = await SaveImageToDatabase(file);

            var logo = new Logo
            {
                ImageId = image.Id,
                CreatedAt = DateTime.UtcNow
            };

            _context.Logos.Add(logo);
            await _context.SaveChangesAsync();

            return Ok(new { LogoId = logo.Id, ImageId = image.Id });
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var image = await SaveImageToDatabase(file);

            return Ok(new { ImageId = image.Id });
        }

        private async Task<Image> SaveImageToDatabase(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var image = new Image
            {
                FileName = file.FileName,
                ImageData = memoryStream.ToArray()
            };

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return image;
        }
    }
}