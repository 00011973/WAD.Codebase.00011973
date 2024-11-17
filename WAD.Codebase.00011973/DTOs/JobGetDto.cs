namespace WAD.Codebase._00011973.DTOs
{
    public class JobGetDto
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
        public string CompanyName { get; set; } // Include the company name
    }

    public class JobCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
        public int CompanyId { get; set; } // Reference to the company
    }
}
