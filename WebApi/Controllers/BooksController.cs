using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepositoryManager _manager;

        public BooksController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _manager.Book.GetAllBooks(false);
           
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetBook([FromRoute(Name = "id")] int id)
        {
            var book = _manager.Book.GetOneBookById(id, false);
            if (book is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
        }
        //[HttpPost]
        //public IActionResult GetAllBooks([FromBody] Book book)
        //{
        //    _logger.LogWarning("Book has been created!");
        //    return StatusCode(201);//created
        //}
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                {
                    return BadRequest();//400
                }
                _manager.Book.CreateOneBook(book);
                _manager.Save();
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            var entity = _manager.Book.GetOneBookById(id, true);
            if (entity is null)
                return NotFound();//404
            if (id != book.Id)
                return BadRequest();//400
            entity.Title = book.Title;
            entity.Price = book.Price;
            _manager.Save();

            return Ok(book);
        }
       
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
        {
            var book = _manager.Book.GetOneBookById(id, false);
            if (book is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = $"Book with id:{id} could not found"
                });//404
            }
            _manager.Book.DeleteOneBook(book);
            _manager.Save();
            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public IActionResult PatchBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var book = _manager.Book.GetOneBookById(id, true);
            if (book is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = $"Book with id:{id} could not found"
                });//404
            }
            bookPatch.ApplyTo(book);
            _manager.Book.Update(book);
            _manager.Save();
            return NoContent();
        }
    }
}
