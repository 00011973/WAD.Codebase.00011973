using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.Codebase._00011973.DTOs;
using WAD.Codebase._00011973.Interfaces;
using WAD.Codebase._00011973.Models;

namespace WAD.Codebase._00011973.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
        {
            var jobs = await _unitOfWork.Jobs.GetJobsWithCompanyAsync();
            return Ok(_mapper.Map<IEnumerable<JobGetDto>>(jobs));
        }

        // POST: api/Jobs
        [HttpPost]
        public async Task<ActionResult> CreateJob(JobCreateDto jobCreateDto)
        {
            var job = _mapper.Map<Job>(jobCreateDto);
            await _unitOfWork.Jobs.AddAsync(job);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJobs), new { id = job.JobId }, new
            {
                Message = "Job created successfully",
                JobId = job.JobId,
                Title = job.Title
            });
        }

        // PUT: api/Jobs/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateJob(int id, JobCreateDto jobUpdateDto)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound(new { Message = $"Job with ID {id} not found." });
            }

            _mapper.Map(jobUpdateDto, job);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new
            {
                Message = "Job updated successfully",
                JobId = job.JobId,
                Title = job.Title
            });
        }

        // DELETE: api/Jobs/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJob(int id)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound(new { Message = $"Job with ID {id} not found." });
            }

            await _unitOfWork.Jobs.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new
            {
                Message = "Job deleted successfully",
                JobId = job.JobId,
                Title = job.Title
            });
        }
    }
}
