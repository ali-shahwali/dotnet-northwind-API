using dotnet_northwind_API.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_northwind_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
