using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>assignment_submissions</c> table.
    /// Represents a student's file submission against an <see cref="Assignment"/>.
    /// </summary>
    [Table("assignment_submissions")]
    public class AssignmentSubmission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public long AssignmentId { get; set; }

        /// <summary>
        /// FK to <see cref="ApplicationUser"/> — the submitting student's user ID.
        /// </summary>
        [Required]
        [MaxLength(225)]
        public string StudentId { get; set; } = string.Empty;

        public DateTime? SubmittedAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [MaxLength(225)]
        public string FilePath { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? FileType { get; set; }

        public string? SubmissionNotes { get; set; }

        public bool? IsLate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(AssignmentId))]
        public virtual Assignment? Assignment { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual ApplicationUser? Student { get; set; }

        public virtual ICollection<AssignmentGrade> Grades { get; set; } = [];
    }
}
