using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>course_modules</c> table.
    /// Join entity linking a <see cref="Course"/> to its constituent <see cref="Module"/>s.
    /// The schema defines only <c>course_id</c> as the PK, but the intent is a composite key;
    /// configure this in <c>OnModelCreating</c> via:
    /// <code>
    ///   modelBuilder.Entity&lt;CourseModule&gt;()
    ///       .HasKey(cm => new { cm.CourseId, cm.ModuleId });
    /// </code>
    /// </summary>
    [Table("course_modules")]
    public class CourseModule
    {
        [Required]
        public long CourseId { get; set; }

        [Required]
        public long ModuleId { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CourseId))]
        public virtual Course? Course { get; set; }

        [ForeignKey(nameof(ModuleId))]
        public virtual Module? Module { get; set; }
    }
}
