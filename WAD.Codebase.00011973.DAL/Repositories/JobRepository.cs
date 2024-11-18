using Microsoft.EntityFrameworkCore;
using WAD.Codebase._00011973.Data;
using WAD.Codebase._00011973.Interfaces;
using WAD.Codebase._00011973.Models;

namespace WAD.Codebase._00011973.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(JobBoardContext context) : base(context) { }

        public async Task<IEnumerable<Job>> GetJobsWithCompanyAsync()
        {
            return await _context.Jobs.Include(j => j.Company).ToListAsync();
        }
    }
}
