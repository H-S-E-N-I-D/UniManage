using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    public enum ResultStatus
    {
        PASS,
        FAIL,
        INCOMPLETE,
        PENDING
    }

    /// <summary>
    /// Maps to the <c>final_course_grades</c> table.
    /// Records the overall result for a student's <see cref="Enrollment"/> in a
    /// <see cref="CourseOffering"/>.
    /// Note: <see cref="FinalizedBy"/> and <see cref="PublishedBy"/> reference
    /// <see cref="ApplicationUser"/> but have no FK constraints in the schema;
    /// navigation properties are included for convenience and should be configured
    /// with <c>.HasPrincipalKey</c> / <c>.IsRequired(false)</c> in <c>OnModelCreating</c>.
    /// </summary>
    [Table("final_course_grades")]
    public class FinalCourseGrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public long EnrollmentId { get; set; }

        [Required]
        public long CourseOfferingId { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal? MarksObtained { get; set; }

        [MaxLength(5)]
        public string? LetterGrade { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal? GradePoint { get; set; }

        public ResultStatus? ResultStatus { get; set; }

        public GradingStatus? GradingStatus { get; set; }

        public string? Remarks { get; set; }

        /// <summary>
        /// User ID of the staff member who finalized this grade (no FK constraint in schema).
        /// </summary>
        [MaxLength(225)]
        public string? FinalizedBy { get; set; }

        public DateTime? FinalizedAt { get; set; }

        /// <summary>
        /// User ID of the staff member who published this grade (no FK constraint in schema).
        /// </summary>
        [MaxLength(225)]
        public string? PublishedBy { get; set; }

        public DateTime? PublishedAt { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(EnrollmentId))]
        public virtual Enrollment? Enrollment { get; set; }

        [ForeignKey(nameof(CourseOfferingId))]
        public virtual CourseOffering? CourseOffering { get; set; }

        [ForeignKey(nameof(FinalizedBy))]
        public virtual ApplicationUser? Finalizer { get; set; }

        [ForeignKey(nameof(PublishedBy))]
        public virtual ApplicationUser? Publisher { get; set; }
    }
}
