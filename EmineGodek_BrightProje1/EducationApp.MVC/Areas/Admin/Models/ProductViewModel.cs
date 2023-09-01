namespace EducationApp.MVC.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string InstructorName { get; set; }
        public bool IsActive { get; set; }
    }
}
