using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
    }
}