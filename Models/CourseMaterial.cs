using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>course_materials</c> table.
    /// Represents a file resource (lecture note, PDF, video link, etc.) uploaded
    /// for a specific <see cref="SemesterModule"/>.
    /// </summary>
    [Table("course_materials")]
    public class CourseMaterial
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
        [MaxLength(255)]
        public string FilePath { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? FileType { get; set; }

        public long? FileSizeMb { get; set; }

        /// <summary>
        /// FK to <see cref="ApplicationUser"/> — the uploader's user ID.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string UploadedBy { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(SemesterModuleId))]
        public virtual SemesterModule? SemesterModule { get; set; }

        [ForeignKey(nameof(UploadedBy))]
        public virtual ApplicationUser? Uploader { get; set; }
    }
}
