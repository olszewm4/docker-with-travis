using Db_Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace Db_Service
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
    }
}
