using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stock.Companies.API.ViewModels;
using Stock.Companies.Domain.Entities;
using Stock.Companies.Domain.Interfaces;

namespace Stock.Companies.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Companies")]
    public class CompanyController : MainController
    {
        //private readonly ICompanyService _companyService;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(INotifier notifier, ICompanyRepository companyRepository,
                                 IMapper mapper) : base(notifier)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyViewModel>> Add([FromBody] CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _companyRepository.Add(_mapper.Map<Company>(companyViewModel));
            // TODO return something more meaningful
            return CustomResponse(companyViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyViewModel>>> GetAll()
        {
            var result = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());
            return CustomResponse(result);
        }
    }
}