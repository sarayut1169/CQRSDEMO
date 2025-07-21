using CQRSDEMO.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSDEMO.CQRS
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
