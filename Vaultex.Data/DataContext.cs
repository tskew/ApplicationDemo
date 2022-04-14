using Microsoft.EntityFrameworkCore;
using Vaultex.Entities;

namespace Vaultex.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
