using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompaniesController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet("GetAllCompanies")]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _service.GetAllAsync();

            Console.WriteLine(companies.Select(x => x.Id).First().ToString());

            return Ok(companies);
        }

        [HttpGet("GetAllEnabled")]
        public async Task<IActionResult> GetAllEnabled()
        {
            var companies = await _service.GetAllEnabledAsync();
            return Ok(companies);
        }

        [HttpGet("GetCompanyById/{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var company = await _service.GetByIdAsync(id);
            if (company == null) return NotFound();

            return Ok(company);
        }

        [HttpPost("AddCompany")]
        public async Task<IActionResult> Add(CompanyRequestDto dto)
        {
            var companyId = await _service.AddAsync(dto);

            return Ok(companyId);
        }

        [HttpPut("UpdateCompany/{id:long}")]
        public async Task<IActionResult> Update(long id, CompanyRequestDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("DeleteCompany/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}