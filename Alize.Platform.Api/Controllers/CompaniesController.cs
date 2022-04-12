using Alize.Platform.Data.Models;
using Alize.Platform.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        // GET: api/<CompaniesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var companies = await _companyRepository.GetCompaniesAsync();

            return Ok(companies);
        }

        // GET api/<CompaniesController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var company = await _companyRepository.GetCompanyAsync(id);

            return Ok(company);
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            await _companyRepository.AddCompanyAsync(company);

            return CreatedAtAction(nameof(Get), new { id = company.Id }, company);
        }

        // PUT api/<CompaniesController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            await _companyRepository.UpdateCompanyAsync(company);

            return NoContent();
        }

        // DELETE api/<CompaniesController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var app = await _companyRepository.GetCompanyAsync(id);

            if (app is null)
                return BadRequest();

            await _companyRepository.DeleteCompanyAsync(app);

            return NoContent();
        }
    }
}
