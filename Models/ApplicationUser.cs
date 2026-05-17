using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>users</c> table.
    /// Extends ASP.NET Core Identity's <see cref="IdentityUser"/> with a <c>FullName</c> field.
    /// All other user-specific profile data lives in the role-specific profile tables.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Full display name stored directly on the identity record.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        // Navigation properties — profile tables (one-to-one)
        public virtual StudentProfile? StudentProfile { get; set; }
        public virtual LecturerProfile? LecturerProfile { get; set; }
        public virtual DepartmentAdminProfile? DepartmentAdminProfile { get; set; }
        public virtual SystemAdminProfile? SystemAdminProfile { get; set; }

        // Navigation properties — audit & notifications
        public virtual ICollection<AuditLog> AuditLogs { get; set; } = [];
        public virtual ICollection<Notification> Notifications { get; set; } = [];

        // Navigation properties — messaging
        public virtual ICollection<MessageThread> CreatedThreads { get; set; } = [];
        public virtual ICollection<MessageThread> StudentThreads { get; set; } = [];
        public virtual ICollection<MessageThread> LecturerThreads { get; set; } = [];
        public virtual ICollection<Message> SentMessages { get; set; } = [];
        public virtual ICollection<Message> ReceivedMessages { get; set; } = [];
        public virtual ICollection<MessageAuditLog> MessageAuditLogs { get; set; } = [];

        // Navigation properties — academic
        public virtual ICollection<SemesterModule> TaughtSemesterModules { get; set; } = [];
        public virtual ICollection<Assignment> CreatedAssignments { get; set; } = [];
        public virtual ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = [];
        public virtual ICollection<AssignmentGrade> GradedAssignments { get; set; } = [];
        public virtual ICollection<CourseMaterial> UploadedMaterials { get; set; } = [];
        public virtual ICollection<EnrollmentRequest> EnrollmentRequests { get; set; } = [];
        public virtual ICollection<Enrollment> Enrollments { get; set; } = [];

        // Navigation properties — final grades (unconstrained FKs)
        public virtual ICollection<FinalCourseGrade> FinalizedGrades { get; set; } = [];
        public virtual ICollection<FinalCourseGrade> PublishedGrades { get; set; } = [];
    }
}
