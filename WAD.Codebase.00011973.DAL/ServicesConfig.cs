using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WAD.Codebase._00011973.Data;
using WAD.Codebase._00011973.Interfaces;
using WAD.Codebase._00011973.Mapping;
using WAD.Codebase._00011973.Repositories;

namespace WAD.Codebase._00011973.DAL
{
    public static class ServicesConfig
    {
        public static IServiceCollection ConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobBoardContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}