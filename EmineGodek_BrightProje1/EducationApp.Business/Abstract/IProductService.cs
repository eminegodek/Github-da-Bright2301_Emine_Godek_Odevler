using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Abstract
{
	public interface IProductService
	{
		Task<Product> GetByIdAsync(int id);
		Task<List<Product>> GetAllAsync();
		Task CreateAsync(Product product);
		void Update(Product product);
		void Delete(Product product);

		Task<List<Product>> GetProductsWithFullDataAsync(bool? isHome = null, bool? isActive = null);
		Task<List<Product>> GetAllActiveProductsAsync(string categoryUrl = null, string instructorUrl = null);
		Task<Product> GetProductByUrlAsync(string productUrl);
		Task<Product> GetProductByIdAsync(int id);
		Task<List<Product>> GetAllProductsWithInstructor(bool isDeleted);
		Task CreateProductAsync(Product product, List<int> SelectedCategoryIds);
		Task UpdateInstructorOfProducts();
		Task CheckProductsCategories();
		void UpdateProduct(Product product);
	}
}
