using EducationApp.Core;
using EducationApp.Data.Abstract;
using EducationApp.Data.Concrete.EFCore.Contexts;
using EducationApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Concrete.EFCore.Repositories
{
	public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
	{
		public EfCoreProductRepository(EducationAppContext _context) : base(_context)
		{

		}

		private EducationAppContext Context
		{
			get { return _dbContext as EducationAppContext; }
		}

		public async Task CheckProductsCategories()
		{
			var productCategoryIds = await Context
				.ProductCategories
				.Select(bc => bc.ProductId)
				.Distinct()
				.ToListAsync();
			var productIds = await Context
				.Products
				.Select(b => b.Id)
				.ToListAsync();
			List<int> different = productIds.Except(productCategoryIds).ToList();
			await Context.ProductCategories.AddRangeAsync(different.Select(d => new ProductCategory
			{
				ProductId = d,
				CategoryId = 1
			}).ToList());
			await Context.SaveChangesAsync();
		}

		public async Task CreateProductAsync(Product product, List<int> SelectedCategoryIds)
		{
			await Context.Products.AddAsync(product);
			await Context.SaveChangesAsync();
			product.ProductCategories = SelectedCategoryIds.Select(sc => new ProductCategory
			{
				ProductId = product.Id,
				CategoryId = sc
			}).ToList();
			Context.Products.Update(product);
			await Context.SaveChangesAsync();
		}

		public async Task<List<Product>> GetAllActiveProductsAsync(string categoryUrl = null, string instructorUrl = null)
		{
			var result = Context
				.Products
				.Where(b => b.IsActive && !b.IsDeleted)
				.Include(b => b.Instructor)
				.AsQueryable();
			if (categoryUrl != null)
			{
				result = result
					.Include(b => b.ProductCategories)
					.ThenInclude(bc => bc.Category)
					.Where(b => b.ProductCategories.Any(bc => bc.Category.Url == categoryUrl))
					.AsQueryable();
			}
			if (instructorUrl != null)
			{
				result = result
					.Where(b => b.Instructor.Url == instructorUrl)
					.AsQueryable();
			}
			return await result.ToListAsync();
		}

		public async Task<List<Product>> GetAllProductsWithInstructor(bool isDeleted)
		{
			var result = await Context
				.Products
				.Where(b => b.IsDeleted == isDeleted)
				.Include(b => b.Instructor)
				.ToListAsync();
			return result;
		}

		public async Task<Product> GetProductByIdAsync(int id)
		{
			var result = await Context
				.Products
				.Where(b => b.IsActive && !b.IsDeleted && b.Id == id)
				.Include(b => b.ProductCategories)
				.ThenInclude(bc => bc.Category)
				.Include(b => b.Instructor)
				.FirstOrDefaultAsync();	
			return result;
		}

		public async Task<Product> GetProductByUrlAsync(string productUrl)
		{
			var result = await Context
				.Products
				.Where(b => b.IsActive && !b.IsDeleted && b.Url == productUrl)
				.Include(b => b.ProductCategories)
				.ThenInclude(bc => bc.Category)
				.Include(b => b.Instructor)
				.FirstOrDefaultAsync();
			return result;
		}

		public async Task<List<Product>> GetProductsWithFullDataAsync(bool? isHome = null, bool? isActive = null)
		{
			var result = Context
				.Products
				.Where(b => !b.IsDeleted)
				.AsQueryable();

			if (isHome != null)
			{
				result = result
					.Where(b => b.IsHome == isHome)
					.AsQueryable();
			}

			if (isActive != null)
			{
				result = result
					.Where(b => b.IsActive == isActive)
					.AsQueryable();
			}
			result = result
				.Include(b => b.ProductCategories)
				.ThenInclude(bc => bc.Category)
				.Include(b => b.Instructor)
				.AsQueryable();
			return await result.ToListAsync();
		}

		public async Task UpdateInstructorOfProducts()
		{
			var products = await Context
				.Products
				//.Where(b => b.InstructorId == null)
				.ToListAsync();
			foreach (var product in products)
			{
				product.InstructorId = 1;
			};
			Context.Products.UpdateRange(products);
			await Context.SaveChangesAsync();
		}

		public void UpdateProduct(Product product)
		{
			Product oldBook = Context
				.Products
				.Include(b => b.ProductCategories)
				.ThenInclude(bc => bc.Category)
				.Include(b => b.Instructor)
				.Where(b => b.Id == product.Id)
				.FirstOrDefault();
			oldBook.Name = product.Name;
			oldBook.Description = product.Description;
			oldBook.Price = product.Price;
			oldBook.IsActive = product.IsActive;
			oldBook.IsHome = product.IsHome;
			oldBook.IsDeleted = product.IsDeleted;
			oldBook.InstructorId = product.InstructorId;
			oldBook.Url = product.Url;
			oldBook.ModifiedDate = DateTime.Now;
			oldBook.ProductCategories = product.ProductCategories;
			oldBook.ImageUrl = product.ImageUrl;

			Context.Products.Update(oldBook);
			Context.SaveChanges();
		}
	}
}