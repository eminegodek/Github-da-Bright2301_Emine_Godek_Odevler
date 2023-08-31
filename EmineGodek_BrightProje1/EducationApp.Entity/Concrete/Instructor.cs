using EducationApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Entity.Concrete
{
	public class Instructor : BaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int BirthOfYear { get; set; }
		public string Url { get; set; }
		public string About { get; set; }
		public string PhotoUrl { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
	}
}
