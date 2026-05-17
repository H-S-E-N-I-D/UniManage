using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    public enum AssignmentStatus
    {
        DRAFT,
        PUBLISHED,
        CLOSED,
        ARCHIVED
    }

    /// <summary>
    /// Maps to the <c>assignments</c> table.
    /// An assessed task published within a <see cref="SemesterModule"/>.
    /// </summary>
    [Table("assignments")]
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public long SemesterModuleId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [MaxLength(200)]
        public string? FileName { get; set; }

        [Required]
        [MaxLength(225)]
        public string FilePath { get; set; } = string.Empty;

        /// <summary>
        /// FK to <see cref="ApplicationUser"/> — the creator's user ID.
        /// </summary>
        [Required]
        [MaxLength(225)]
        public string CreatedBy { get; set; } = string.Empty;

        public string? Instructions { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal? TotalMarks { get; set; }

        public DateTime? OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public bool AllowLateSubmission { get; set; } = false;

        /// <summary>
        /// Comma-separated allowed file extensions, e.g. "pdf,doc,docx".
        /// </summary>
        [MaxLength(100)]
        public string? AllowedFileTypes { get; set; }

        public int? MaxFileSizeMb { get; set; }

        public AssignmentStatus? Status { get; set; } = AssignmentStatus.DRAFT;

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(SemesterModuleId))]
        public virtual SemesterModule? SemesterModule { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public virtual ApplicationUser? Creator { get; set; }

        public virtual ICollection<AssignmentSubmission> Submissions { get; set; } = [];
    }
}
