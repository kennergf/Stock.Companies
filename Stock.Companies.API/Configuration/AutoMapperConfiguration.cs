using AutoMapper;
using Stock.Companies.API.ViewModels;
using Stock.Companies.Domain.Entities;

namespace Stock.Companies.API.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Company, CompanyViewModel>().ReverseMap();
        }
    }
}