namespace WAD.Codebase._00011973.DTOs
{
    public class CompanyGetDto
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public ICollection<JobGetDto> Jobs { get; set; } // Nested jobs
    }

    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
    }

}
