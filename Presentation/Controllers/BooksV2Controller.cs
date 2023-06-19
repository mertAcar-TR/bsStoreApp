using System;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
	
	//[ApiVersion("2.0",Deprecated =true)] yayından kaldıracağımız bilgisini verdik.Extensiom method conversion bölümünü yazdığımız için kaldırdık
	[ApiController]
    //[Route("api/{v:apiversion}/books")] url ile versiyonlama
    [Route("api/books")]
	[ApiExplorerSettings(GroupName ="v2")] //versiyon v2 ye göre grupladık(swagger için)
    public class BooksV2Controller:ControllerBase
	{
		private readonly IServiceManager _manager;

        public BooksV2Controller(IServiceManager manager)
        {
            _manager = manager;
        }

		[HttpGet]
		public async Task<IActionResult> GetAllBooksAsync()
		{
			var books = await _manager.BookService.GetAllBooksAsync(false);
			var booksV2 = books.Select(b=> new
			{
				Title=b.Title,
				Id=b.Id
			});
			return Ok(booksV2);
		}
    }
}

//Api tarafında güncellmeye ihtiyaç duyulduğunda kullanıcılar daha yumuşak geçişler yapsın diye versiyonlama yapılır.
