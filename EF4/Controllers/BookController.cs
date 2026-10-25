using EF4.Model;
using EF4.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDB _book;
        public BookController(BookDB book)
        {
            _book = book;
        }

        [HttpGet]
        public async Task<IActionResult> getBooks()
        {
            try
            {
                var bookData = await _book.BookTable.ToListAsync();
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
                    _book.BookTable.Add(entity);
                await _book.SaveChangesAsync();

                return Ok("Book Added Successfully");
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
                var entity = await _book.BookTable.FindAsync(Id);
                if (entity == null)
                {
                    return NotFound("Book not found");
                }

                _book.BookTable.Remove(entity);
                await _book.SaveChangesAsync();

                return Ok("Book Deleted Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooks(int Id, [FromBody] Books entity)
        {
            try
            {
                var existingBook = await _book.BookTable.FindAsync(Id);
                if (existingBook == null)
                {
                    return NotFound("Book not found");
                }
                existingBook.Name = entity.Name;
                existingBook.Price = entity.Price;
                existingBook.Publisher = entity.Publisher;
                existingBook.AuthorId = entity.AuthorId;

                _book.BookTable.Update(existingBook);
                await _book.SaveChangesAsync();
                return Ok("Book Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
