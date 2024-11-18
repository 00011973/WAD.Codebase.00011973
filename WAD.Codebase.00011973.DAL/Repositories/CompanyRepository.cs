using Microsoft.EntityFrameworkCore;
using WAD.Codebase._00011973.Data;
using WAD.Codebase._00011973.Interfaces;
using WAD.Codebase._00011973.Models;

namespace WAD.Codebase._00011973.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(JobBoardContext context) : base(context) { }

        public async Task<IEnumerable<Company>> GetCompaniesWithJobsAsync()
        {
            return await _context.Companies.Include(c => c.Jobs).ToListAsync();
        }
    }
}
