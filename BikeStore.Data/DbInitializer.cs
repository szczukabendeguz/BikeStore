using BikeStore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BikeStore.Data
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BikeStoreContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure roles exist
            var roles = new[] { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
            }

            // Create example users
            var users = new[]
            {
                new AppUser { UserName = "admin@example.com", Email = "admin@example.com" },
                new AppUser { UserName = "user1@example.com", Email = "user1@example.com" },
                new AppUser { UserName = "user2@example.com", Email = "user2@example.com" },
                new AppUser { UserName = "user3@example.com", Email = "user3@example.com" },
                new AppUser { UserName = "user4@example.com", Email = "user4@example.com" }
            };

            foreach (var user in users)
            {
                if (userManager.FindByEmailAsync(user.Email).Result == null)
                {
                    userManager.CreateAsync(user, "Password123!").Wait();
                    userManager.AddToRoleAsync(user, user.Email == "admin@example.com" ? "Admin" : "User").Wait();
                }
            }

            // Add example BikeBrands
            var brands = new[]
            {
                new BikeBrand("Trek", "USA"),
                new BikeBrand("Giant", "Taiwan"),
                new BikeBrand("Specialized", "USA"),
                new BikeBrand("Canyon", "Germany"),
                new BikeBrand("Santa Cruz", "USA"),
                new BikeBrand("Yeti", "USA"),
                new BikeBrand("Scott", "Switzerland"),
                new BikeBrand("BMC", "Switzerland")
            };

            if (!context.BikeBrands.Any())
            {
                context.BikeBrands.AddRange(brands);
            }

            // Add example BikeModels
            if (!context.BikeModels.Any())
            {
                context.BikeModels.AddRange(
                    // Trek Models
                    new BikeModel(brands[0].Id, "Trek X-Caliber", 100, 0, 800, users[1].Id),
                    new BikeModel(brands[0].Id, "Trek Marlin", 120, 0, 650, users[2].Id),
                    new BikeModel(brands[0].Id, "Trek Fuel EX", 140, 140, 3000, users[3].Id),

                    // Giant Models
                    new BikeModel(brands[1].Id, "Giant Anthem", 110, 110, 1200, users[4].Id),
                    new BikeModel(brands[1].Id, "Giant Trance", 150, 150, 2500, users[1].Id),

                    // Specialized Models
                    new BikeModel(brands[2].Id, "Specialized Stumpjumper", 140, 140, 2000, users[2].Id),
                    new BikeModel(brands[2].Id, "Specialized Epic", 100, 100, 3000, users[3].Id),

                    // Canyon Models
                    new BikeModel(brands[3].Id, "Canyon Spectral", 160, 160, 3200, users[4].Id),
                    new BikeModel(brands[3].Id, "Canyon Strive", 150, 150, 2800, users[1].Id),

                    // Santa Cruz Models
                    new BikeModel(brands[4].Id, "Santa Cruz Hightower", 150, 150, 3500, users[2].Id),
                    new BikeModel(brands[4].Id, "Santa Cruz Nomad", 170, 170, 4000, users[3].Id),

                    // Yeti Models
                    new BikeModel(brands[5].Id, "Yeti SB150", 150, 150, 5000, users[4].Id),
                    new BikeModel(brands[5].Id, "Yeti SB130", 130, 130, 4500, users[1].Id),

                    // Scott Models
                    new BikeModel(brands[6].Id, "Scott Spark", 120, 120, 2500, users[2].Id),
                    new BikeModel(brands[6].Id, "Scott Genius", 150, 150, 3000, users[3].Id),

                    // BMC Models
                    new BikeModel(brands[7].Id, "BMC Fourstroke", 100, 100, 5000, users[4].Id),
                    new BikeModel(brands[7].Id, "BMC Speedfox", 130, 130, 3800, users[1].Id)
                );
            }

            context.SaveChanges();
        }
    }
}
