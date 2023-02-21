using Microsoft.EntityFrameworkCore;
using SupportWheelOfFate.Models;

namespace SupportWheelOfFate.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {

        }

        public DbSet<Engineer> Engineers { get; set; }
     
    }
}
