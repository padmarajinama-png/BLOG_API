using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BLOG.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)

        {

            base.OnModelCreating(builder);
            //Create Reader and Writer Roles
            var readerRoleId = "826bce72-bc43-4c06-a209-260d9762dac5";

            var writerRoleId = "c832627c-c9b2-4613-a917-988ee2855fae";

            var roles = new List<IdentityRole>
            {
                new IdentityRole()

              {

               Id=readerRoleId,

               Name="Reader",

               NormalizedName="Reader".ToUpper(),

               ConcurrencyStamp=readerRoleId
                },


                new IdentityRole()

                {

                 Id=writerRoleId,

                 Name="Writer",

                 NormalizedName="Writer".ToUpper(),

                 ConcurrencyStamp=writerRoleId }

                  };
            //Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            var adminUserId = "8967ab26-0f21-40ab-ac25-0a07840d3fd6";

            var admin = new IdentityUser()

            {

                Id = adminUserId,

                UserName = "admin@blog.com",

                Email = "admin@blog.com",

                NormalizedEmail = "admin@blog.com".ToUpper(),

                NormalizedUserName = "admin@blog.com".ToUpper(),

            };
            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);

            //Give Roles to Admin
            var adminRoles = new List<IdentityUserRole<string>>()

              {

                new()

                {

                    UserId = adminUserId,

                    RoleId = readerRoleId

                },

               new()

                {

                    UserId = adminUserId,

                    RoleId = writerRoleId
                }
                };



            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }
    }
}

