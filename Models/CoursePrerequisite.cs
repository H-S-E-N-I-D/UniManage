using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>course_prerequisites</c> table.
    /// Associates a <see cref="Course"/> with a required <see cref="Prerequisite"/>.
    /// </summary>
    [Table("course_prerequisites")]
    public class CoursePrerequisite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public long CourseId { get; set; }

        [Required]
        public long PrerequisiteId { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CourseId))]
        public virtual Course? Course { get; set; }

        [ForeignKey(nameof(PrerequisiteId))]
        public virtual Prerequisite? Prerequisite { get; set; }
    }
}
