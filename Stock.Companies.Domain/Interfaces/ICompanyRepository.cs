using System.Threading.Tasks;
using Stock.Companies.Domain.Entities;

namespace Stock.Companies.Domain.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        /// <summary>
        /// Retrieve Entity by ISIN
        /// </summary>
        /// <param name="ISIN"></param>
        /// <returns></returns>
        Task<Company> GetByISIN(string ISIN);
    }
}