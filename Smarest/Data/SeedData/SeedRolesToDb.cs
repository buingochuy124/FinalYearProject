using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Smarest.Model;
using System;
using System.Xml.Linq;

namespace Smarest.Data.SeedData
{
    public static class SeedRolesToDb
    {
        public static void Seed(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);
            SeedCategories(builder);
            SeedItem(builder);
        }
        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role()
                {
                    Id = "100",
                    Name = Utils.Role.Admin,
                    NormalizedName = Utils.Role.Admin.ToUpper()
                },
                new Role()
                {
                    Id = "101",
                    Name = Utils.Role.Manager,
                    NormalizedName = Utils.Role.Manager.ToUpper()
                },
                new Role()
                {
                    Id = "102",
                    Name = Utils.Role.Guest,
                    NormalizedName = Utils.Role.Guest.ToUpper()
                });
        }
        public static void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(
                new User()
                {
                    Id = "201",           
                    UserName = "Admin201@gmail.com",
                    NormalizedUserName = "Admin201@gmail.com".ToUpper(),
                    Email = "Admin201@gmail.com",
                    NormalizedEmail = "Admin201@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Default@123"),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Ngoc Huy",
                    LastName = "Bui",

                },
                new User()
                {
                    Id = "202",
                    UserName = "Manager202@gmail.com",
                    NormalizedUserName = "Manager202@gmail.com".ToUpper(),
                    Email = "Manager202@gmail.com",
                    NormalizedEmail = "Manager202@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Default@123"),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Thanh Binh",
                    LastName = "Phan",                  
                },
                new User()
                {
                    Id = "203",
                    UserName = "Guest203@gmail.com",
                    NormalizedUserName = "Guest203@gmail.com".ToUpper(),
                    Email = "Guest203@gmail.com",
                    NormalizedEmail = "Guest203@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Default@123"),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Hoai Anh",
                    LastName = "Bui Ngoc"
                });
        }

        public static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    // Bui Ngoc Huy
                    UserId = "201",
                    RoleId = "100"

                },
                new IdentityUserRole<string>
                {
                    // Phan Thanh Binh
                    UserId = "202",
                    RoleId = "101"

                },
                new IdentityUserRole<string>
                {
                    // Bui Ngoc Hoai Anh
                    UserId = "203",
                    RoleId = "102"

                });
        }
        public static void SeedCategories(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category()
                {
                    Id = "101",
                    Name = "Food"
                },
                new Category()
                {
                    Id = "102",
                    Name = "Drink"
                },
                new Category()
                {
                    Id = "103",
                    Name = "Other"
                }); 
        }
        public static void SeedItem(ModelBuilder builder)
        {
            builder.Entity<Item>().HasData(
               new Item()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Fried rice",
                   Cost = 30.5,
                   ImageUrl = "https://www.jessicagavin.com/wp-content/uploads/2018/09/fried-rice-8-1200.jpg",
                   CategoryId = "101"
               },
               new Item()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Santa Maria Grilled Tri-Tip Beef",
                   Cost = 30.5,
                   ImageUrl = "https://www.allrecipes.com/thmb/r29Rv3SakBBaqpbOZu4fHibsf8k=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/236992-santa-maria-grilled-tri-tip-beef-ddmfs-1x1-1-517a088b88a8431c8a41b81c1e978758.jpg",
                   CategoryId = "101"
               },
               new Item()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Coca",
                   Cost = 12.5,
                   ImageUrl = "https://cf.shopee.vn/file/bacb189db5215ac1f25033d76b6c6add",
                   CategoryId = "102"
               },
               new Item()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Pepsi",
                   Cost = 13.5,
                   ImageUrl = "https://www.pepsi.com/en-us/uploads/images/twil-can.png",
                   CategoryId = "102"
               },
               new Item()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "tissue",
                   Cost = 10.0,
                   ImageUrl = "https://www.intour.com.vn/upload/2021/03/thumbs/chuyen-san-xuat-khan-uot-kham-lanh-omi-gia-tot-nhat-vn-2.jpg",
                   CategoryId = "103"
               });

        }
      
    }
}
