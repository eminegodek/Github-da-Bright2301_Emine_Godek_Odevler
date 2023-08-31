using EducationApp.Data.Concrete.EfCore.Extensions;
using EducationApp.Data.Concrete.EFCore.Configs;
using EducationApp.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Concrete.EFCore.Contexts
{
	public class EducationAppContext : IdentityDbContext<User, Role, string>
	{
		public EducationAppContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.SeedData();
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(InstructorConfig).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
