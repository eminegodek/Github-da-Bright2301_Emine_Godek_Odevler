using EducationApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Entity.Concrete
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public string ImageUrl { get; set; }
		public int Time { get; set; }
		public decimal Price { get; set; }
		public bool IsHome { get; set; }
		public int InstructorId { get; set; }
		public Instructor Instructor { get; set; }
		public List<ProductCategory> ProductCategories { get; set; }
	}
}
