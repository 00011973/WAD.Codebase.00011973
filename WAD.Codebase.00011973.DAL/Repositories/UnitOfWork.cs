using WAD.Codebase._00011973.Data;
using WAD.Codebase._00011973.Interfaces;

namespace WAD.Codebase._00011973.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JobBoardContext _context;

        public IJobRepository Jobs { get; }
        public ICompanyRepository Companies { get; }

        public UnitOfWork(JobBoardContext context)
        {
            _context = context;
            Jobs = new JobRepository(context);
            Companies = new CompanyRepository(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
