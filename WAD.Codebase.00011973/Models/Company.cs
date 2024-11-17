namespace WAD.Codebase._00011973.Models
{
    public class Company
    {
        public int CompanyId { get; set; } // Primary Key
        public string Name { get; set; } // Company Name
        public string Address { get; set; } // Company Address
        public string Website { get; set; } // Company Website

        // Navigation Property
        public ICollection<Job> Jobs { get; set; }
    }
}
