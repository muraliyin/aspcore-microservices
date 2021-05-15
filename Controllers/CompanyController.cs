using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspcorewebapis.dtos; 
using aspcorewebapis.Services;
using aspcorewebapis.Models; 
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Http;
namespace aspcorewebapis.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {

        private ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository ??
                throw new ArgumentNullException(nameof(companyRepository));
            _mapper = mapper;
        }
        [HttpPost]
        [Route("getAllCompanies")]
        [ProducesResponseType(typeof(dtos.CompanyViewDto), 200)]
        public async Task<IActionResult> GetAllCompanies()
        {

            var companyEntities = await _companyRepository.GetCompanies();
            if (companyEntities == null)
            {
                return NotFound();
            }
            var companiesList = _mapper.Map<List<dtos.CompanyViewDto>>(companyEntities);
            return Ok(companiesList);

        }

        [HttpPost]
        [Route("addCompany")]
        public async Task<IActionResult> CreateCompany([FromBody] dtos.CompanyInputDto company)
        {
            var companyContactEntity = _mapper.Map<Entities.Companies>(company);
            var companyExists = await _companyRepository.CompanyIfExists(company.companyName);
            if (companyExists > 0)
            {
                return Ok("Already Exists!");
            }
            else
            {
                await _companyRepository.AddCompany(companyContactEntity);
                await _companyRepository.SaveChanges();
            }
            return Ok(companyContactEntity);

        }

        [HttpPost]
        [Route("updateCompany")]
        public async Task<IActionResult> UpdateCompany([FromBody] dtos.CompanyInputUpdateDto company)
        {
            var companyContactEntity = _mapper.Map<Entities.Companies>(company);
            await _companyRepository.UpdateCompany(companyContactEntity);
            return Ok(companyContactEntity);
        }
        [HttpPost]
        [Route("getCompany")]
        [ProducesResponseType(typeof(dtos.CompanyViewDto), 200)]
        public async Task<IActionResult> GetCompany([FromBody] CompanyInput company)
        {
            var companyEntity = await _companyRepository.GetCompany(company.companyId);
            if (companyEntity == null)
            {
                return NotFound();
            }

            var companyInfo = _mapper.Map<dtos.CompanyViewDto>(companyEntity);
            return Ok(companyInfo);

        }

        [HttpPost]
        [Route("deactivateCompany")]
        public async Task<IActionResult> DeactivateCompany([FromBody] CompanyInput company)
        {
            int result = 0;
            var companyId = company.companyId;
            result = await _companyRepository.DeActivateCompany(companyId);
            return Ok(result);
        }


    }
}
