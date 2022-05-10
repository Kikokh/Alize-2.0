using Alize.Platform.Api.Requests.Companies;
using Alize.Platform.Api.Responses.Companies;
using Alize.Platform.Data.Constants;
using Alize.Platform.Data.Models;
using Alize.Platform.Data.Repositories;
using Alize.Platform.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Modules.Companies)]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository companyRepository, ISecurityService securityService, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _securityService = securityService;
            _mapper = mapper;
        }

        // GET: api/<CompaniesController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var user = await _securityService.GetUserAsync(User.Claims.Single(c => c.Type == ClaimTypes.Sid).Value);

            if (user == null)
                return NotFound();

            var companies = await _companyRepository.GetCompaniesForUserAsync(user);

            return Ok(_mapper.Map<IEnumerable<CompanyResponse>>(companies));
        }

        // GET api/<CompaniesController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var company = await _companyRepository.GetCompanyAsync(id);

            return company is null ? NotFound() : Ok(_mapper.Map<CompanyResponse>(company));

        }

        // POST api/<CompaniesController>
        [HttpPost]
        [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] CreateCompanyRequest request)
        {
            var company = await _companyRepository.AddCompanyAsync(_mapper.Map<Company>(request));

            return CreatedAtAction(nameof(Get), new { id = company.Id }, _mapper.Map<CompanyResponse>(company));
        }

        // PUT api/<CompaniesController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCompanyRequest request)
        {
            if (id != request.Id) return BadRequest();

            if (await _companyRepository.GetCompanyAsync(id) is null) return NotFound();

            await _companyRepository.UpdateCompanyAsync(_mapper.Map<Company>(request));

            return NoContent();
        }

        // DELETE api/<CompaniesController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var company = await _companyRepository.GetCompanyAsync(id);

            if( company is null ) return NotFound(); 

            await _companyRepository.DeleteCompanyAsync(company);

            return NoContent();
        }
    }
}
