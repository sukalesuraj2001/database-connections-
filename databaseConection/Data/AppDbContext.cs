using databaseConection.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace databaseConection.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext( DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }


        public DbSet<User> Users { get; set;  }


    }
}
