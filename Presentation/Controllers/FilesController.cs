using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

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
            //folder
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media");
            if (!Directory.Exists(folder)) { Directory.CreateDirectory(folder); }

            //path
            var path = Path.Combine(folder, file?.FileName);

            //stream
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //response body

            return Ok(new
            {
                file=file.FileName,
                path=path,
                size=file.Length
            });
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download(string fileName)
        {
            //filePath
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", fileName);

            //ContentType:(MIME)
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName,out var contentType))
            {
                contentType = "application/octet-stream";//indirilebilmesine olanak sağladık
            }
            //Read(API'lerde tıklandığında download edilir,klasik web'de ise tıklandığında açılması istenir)
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);//binary şeklinde indirilir
            return File(bytes,contentType,Path.GetFileName(filePath));
        }
    }
}

