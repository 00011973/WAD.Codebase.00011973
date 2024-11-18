using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.Codebase._00011973.DTOs;
using WAD.Codebase._00011973.Interfaces;
using WAD.Codebase._00011973.Models;

namespace WAD.Codebase._00011973.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompaniesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetCompanies()
        {
            var companies = await _unitOfWork.Companies.GetCompaniesWithJobsAsync();
            return Ok(_mapper.Map<IEnumerable<CompanyGetDto>>(companies));
        }

        // POST: api/Companies
        [HttpPost]
        public async Task<ActionResult> CreateCompany(CompanyCreateDto companyCreateDto)
        {
            var company = _mapper.Map<Company>(companyCreateDto);
            await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompanies), new { id = company.CompanyId }, new
            {
                Message = "Company created successfully",
                CompanyId = company.CompanyId,
                Name = company.Name
            });
        }

        // PUT: api/Companies/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompany(int id, CompanyCreateDto companyUpdateDto)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound(new { Message = $"Company with ID {id} not found." });
            }

            _mapper.Map(companyUpdateDto, company);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new
            {
                Message = "Company updated successfully",
                CompanyId = company.CompanyId,
                Name = company.Name
            });
        }

        // DELETE: api/Companies/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound(new { Message = $"Company with ID {id} not found." });
            }

            await _unitOfWork.Companies.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new
            {
                Message = "Company deleted successfully",
                CompanyId = company.CompanyId,
                Name = company.Name
            });
        }
    }
}
