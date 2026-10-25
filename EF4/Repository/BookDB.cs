using EF4.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EF4.Repository
{
    public class BookDB : DbContext
    {
        public BookDB(DbContextOptions<BookDB> options) : base(options)
        {

        }

        public DbSet<Books> BookTable { get; set; }

    }
}
