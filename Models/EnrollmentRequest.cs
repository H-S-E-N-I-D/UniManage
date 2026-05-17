using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    public enum EnrollmentRequestStatus
    {
        PENDING,
        APPROVED,
        REJECTED,
        WAITLISTED
    }

    /// <summary>
    /// Maps to the <c>enrollment_requests</c> table.
    /// Captures a student's application to enroll in a <see cref="CourseOffering"/>
    /// before it is approved and converted to an <see cref="Enrollment"/>.
    /// </summary>
    [Table("enrollment_requests")]
    public class EnrollmentRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public long OfferingId { get; set; }

        /// <summary>
        /// FK to <see cref="ApplicationUser"/> — the applying student's user ID.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string StudentId { get; set; } = string.Empty;

        public DateTime? RequestDate { get; set; }

        public EnrollmentRequestStatus? Status { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(OfferingId))]
        public virtual CourseOffering? CourseOffering { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual ApplicationUser? Student { get; set; }

        public virtual ICollection<EnrollmentRequestDocument> Documents { get; set; } = [];
        public virtual ICollection<Enrollment> Enrollments { get; set; } = [];
    }
}
