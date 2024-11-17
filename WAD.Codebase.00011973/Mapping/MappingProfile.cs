using AutoMapper;
using WAD.Codebase._00011973.DTOs;
using WAD.Codebase._00011973.Models;

namespace WAD.Codebase._00011973.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Company Mappings
            CreateMap<Company, CompanyGetDto>()
                .ForMember(dest => dest.Jobs, opt => opt.MapFrom(src => src.Jobs)); // Map nested jobs
            CreateMap<CompanyCreateDto, Company>();

            // Job Mappings
            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name)); // Map company name
            CreateMap<JobCreateDto, Job>();
        }
    }
}
