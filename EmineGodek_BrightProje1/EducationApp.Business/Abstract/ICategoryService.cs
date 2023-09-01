using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Abstract
{
	public interface ICategoryService
	{
		Task<Category> GetByIdAsync(int id);
		Task<List<Category>> GetAllAsync();
		Task CreateAsync(Category category);
		void Update(Category category);
		void Delete(Category category);

        Task<List<Category>> GetAllCategoriesAsync(bool isDeleted, bool? isActive = null);
    }
}
