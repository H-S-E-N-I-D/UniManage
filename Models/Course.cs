using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>courses</c> table.
    /// Represents a degree or diploma programme offered by a department.
    /// </summary>
    [Table("courses")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public long DepartmentId { get; set; }

        public string? Description { get; set; }

        /// <summary>
        /// Unique short code, e.g. "BSc-CS". Nullable — assigned after creation.
        /// </summary>
        [MaxLength(20)]
        public string? CourseCode { get; set; }

        /// <summary>
        /// Duration expressed in years (e.g. 3.0, 3.5).
        /// </summary>
        [Column(TypeName = "decimal(3,1)")]
        public decimal? Duration { get; set; }

        public long? ProgramLevelId { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department? Department { get; set; }

        [ForeignKey(nameof(ProgramLevelId))]
        public virtual ProgramLevel? ProgramLevel { get; set; }

        public virtual ICollection<CourseModule> CourseModules { get; set; } = [];
        public virtual ICollection<CourseOffering> CourseOfferings { get; set; } = [];
        public virtual ICollection<CoursePrerequisite> CoursePrerequisites { get; set; } = [];
    }
}
