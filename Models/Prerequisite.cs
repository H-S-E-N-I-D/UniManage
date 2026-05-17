using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>prerequisites</c> table.
    /// Represents an entry-requirement or prerequisite condition that can be
    /// associated with one or more courses via <see cref="CoursePrerequisite"/>.
    /// </summary>
    [Table("prerequisites")]
    public class Prerequisite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual ICollection<CoursePrerequisite> CoursePrerequisites { get; set; } = new List<CoursePrerequisite>();
    }
}
