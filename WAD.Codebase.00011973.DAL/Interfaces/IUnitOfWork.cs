namespace WAD.Codebase._00011973.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IJobRepository Jobs { get; }
        ICompanyRepository Companies { get; }
        Task<int> SaveChangesAsync();
    }

}
