using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Stock.Companies.Data.Context;

namespace Stock.Companies.Data.ContextFactory
{
    /// <summary>
    /// The Context Factory will configure our context with the connection string to be user in the Migration for example.
    /// The string connection should not be stored within the code, UserSecret or other credential Vault should be used here
    /// </summary>
    public class MSSQLContextFactory : IDesignTimeDbContextFactory<MSSQLContext>
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        public MSSQLContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MSSQLContext>();
            builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            return new MSSQLContext(builder.Options);
        }
    }
}