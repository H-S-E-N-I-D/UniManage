using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>semester_modules</c> table.
    /// Assigns a <see cref="Module"/> to a <see cref="Semester"/> and optionally
    /// designates the lecturing <see cref="ApplicationUser"/>.
    /// </summary>
    [Table("semester_modules")]
    public class SemesterModule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // PK not auto-incremented in schema
        public long Id { get; set; }

        [MaxLength(255)]
        public string? Guid { get; set; }

        [Required]
        public long SemesterId { get; set; }

        [Required]
        public long ModuleId { get; set; }

        /// <summary>
        /// FK to <see cref="ApplicationUser"/> — the assigned lecturer's user ID.
        /// </summary>
        [MaxLength(255)]
        public string? LecturerId { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(SemesterId))]
        public virtual Semester? Semester { get; set; }

        [ForeignKey(nameof(ModuleId))]
        public virtual Module? Module { get; set; }

        [ForeignKey(nameof(LecturerId))]
        public virtual ApplicationUser? Lecturer { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; } = [];
        public virtual ICollection<CourseMaterial> CourseMaterials { get; set; } = [];
    }
}
