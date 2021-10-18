using System;
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
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(INotifier notifier, ICompanyRepository companyRepository, ICompanyService companyService,
                                 IMapper mapper) : base(notifier)
        {
            _companyRepository = companyRepository;
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<CompanyViewModel>> GetById([FromQuery] string id)
        {
            var result = _mapper.Map<CompanyViewModel>(await _companyRepository.GetById(Guid.Parse(id)));
            return CustomResponse(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<CompanyViewModel>> GetByISIN([FromQuery] string isin)
        {
            var result = _mapper.Map<CompanyViewModel>(await _companyRepository.GetByISIN(isin));
            return CustomResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyViewModel>> Add([FromBody] CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _companyService.Add(_mapper.Map<Company>(companyViewModel));
            // TODO return something more meaningful
            return CustomResponse(companyViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyViewModel>>> GetAll()
        {
            var result = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());
            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult<CompanyViewModel>> Update(Guid id, [FromBody] CompanyViewModel companyViewModel)
        {
            if (id != companyViewModel.Id)
            {
                NotifyErro("The Id provided is not the same infomed on the Company");
                return CustomResponse(companyViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _companyService.Update(id, _mapper.Map<Company>(companyViewModel));
            return CustomResponse(companyViewModel);
        }

    }
}