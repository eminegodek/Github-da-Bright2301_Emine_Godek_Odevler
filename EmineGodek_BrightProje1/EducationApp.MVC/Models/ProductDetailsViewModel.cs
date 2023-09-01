using System;
namespace EducationApp.MVC.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string InstructorName { get; set; }
        public string InstructorAbout { get; set; }
        public string InstructorUrl { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        public string Description { get; set; }
    }
}

