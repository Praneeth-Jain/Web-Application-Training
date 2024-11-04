using Microsoft.EntityFrameworkCore;
using LoginPage.Data.Entity;

namespace LoginPage.Data.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> users { get; set; }
        public DbSet<Customer> customers { get; set; }

        public DbSet<Products> products { get; set; }

    }
}
