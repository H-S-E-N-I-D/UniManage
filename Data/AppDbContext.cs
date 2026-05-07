using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UniManage.Models;

namespace UniManage.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Users>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("User_Roles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("User_Claims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("User_Logins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("Role_Claims");
            builder.Entity<IdentityUserToken<string>>().ToTable("User_Tokens");

            builder.Entity<Department>().Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Entity<Department>().Property(e => e.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        }
    }
}
