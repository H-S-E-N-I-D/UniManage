using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    public enum GradingStatus
    {
        DRAFT,
        FINALIZED,
        PUBLISHED
    }

    /// <summary>
    /// Maps to the <c>assignment_grades</c> table.
    /// Records the marks and feedback awarded to an <see cref="AssignmentSubmission"/>.
    /// </summary>
    [Table("assignment_grades")]
    public class AssignmentGrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(225)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public long SubmissionId { get; set; }

        /// <summary>
        /// FK to <see cref="ApplicationUser"/> — the grading lecturer's user ID.
        /// </summary>
        [Required]
        [MaxLength(225)]
        public string GradedBy { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal MarksAwarded { get; set; }

        [Required]
        [MaxLength(5)]
        public string LetterGrade { get; set; } = string.Empty;

        public string? Feedback { get; set; }

        public GradingStatus? GradingStatus { get; set; } = Models.GradingStatus.DRAFT;

        public DateTime? PublishedAt { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(SubmissionId))]
        public virtual AssignmentSubmission? Submission { get; set; }

        [ForeignKey(nameof(GradedBy))]
        public virtual ApplicationUser? Grader { get; set; }
    }
}
