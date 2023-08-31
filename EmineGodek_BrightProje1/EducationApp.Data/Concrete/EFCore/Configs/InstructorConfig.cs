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
	public class InstructorConfig : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.CreatedDate).IsRequired();

			builder.Property(x => x.ModifiedDate).IsRequired();

			builder.Property(x => x.IsActive).IsRequired();

			builder.Property(x => x.IsDeleted).IsRequired();

			builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

			builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

			builder.Property(x => x.BirthOfYear).IsRequired();

			builder.Property(x => x.About).IsRequired().HasMaxLength(1000);

			builder.Property(x => x.PhotoUrl).IsRequired();

			builder.HasData(
				new Instructor
				{
					Id = 1,
					FirstName = "Dominic",
					LastName = "Harmon",
					BirthOfYear = 1990,
					PhotoUrl = "1.png",
					About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
					ProductId = 1,
				},
				new Instructor
				{
					Id = 2,
					FirstName = "Justina",
					LastName = "Burch",
					BirthOfYear = 1990,
					PhotoUrl = "1.png",
					About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 2,

                },
				 new Instructor
				 {
					  Id = 3,
					  FirstName = "Madison",
					  LastName = "Beard",
					  BirthOfYear = 1985,
					  PhotoUrl = "1.png",
					  About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
					  ProductId = 3,
				 },
				new Instructor
				{
					Id = 4,
					FirstName = "Sara",
					LastName = "Wade",
					BirthOfYear = 1982,
					PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 4,
				},
				new Instructor
				{
					Id = 5,
					FirstName = "Jacob",
					LastName = "Hunt",
					BirthOfYear = 1988,
					PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 5,
				},
				new Instructor
				{
					Id = 6,
					FirstName = "Osamu",
					LastName = "Dazai",
					BirthOfYear = 1989,
					PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 6,
				},
				new Instructor
				{
					Id = 7,
					FirstName = "Zachery",
					LastName = "Salas",
					BirthOfYear = 1983,
					PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 7,
				},
				new Instructor
				{
					Id = 8,
					FirstName = "Matt",
					LastName = "Haig",
					BirthOfYear = 1982,
					PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 8,
				},
				new Instructor
				{
					Id = 9,
					FirstName = "William",
					LastName = "Hawkingan",
					BirthOfYear = 1982,
					PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 9,
				},
				new Instructor
				{
					Id = 10,
					FirstName = "Geraldine",
					LastName = "Richmond",
					BirthOfYear = 1990,
                    PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 10,
				},
				new Instructor
				{
					Id = 11,
					FirstName = "Steffan",
					LastName = "Ros",
					BirthOfYear = 1983,
                    PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 11,
				},
				new Instructor
				{
					Id = 12,
					FirstName = "Nichole",
					LastName = "Talley",
					BirthOfYear = 1991,
                    PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 12,
				},
				new Instructor
				{
					Id = 13,
					FirstName = "Yetta",
					LastName = "Sheppard",
					BirthOfYear = 1979,
                    PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 13,
				},
				new Instructor
				{
					Id = 14,
					FirstName = "Elijah",
					LastName = "Farley",
					BirthOfYear = 1978,
                    PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 14,
				},
				new Instructor
				{
					Id = 15,
					FirstName = "Neil",
					LastName = "Wooten",
					BirthOfYear = 1991,
                    PhotoUrl = "1.png",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    ProductId = 15,
				});
        }
	}
}
