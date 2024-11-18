using WAD.Codebase._00011973.Models;

namespace WAD.Codebase._00011973.Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<IEnumerable<Job>> GetJobsWithCompanyAsync();
    }

}
