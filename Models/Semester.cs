using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>semesters</c> table.
    /// Represents one semester within a <see cref="CourseOffering"/> for a given
    /// <see cref="AcademicYear"/>.
    /// </summary>
    [Table("semesters")]
    public class Semester
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // PK not auto-incremented in schema
        public long Id { get; set; }

        [MaxLength(255)]
        public string? Guid { get; set; }

        [Required]
        public long CourseOfferingId { get; set; }

        [Required]
        public long AcademicYearId { get; set; }

        /// <summary>
        /// Ordinal semester number within the course offering (e.g. 1, 2, 3).
        /// </summary>
        [Required]
        public byte SemesterNumber { get; set; }

        [MaxLength(50)]
        public string? SemesterName { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CourseOfferingId))]
        public virtual CourseOffering? CourseOffering { get; set; }

        [ForeignKey(nameof(AcademicYearId))]
        public virtual AcademicYear? AcademicYear { get; set; }

        public virtual ICollection<SemesterModule> SemesterModules { get; set; } = [];
    }
}
