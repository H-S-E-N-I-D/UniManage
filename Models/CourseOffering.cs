using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    public enum CourseOfferingStatus
    {
        PLANNED,
        OPEN,
        CLOSED,
        CANCELLED,
        COMPLETED
    }

    /// <summary>
    /// Maps to the <c>course_offerings</c> table.
    /// Represents a specific intake / run of a <see cref="Course"/> with capacity
    /// and enrolment window information.
    /// </summary>
    [Table("course_offerings")]
    public class CourseOffering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public long CourseId { get; set; }

        public CourseOfferingStatus? CourseStatus { get; set; }

        public int? MaxCapacity { get; set; }

        public DateTime? EnrolmentsStartDate { get; set; }

        public DateTime? EnrolmentsEndDate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CourseId))]
        public virtual Course? Course { get; set; }

        public virtual ICollection<Semester> Semesters { get; set; } = [];
        public virtual ICollection<EnrollmentRequest> EnrollmentRequests { get; set; } = [];
        public virtual ICollection<Enrollment> Enrollments { get; set; } = [];
        public virtual ICollection<FinalCourseGrade> FinalCourseGrades { get; set; } = [];
    }
}
