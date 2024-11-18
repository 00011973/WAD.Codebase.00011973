using WAD.Codebase._00011973.Models;

namespace WAD.Codebase._00011973.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetCompaniesWithJobsAsync();
    }
}
