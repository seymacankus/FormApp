using FormApp.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Data.Concrete.EfCore.Extensions
{
    public static class SqlServerModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Oluşturma
            List<Role> roles = new List<Role>
            {
                new Role{Name="User", NormalizedName="USER"}
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region User Oluşturma
            List<User> users = new List<User>
            {
                new User{UserName="deniz", NormalizedUserName="DENIZ", Email="deniz@gmail.com", NormalizedEmail="DENIZ@GMAIL.COM", EmailConfirmed=true}
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion
            #region Parola İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            #endregion
            #region Rol Atama İşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id}
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

        }
    }
}
