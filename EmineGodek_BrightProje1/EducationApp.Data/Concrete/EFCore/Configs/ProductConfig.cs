using EducationApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Concrete.EFCore.Configs
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.CreatedDate).IsRequired();

			builder.Property(x => x.ModifiedDate).IsRequired();

			builder.Property(x => x.IsActive).IsRequired();

			builder.Property(x => x.IsDeleted).IsRequired();

			builder.Property(x => x.Url).IsRequired();

			builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

			builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);

			builder.Property(x => x.Time).IsRequired();

			builder.Property(x => x.ImageUrl).IsRequired();

			builder.Property(x => x.Price).IsRequired();

			builder.Property(x => x.IsHome).IsRequired();

			builder.HasOne(x => x.Instructor).WithMany(x => x.Products).HasForeignKey(x => x.InstructorId).OnDelete(DeleteBehavior.NoAction);

			builder.HasData(
				new Product
				{
					Id = 1,
					Name = "Türk Mutfağı",
					Description = "Türk Mutfağının bir birinden eşsiz lezzetleriyle sofralarınıza lezzet katacaksınız.",
					Url = "turk-mutfagi",
					ImageUrl = "14.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 1
				},
				new Product
				{
					Id = 2,
					Name = "Uzak Doğu",
					Description = "Uzak Doğunun bir birinden eşsiz lezzetleriyle sofralarınıza lezzet katacaksınız.",
					Url = "java",
					ImageUrl = "12.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 2
				},
				new Product
				{
					Id = 3,
					Name = "Kalabalık Sofra",
					Description = "Kalabalık gruplarla eğitimlere katılarak eşsiz anılar oluşturacaksınız",
					Url = "kalabalik-sofra",
					ImageUrl = "3.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 3
				},
				new Product
				{
					Id = 4,
					Name = "Pastacılık",
					Description = "En renkli tatlılar kutlama yemeklerinizin favorisi olacak.",
					Url = "pastacilik",
					ImageUrl = "6.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 4
				},
				new Product
				{
					Id = 5,
					Name = "Etler",
					Description = "İyi pişmiş bir et menüsünden daha iyi çok az şey vardır.",
					Url = "etler",
					ImageUrl = "10.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 5
				},
				new Product
				{
					Id = 6,
					Name = "Hamur İşleri",
					Description = "El açması hamur işleri için komşunuz yardımınızı isteyecek.",
					Url = "hamur-isleri",
					ImageUrl = "7.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 6
				},
				new Product
				{
					Id = 7,
					Name = "Kahveler",
					Description = "Evinizde kendi kafenizi kurun.",
					Url = "kahveler",
					ImageUrl = "9.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 7
				},
				new Product
				{
					Id = 8,
					Name = "Türk Mutfağı",
					Description = "Türk Mutfağının bir birinden eşsiz lezzetleriyle sofralarınıza lezzet katacaksınız.",
					Url = "turk-mutfagi",
					ImageUrl = "1.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 8
				},
				new Product
				{
					Id = 9,
					Name = "Hamur İşleri",
					Description = "El açması hamur işleri için komşunuz yardımınızı isteyecek.",
					Url = "hamur-isleri",
					ImageUrl = "2.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 9
				},
				new Product
				{
					Id = 10,
					Name = "Pastacılık",
					Description = "En renkli tatlılar kutlama yemeklerinizin favorisi olacak.",
					Url = "pastacilik",
					ImageUrl = "8.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 10
				},
				new Product
				{
					Id = 11,
					Name = "Hamur İşleri",
					Description = "El açması hamur işleri için komşunuz yardımınızı isteyecek.",
					Url = "hamur-isleri",
					ImageUrl = "11.jpg",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 11
				},
				new Product
				{
					Id = 12,
					Name = "Pastacılık",
					Description = "En renkli tatlılar kutlama yemeklerinizin favorisi olacak.",
					Url = "pastacilik",
					ImageUrl = "13.png",
					Price = 100,
					Time = 200,
					IsHome = true,
					InstructorId = 12
				});
		}
	}
}
