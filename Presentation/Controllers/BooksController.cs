﻿using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
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
            public IActionResult GetAllBooks()
            {
                var books = _manager.BookService.GetAllBooks(false);

                return Ok(books);
            }
            [HttpGet("{id:int}")]
            public IActionResult GetBook([FromRoute(Name = "id")] int id)
            {
            
                var book = _manager.BookService.GetOneBookById(id, false);
               
                
                    return Ok(book);
                
           
            }
            //[HttpPost]
            //public IActionResult GetAllBooks([FromBody] Book book)
            //{
            //    _logger.LogWarning("Book has been created!");
            //    return StatusCode(201);//created
            //}
            [HttpPost]
            public IActionResult CreateOneBook([FromBody] BookDtoForInsertion bookDto)
            {
                
                    if (bookDto is null)
                    {
                        return BadRequest();//400
                    }
                    if (!ModelState.IsValid)
                    {
                        return UnprocessableEntity(ModelState);
                    }
                    _manager.BookService.CreateOneBook(bookDto);

                    return StatusCode(201, bookDto);//CreatedAtRoute() metodu ile ekleme yaparsak Response'un header'ına bir location bilgisi koyabiliriz.
                
            }
            [HttpPut("{id:int}")]
            public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
            {
                if (bookDto is null)
                    return BadRequest();
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
            _manager.BookService.UpdateOneBook(id, bookDto, false);

                return NoContent();
            }

            [HttpDelete("{id:int}")]
            public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
            {
                _manager.BookService.DeleteOneBook(id, false);
                return NoContent();
            }
            [HttpPatch("{id:int}")]
            public IActionResult PatchBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
            {
                if (bookPatch is null)
                {
                return BadRequest();
                }
                var result = _manager.BookService.GetOneBookForPatch(id, false);
               
                bookPatch.ApplyTo(result.bookDtoForUpdate,ModelState);
                TryValidateModel(result.bookDtoForUpdate);
                if (!ModelState.IsValid)
                 {
                     return UnprocessableEntity(ModelState);
                 }
                _manager.BookService.SaveChangesForPatch(result.bookDtoForUpdate,result.book);
                return NoContent();
            }
        }
    }

