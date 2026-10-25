using EF4.Model;
using EF4.Repository;
using Microsoft.EntityFrameworkCore;

namespace EF4.Services
{
    public class BookService
    {
        private readonly BookDB _book;
        public BookService(BookDB book)
        {
            _book = book;
        }

        public async Task<List<Books>> GetBooksAsync()
        {
            return await _book.BookTable.ToListAsync();
        }

        public async Task<string> AddBook(Books entity)
        {
            try
            {
                _book.BookTable.Add(entity);
                await _book.SaveChangesAsync();
                return "Book Added Successfully";
            }
            catch (Exception ex)
            {
               return $"Error occurred while adding book: {ex.Message}";
            }

        }

        public async Task<string> DeleteBook(int Id)
        {
            try
            {
                var entity = await _book.BookTable.FindAsync(Id);
                if (entity == null)
                {
                    return "Book not found";
                }
                _book.BookTable.Remove(entity);
                await _book.SaveChangesAsync();
                return "Book deleted successfully";
            }
            catch (Exception ex)
            {
                return $"Error occurred while deleting book: {ex.Message}";
            }
        }

        public async  Task<string> UpdateBook(int Id, Books entity)
        {
            try
            {
                var existingBook = await _book.BookTable.FindAsync(Id);
                if (existingBook == null)
                {
                    return "Book not found";
                }
                existingBook.Name = entity.Name;
                existingBook.Price = entity.Price;
                existingBook.Publisher = entity.Publisher;
                existingBook.AuthorId = entity.AuthorId;

                _book.BookTable.Update(existingBook);
                await _book.SaveChangesAsync();
                return "Book Updated Successfully";
            }
            catch (Exception ex)
            {
                return $"Error occurred while updating book: {ex.Message}";
            }
        }

    }
}
