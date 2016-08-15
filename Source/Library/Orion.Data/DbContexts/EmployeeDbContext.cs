using System.Data.Entity;
using Orion.Data.Entities;

namespace Orion.Data.DbContexts
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("Orion.Data") {}

        public DbSet<Employee> Employees { get; set; }
    }
}
