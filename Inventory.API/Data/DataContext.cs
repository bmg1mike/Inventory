using Inventory.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        { 
            
        }
    }
}