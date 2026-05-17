using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UniManage.Models
{
    /// <summary>
    /// EF Core DbContext for UniManage.
    /// Extends <see cref="IdentityDbContext{TUser}"/> so that ASP.NET Identity tables
    /// (users, roles, user_roles, user_claims, role_claims, user_logins, user_tokens)
    /// are managed automatically.
    /// </summary>
    public class UniManageDbContext : IdentityDbContext<ApplicationUser>
    {
        public UniManageDbContext(DbContextOptions<UniManageDbContext> options)
            : base(options) { }

        // ── Academic structure ──────────────────────────────────────────────
        public DbSet<AcademicYear> AcademicYears => Set<AcademicYear>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<ProgramLevel> ProgramLevels => Set<ProgramLevel>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<CourseModule> CourseModules => Set<CourseModule>();
        public DbSet<CoursePrerequisite> CoursePrerequisites => Set<CoursePrerequisite>();
        public DbSet<CourseOffering> CourseOfferings => Set<CourseOffering>();
        public DbSet<Prerequisite> Prerequisites => Set<Prerequisite>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<Semester> Semesters => Set<Semester>();
        public DbSet<SemesterModule> SemesterModules => Set<SemesterModule>();

        // ── Profiles ────────────────────────────────────────────────────────
        public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
        public DbSet<LecturerProfile> LecturerProfiles => Set<LecturerProfile>();
        public DbSet<DepartmentAdminProfile> DepartmentAdminProfiles => Set<DepartmentAdminProfile>();
        public DbSet<SystemAdminProfile> SystemAdminProfiles => Set<SystemAdminProfile>();

        // ── Enrollment ──────────────────────────────────────────────────────
        public DbSet<EnrollmentRequest> EnrollmentRequests => Set<EnrollmentRequest>();
        public DbSet<EnrollmentRequestDocument> EnrollmentRequestDocuments => Set<EnrollmentRequestDocument>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        // ── Assignments & grades ────────────────────────────────────────────
        public DbSet<CourseMaterial> CourseMaterials => Set<CourseMaterial>();
        public DbSet<Assignment> Assignments => Set<Assignment>();
        public DbSet<AssignmentSubmission> AssignmentSubmissions => Set<AssignmentSubmission>();
        public DbSet<AssignmentGrade> AssignmentGrades => Set<AssignmentGrade>();
        public DbSet<GradeScale> GradeScales => Set<GradeScale>();
        public DbSet<FinalCourseGrade> FinalCourseGrades => Set<FinalCourseGrade>();

        // ── Messaging ───────────────────────────────────────────────────────
        public DbSet<MessageThread> MessageThreads => Set<MessageThread>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<MessageAttachment> MessageAttachments => Set<MessageAttachment>();
        public DbSet<MessageAuditLog> MessageAuditLogs => Set<MessageAuditLog>();

        // ── System ──────────────────────────────────────────────────────────
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<Notification> Notifications => Set<Notification>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Must be called first — configures Identity tables

            // ── Identity table name overrides ────────────────────────────────
            builder.Entity<ApplicationUser>().ToTable("users");
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>().ToTable("roles");
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<string>>().ToTable("user_roles");
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>>().ToTable("user_claims");
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>>().ToTable("role_claims");
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<string>>().ToTable("user_logins");
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserToken<string>>().ToTable("user_tokens");

            // ── CourseModule: composite PK ───────────────────────────────────
            builder.Entity<CourseModule>()
                .HasKey(cm => new { cm.CourseId, cm.ModuleId });

            // ── MessageThread: multiple FKs to ApplicationUser ───────────────
            builder.Entity<MessageThread>()
                .HasOne(t => t.Creator)
                .WithMany(u => u.CreatedThreads)
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MessageThread>()
                .HasOne(t => t.Student)
                .WithMany(u => u.StudentThreads)
                .HasForeignKey(t => t.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MessageThread>()
                .HasOne(t => t.Lecturer)
                .WithMany(u => u.LecturerThreads)
                .HasForeignKey(t => t.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── Message: multiple FKs to ApplicationUser ─────────────────────
            builder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── FinalCourseGrade: unconstrained user FKs ─────────────────────
            builder.Entity<FinalCourseGrade>()
                .HasOne(g => g.Finalizer)
                .WithMany(u => u.FinalizedGrades)
                .HasForeignKey(g => g.FinalizedBy)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<FinalCourseGrade>()
                .HasOne(g => g.Publisher)
                .WithMany(u => u.PublishedGrades)
                .HasForeignKey(g => g.PublishedBy)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // ── Enum conversions (store as string for readability) ───────────
            builder.Entity<CourseOffering>()
                .Property(e => e.CourseStatus)
                .HasConversion<string>();

            builder.Entity<EnrollmentRequest>()
                .Property(e => e.Status)
                .HasConversion<string>();

            builder.Entity<Enrollment>()
                .Property(e => e.Status)
                .HasConversion<string>();

            builder.Entity<Assignment>()
                .Property(e => e.Status)
                .HasConversion<string>();

            builder.Entity<AssignmentGrade>()
                .Property(e => e.GradingStatus)
                .HasConversion<string>();

            builder.Entity<FinalCourseGrade>()
                .Property(e => e.GradingStatus)
                .HasConversion<string>();

            builder.Entity<FinalCourseGrade>()
                .Property(e => e.ResultStatus)
                .HasConversion<string>();

            builder.Entity<MessageThread>()
                .Property(e => e.ThreadType)
                .HasConversion<string>();

            builder.Entity<MessageThread>()
                .Property(e => e.ThreadStatus)
                .HasConversion<string>();

            builder.Entity<Message>()
                .Property(e => e.MessageStatus)
                .HasConversion<string>();

            builder.Entity<MessageAuditLog>()
                .Property(e => e.ActionType)
                .HasConversion<string>();

            builder.Entity<Notification>()
                .Property(e => e.NotificationType)
                .HasConversion<string>();

            builder.Entity<Notification>()
                .Property(e => e.Status)
                .HasConversion<string>();

            builder.Entity<LecturerProfile>()
                .Property(e => e.Gender)
                .HasConversion<string>();

            builder.Entity<StudentProfile>()
                .Property(e => e.Gender)
                .HasConversion<string>();
        }
    }
}
