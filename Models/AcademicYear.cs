using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>academic_year</c> table.
    /// Represents a named academic year period (e.g. "2025/2026").
    /// </summary>
    [Table("academic_year")]
    public class AcademicYear
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(225)]
        public string Guid { get; set; } = string.Empty;

        /// <summary>
        /// Human-readable label, e.g. "2025/2026". Must be unique.
        /// </summary>
        [Required]
        [MaxLength(45)]
        public string YearLabel { get; set; } = string.Empty;

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Semester> Semesters { get; set; } = [];
    }
}
