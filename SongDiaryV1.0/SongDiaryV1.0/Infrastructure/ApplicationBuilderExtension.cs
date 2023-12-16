using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using SongDiaryV1._0.Data;
using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Infrastructure
{
#nullable disable
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdmin(services);

            var dataType = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedSongType(dataType);

            var datatempo = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedTempo(datatempo);

            return app;
        }

        private static void SeedTempo(ApplicationDbContext datatempo)
        {
            if (datatempo.SongTempos.Any())
            {
                return;
            }
            datatempo.SongTempos.AddRange(new[]
            {
                new SongTempo{Name="Бавни"},
                new SongTempo{Name="Бързи"}
            });
            datatempo.SaveChanges();
        }

        private static void SeedSongType(ApplicationDbContext dataType)
        {
            if (dataType.SongTypes.Any())
            {
                return;
            }
            dataType.SongTypes.AddRange(new[]
            {
                new SongType{Name="Песнарки"},
                new SongType{Name="Авторски"},
                new SongType{Name="Преведени"},
                new SongType{Name="Еврейски"},
                new SongType{Name="Български"},
                new SongType{Name="Английски"},
                new SongType{Name="Руски"},
                
            });
            dataType.SaveChanges();
        }


        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrator", "Worship Leader", "Worship Team", "Single User" };
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        private static async Task SeedAdmin(IServiceProvider serviceProvider)
        {

            //Unable to login with admin role

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.Email = "stilyanapetrova1@gmail.com";
                user.UserName = "stilyanapetrova1@gmail.com";

                var result = await userManager.CreateAsync(user, "admin");
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }

            }
        }
    }
}
