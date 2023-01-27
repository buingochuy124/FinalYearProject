using Microsoft.EntityFrameworkCore;
using Smarest.Model;
using System;

namespace Smarest.Data.SeedData
{
    public static class SeedRolesToDb
    {
        public static void Seed(ModelBuilder builder)
        {
            SeedRoles(builder);
        }
        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = UserRoles.RoleConstant.Admin,
                    NormalizedName = UserRoles.RoleConstant.Admin.ToUpper()
                },
                new Role()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = UserRoles.RoleConstant.Manager,
                    NormalizedName = UserRoles.RoleConstant.Manager.ToUpper()
                },
                new Role()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = UserRoles.RoleConstant.Guest,
                    NormalizedName = UserRoles.RoleConstant.Guest.ToUpper()
                });
        }
    }
}
