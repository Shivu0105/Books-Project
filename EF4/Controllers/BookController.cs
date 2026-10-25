using EF4.Model;
using EF4.Repository;
using EF4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController(BookService book)
        {
            _bookService = book;
        }

        [HttpGet]
        public async Task<IActionResult> getBooks()
        {
            try
            {
                var bookData = await _bookService.GetBooksAsync();
                return Ok(bookData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Books entity)
        {
            try 
            {
                 var result  = await _bookService.AddBook(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBook(int Id)
        {
            try
            {
                var result = await _bookService.DeleteBook(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateBooks(int Id, [FromBody] Books entity)
        {
            try
            {
                var result = await _bookService.UpdateBook(Id, entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
