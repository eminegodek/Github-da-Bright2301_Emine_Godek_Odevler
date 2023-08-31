namespace EducationApp.MVC.Areas.Admin.Models
{
    public class ProductDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InstructorName { get; set; }
        public decimal Price { get; set; }
        public bool IsHome { get; set; }
        public bool IsActive { get; set; }
    }
}
