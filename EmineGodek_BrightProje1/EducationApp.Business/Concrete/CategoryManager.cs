using EducationApp.Business.Abstract;
using EducationApp.Data.Abstract;
using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryManager(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task CreateAsync(Category category)
		{
			await _categoryRepository.CreateAsync(category);
		}

		public void Delete(Category category)
		{
			_categoryRepository.Delete(category);
		}

		public async Task<List<Category>> GetAllAsync()
		{
			var result = await _categoryRepository.GetAllAsync();
			return result;
		}

        public async Task<List<Category>> GetAllCategoriesAsync(bool isDeleted, bool? isActive = null)
        {
            var result = await _categoryRepository.GetAllCategoriesAsync(isDeleted, isActive);
            return result;
        }

        public async Task<Category> GetByIdAsync(int id)
		{
			var result = await _categoryRepository.GetByIdAsync(id);
			return result;
		}

		public void Update(Category category)
		{
			_categoryRepository.Update(category);
		}
	}
}
