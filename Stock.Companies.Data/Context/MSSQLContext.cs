using Microsoft.EntityFrameworkCore;
using Stock.Companies.Data.Configuration;
using Stock.Companies.Data.Entities;

namespace Stock.Companies.Data.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) { }

        public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}
