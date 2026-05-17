using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    public enum EnrollmentStatus
    {
        ENROLLED,
        DROPPED,
        COMPLETED,
        FAILED,
        WITHDRAWN
    }

    /// <summary>
    /// Maps to the <c>enrollments</c> table.
    /// Created when an <see cref="EnrollmentRequest"/> is approved.
    /// Tracks the student's ongoing status in a <see cref="CourseOffering"/>.
    /// </summary>
    [Table("enrollments")]
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public long OfferingId { get; set; }

        [Required]
        public long EnrollmentRequestId { get; set; }

        /// <summary>
        /// FK to <see cref="ApplicationUser"/> — the enrolled student's user ID.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string StudentId { get; set; } = string.Empty;

        public DateTime? ApprovedDate { get; set; }

        public EnrollmentStatus? Status { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(OfferingId))]
        public virtual CourseOffering? CourseOffering { get; set; }

        [ForeignKey(nameof(EnrollmentRequestId))]
        public virtual EnrollmentRequest? EnrollmentRequest { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual ApplicationUser? Student { get; set; }

        public virtual ICollection<FinalCourseGrade> FinalCourseGrades { get; set; } = [];
    }
}
