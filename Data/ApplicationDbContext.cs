using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<States> States { get; set; }
    }
}
