using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniManage.Data;
using UniManage.Models;

namespace UniManage.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Users>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                // Ensure the database is ready
                logger.LogInformation("Ensuring the database is created.");
                await context.Database.EnsureCreatedAsync();

                // Add roles
                logger.LogInformation("Seeding roles.");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "System Admin");
                await AddRoleAsync(roleManager, "Department Admin");
                await AddRoleAsync(roleManager, "User");
                await AddRoleAsync(roleManager, "Student");
                await AddRoleAsync(roleManager, "Lecturer");

                // Add admin user
                logger.LogInformation("Seeding admin user.");
                var adminEmail = "admin@codehub.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new Users
                    {
                        FullName = "Code Hub",
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Assigning Admin role to the admin user.");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        logger.LogError("Failed to create admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }

                logger.LogInformation("Seeding departments.");
                await SeedDepartmentsAsync(context, logger);

                logger.LogInformation("Database seeding completed successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");

            }

        }

        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }

        private static async Task SeedDepartmentsAsync(AppDbContext context, ILogger<SeedService> logger)
        {
            var existingDepartmentNames = await context.Departments
                .Select(d => d.Name)
                .ToListAsync();

            var departmentsToSeed = new List<Department>
    {
        new Department
        {
            Guid = System.Guid.NewGuid().ToString(),
            Name = "Department of Languages",
            Description = "Handles academic programs, teaching, and research related to languages.",
            IsActive = true
        },
        new Department
        {
            Guid = System.Guid.NewGuid().ToString(),
            Name = "Department of Art & Design",
            Description = "Handles academic programs, teaching, and research related to art and design.",
            IsActive = true
        },
        new Department
        {
            Guid = System.Guid.NewGuid().ToString(),
            Name = "Department of Life Science",
            Description = "Handles academic programs, teaching, and research related to life sciences.",
            IsActive = true
        },
        new Department
        {
            Guid = System.Guid.NewGuid().ToString(),
            Name = "Department of Computing",
            Description = "Handles academic programs, teaching, and research related to computing and information technology.",
            IsActive = true
        },
        new Department
        {
            Guid = System.Guid.NewGuid().ToString(),
            Name = "Department of Engineering",
            Description = "Handles academic programs, teaching, and research related to engineering disciplines.",
            IsActive = true
        },
        new Department
        {
            Guid = System.Guid.NewGuid().ToString(),
            Name = "Department of Management & Law",
            Description = "Handles academic programs, teaching, and research related to management and law.",
            IsActive = true
        }
    };

            var newDepartments = departmentsToSeed
                .Where(d => !existingDepartmentNames.Contains(d.Name))
                .ToList();

            if (newDepartments.Any())
            {
                await context.Departments.AddRangeAsync(newDepartments);
                await context.SaveChangesAsync();

                foreach (var dept in newDepartments)
                {
                    logger.LogInformation("Seeded department: {DepartmentName}", dept.Name);
                }
            }
            else
            {
                logger.LogInformation("All departments already exist.");
            }
        }
    }
}
