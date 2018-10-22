using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Persistance
{
    public class CRUDeliciousDbContext: DbContext
    {
        public DbSet<Dish> Dishes { get; set; } 

        public CRUDeliciousDbContext(DbContextOptions<CRUDeliciousDbContext> options)
            : base(options)
        {
            
        }
    }
}