using Microsoft.EntityFrameworkCore;
using Smarest.Model;

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
                    Id = 1,
                    Name = UserRoles.RoleConstant.Admin,
                    NormalizedName = UserRoles.RoleConstant.Admin.ToUpper()
                },
                new Role()
                {
                    Id=2,
                    Name = UserRoles.RoleConstant.Manager,
                    NormalizedName = UserRoles.RoleConstant.Manager.ToUpper()
                },
                new Role()
                {
                    Id=3,
                    Name = UserRoles.RoleConstant.Guest,
                    NormalizedName = UserRoles.RoleConstant.Guest.ToUpper()
                });
        }
    }
}
