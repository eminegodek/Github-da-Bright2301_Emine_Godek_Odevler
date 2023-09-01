namespace EducationApp.MVC.Models
{
	public class ProductViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		public DateTime Time { get; set; }
		public string InstructorName { get; set; }
		public string InstructorUrl { get; set; }
	}
}
