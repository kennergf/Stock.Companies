using System;
using System.Threading.Tasks;
using Stock.Companies.Domain.Entities;
using Stock.Companies.Domain.Interfaces;

namespace Stock.Companies.Domain.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(INotifier notifier, ICompanyRepository companyRepository) : base(notifier)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Add(Company company)
        {
            var existingCompany = await _companyRepository.GetByISIN(company.ISIN);
            if (existingCompany != null && existingCompany?.ISIN == company.ISIN)
            {
                Notify($"Can not insert duplicate ISIN for Company. Duplicate ISIN is ({company.ISIN})");
                return false;
            }
            else
            {
                await _companyRepository.Add(company);
                return true;
            }
        }

        public async Task<Company> Update(Guid id, Company company)
        {
            if(id != company.Id)
            {
                Notify("The Id provided is not the same infomed on the Company");
                return null;
            }
            else
            {
                await _companyRepository.Update(company);
                return company;
            }
        }

        public void Dispose()
        {
            _companyRepository?.Dispose();
        }
    }
}