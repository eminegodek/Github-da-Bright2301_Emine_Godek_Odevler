namespace EducationApp.MVC.Areas.Admin.Models
{
    public class InstructorViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public string PhotoUrl { get; set; }
        public int BirthOfYear { get; set; }
        public int Age()
        {
            int result = DateTime.Now.Year - BirthOfYear;
            return result;
        }

    }
}
