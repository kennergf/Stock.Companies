using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock.Companies.Data.Context;
using Stock.Companies.Domain.Entities;
using Stock.Companies.Domain.Interfaces;

namespace Stock.Companies.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(MSSQLContext db) : base(db)
        {
        }

        public async Task<Company> GetByISIN(string ISIN)
        {
            return await _db.Company.FirstOrDefaultAsync(c => c.ISIN == ISIN);
        }
    }
}