using System;
using System.Threading.Tasks;
using Stock.Companies.Domain.Entities;

namespace Stock.Companies.Domain.Interfaces
{
    public interface ICompanyService : IDisposable
    {
        Task<bool> Add(Company company);

        Task<Company> Update(Guid id, Company company);
    }
}