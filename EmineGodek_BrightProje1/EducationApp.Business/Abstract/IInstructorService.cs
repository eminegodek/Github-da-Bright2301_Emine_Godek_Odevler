using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Abstract
{
	public interface IInstructorService
	{
		Task<Instructor> GetByIdAsync(int id);
		Task<List<Instructor>> GetAllAsync();
		Task CreateAsync(Instructor instructor);
		void Update(Instructor instructor);
		void Delete(Instructor instructor);

		Task<List<Instructor>> GetAllInstructorsAsync(bool isDeleted, bool? isActive = null);
		Task CreateWithUrl(Instructor instructor);
		Task<List<Instructor>> GetAllActiveInstructorsAsync(string categoryUrl = null, string instructorUrl = null);
		Task<Instructor> GetInstructorsByUrlAsync(string instructorUrl);
		Task<List<Instructor>> GetInstructorsWithFullDataAsync(bool? isActive = null);
	}
}
