using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>modules</c> table.
    /// Represents an individual academic module that can be assigned to courses.
    /// </summary>
    [Table("modules")]
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // PK is not auto-incremented in schema
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Unique module code (e.g. "CS101").
        /// </summary>
        [MaxLength(20)]
        public string? ModuleCode { get; set; }

        public int? NumberOfCredits { get; set; }

        /// <summary>
        /// Duration of the module expressed in weeks.
        /// </summary>
        [Column(TypeName = "decimal(3,1)")]
        public decimal? DurationWeeks { get; set; }

        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<CourseModule> CourseModules { get; set; } = new List<CourseModule>();
        public virtual ICollection<SemesterModule> SemesterModules { get; set; } = new List<SemesterModule>();
    }
}
