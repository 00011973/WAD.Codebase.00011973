namespace WAD.Codebase._00011973.Models
{
    public class Job
    {
        public int JobId { get; set; } // Primary Key
        public string Title { get; set; } // Job Title
        public string Description { get; set; } // Job Description
        public decimal Salary { get; set; } // Job Salary
        public string Location { get; set; } // Job Location

        // Foreign Key
        public int CompanyId { get; set; }
        public Company Company { get; set; } // Navigation Property
    }

}
