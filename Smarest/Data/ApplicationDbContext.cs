using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smarest.Data.SeedData;
using Smarest.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smarest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Item> Items { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //xoa chu trong db neu can
            //foreach (var entityType in builder.Model.GetEntityTypes())
            //{
            //    var tableName = entityType.GetTableName();
            //    if (tableName.StartsWith("AspNet"))
            //    {
            //        entityType.SetTableName(tableName.Substring(6));
            //    }
            //}

            SeedRolesToDb.Seed(builder);
        }

    }
}
