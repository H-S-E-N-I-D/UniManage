using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>program_levels</c> table.
    /// Represents an academic programme level (e.g. "Undergraduate", "Postgraduate", "HND").
    /// Courses reference this via <see cref="Course.ProgramLevelId"/>.
    /// </summary>
    [Table("program_levels")]
    public class ProgramLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // PK is not auto-incremented in schema
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
