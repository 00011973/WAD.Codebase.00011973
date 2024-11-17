using Microsoft.EntityFrameworkCore;
using WAD.Codebase._00011973.Models;

namespace WAD.Codebase._00011973.Data
{
    public class JobBoardContext : DbContext
    {
        public JobBoardContext(DbContextOptions<JobBoardContext> options) : base(options)
        {
        }

        // DbSets for the entities
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configuration (optional for fine-tuning relationships)
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Company)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CompanyId);
        }
    }
}
