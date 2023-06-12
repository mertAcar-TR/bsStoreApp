using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //[ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/books")]
    public class BooksController:ControllerBase
    {
        
            private readonly IServiceManager _manager;

            public BooksController(IServiceManager manager)
            {
                _manager = manager;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookParameters bookParameters)
            {
                var pagedResult = await _manager.BookService.GetAllBooksAsync(bookParameters,false);
                Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(pagedResult.metaData));
                return Ok(pagedResult.books);
            }
            [HttpGet("{id:int}")]
            public async Task<IActionResult> GetBookAsync([FromRoute(Name = "id")] int id)
            {
            
                var book = await _manager.BookService.GetOneBookByIdAsync(id, false);
               
                
                    return Ok(book);
                
           
            }
            //[HttpPost]
            //public IActionResult GetAllBooks([FromBody] Book book)
            //{
            //    _logger.LogWarning("Book has been created!");
            //    return StatusCode(201);//created
            //}

            [ServiceFilter(typeof(ValidationFilterAttribute))]//typeof'dan sonra virgül koyup Order property'si ile sıralama yapabiliriz.
            [HttpPost]
            public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
            {
             
                    await _manager.BookService.CreateOneBookAsync(bookDto);

                    return StatusCode(201, bookDto);//CreatedAtRoute() metodu ile ekleme yaparsak Response'un header'ına bir location bilgisi koyabiliriz.
                
            }
            [ServiceFilter(typeof(ValidationFilterAttribute))]
            [HttpPut("{id:int}")]
            public async Task<IActionResult> UpdateBookAsync([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
            {
                if (bookDto is null)
                    return BadRequest();
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
           await  _manager.BookService.UpdateOneBookAsync(id, bookDto, false);

                return NoContent();
            }

            [HttpDelete("{id:int}")]
            public async Task<IActionResult> DeleteBookAsync([FromRoute(Name = "id")] int id)
            {
                await _manager.BookService.DeleteOneBookAsync(id, false);
                return NoContent();
            }
            [HttpPatch("{id:int}")]
            public async Task<IActionResult> PatchBookAsync([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
            {
                if (bookPatch is null)
                {
                return BadRequest();
                }
                var result = await _manager.BookService.GetOneBookForPatchAsync(id, false);
               
                bookPatch.ApplyTo(result.bookDtoForUpdate,ModelState);
                TryValidateModel(result.bookDtoForUpdate);
                if (!ModelState.IsValid)
                 {
                     return UnprocessableEntity(ModelState);
                 }
                await _manager.BookService.SaveChangesForPatchAsync(result.bookDtoForUpdate,result.book);
                return NoContent();
            }
        }
    }

