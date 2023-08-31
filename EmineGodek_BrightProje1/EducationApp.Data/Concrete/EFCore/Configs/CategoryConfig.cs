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
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
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

			builder.HasData(
				new Category
				{
					Id = 1,
					Name = "Türk Mutfağı",
					Description = "Türk Mutfağının bir birinden eşsiz lezzetleriyle sofralarınıza lezzet katacaksınız.",
					Url = "turk-mutfagi"
				},
				new Category
				{
					Id = 2,
					Name = "Uzak Doğu",
					Description = "Uzak Doğunun bir birinden eşsiz lezzetleriyle sofralarınıza lezzet katacaksınız.",
					Url = "uzak-dogu"
				},
				new Category
				{
                    Id = 3,
                    Name = "Kalabalık Sofra",
                    Description = "Kalabalık gruplarla eğitimlere katılarak eşsiz anılar oluşturacaksınız.",
                    Url = "kalabalik-sofra"
                },
				new Category
				{
					Id = 4,
					Name = "Pastacılık",
					Description = "En renkli tatlılar kutlama yemeklerinizin favorisi olacak.",
					Url = "pastacilik"
				},
				new Category
				{
					Id = 5,
					Name = "Etler",
					Description = "İyi pişmiş bir et menüsünden daha iyi çok az şey vardır.",
					Url = "etler"
				},
				new Category
				{
					Id = 6,
					Name = "Hamur İşleri",
					Description = "El açması hamur işleri için komşunuz yardımınızı isteyecek.",
					Url = "hamur-isleri"
				},
				new Category
				{
					Id = 7,
					Name = "Kahveler",
					Description = "Evinizde kendi kafenizi kurun.",
					Url = "kahveler"
				});
		}
	}
}
