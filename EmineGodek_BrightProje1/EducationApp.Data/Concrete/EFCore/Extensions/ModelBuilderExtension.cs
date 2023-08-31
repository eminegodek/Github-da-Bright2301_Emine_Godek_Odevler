using EducationApp.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Concrete.EfCore.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Bilgileri
            List<Role> roles = new List<Role>
            {
                new Role { Name="Admin", Description="Yöneticilerin rolü bu.", NormalizedName="ADMIN"},
                new Role { Name="User", Description="Diğer tüm kullanıcıların rolü bu.", NormalizedName="USER"}
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region Kullanıcı Bilgileri
            List<User> users = new List<User>
            {
                new User
                {
                    FirstName="Emine",
                    LastName="GÖDEK",
                    UserName="admin",
                    NormalizedUserName="ADMIN",
                    Email="eminegodekk@gmail.com",
                    NormalizedEmail="EMINEGODEKK@GMAIL.COM",
                    Gender="KADIN",
                    DateOfBirth= new DateTime(1998,3,30),
                    Address="Beykoz",
                    City="İstanbul",
                    EmailConfirmed=true,
                    SecurityStamp="",
                    LockoutEnabled=true
                }
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion
            #region Şifre İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            #endregion
            #region Rol Atama İşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles[0].Id }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
            #region Alışveriş Sepeti İşlemleri
            List<Cart> carts = new List<Cart>
            {
                new Cart{ Id=1, UserId=users[0].Id}
            };
            modelBuilder.Entity<Cart>().HasData(carts);
            #endregion
        }
    }
}
