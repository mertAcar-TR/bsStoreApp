using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        //Günümüzde bulut teknolojileri kullanılır,dosyalar oraya kaydedilir.

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media");
            if (!Directory.Exists(folder)) { Directory.CreateDirectory(folder); }

            var path = Path.Combine(folder, file?.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new
            {
                file=file.FileName,
                path=path,
                size=file.Length
            });
        }
    }
}

