using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>lecturer_profiles</c> table.
    /// Inherits shared identity fields from <see cref="UserProfile"/>.
    /// </summary>
    [Table("lecturer_profiles")]
    public class LecturerProfile : UserProfile
    {
        /// <summary>
        /// Unique staff/employee number.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string StaffNumber { get; set; }

        /// <summary>
        /// Foreign key to the <c>departments</c> table.
        /// </summary>
        [Required]
        public long DepartmentId { get; set; }

        [MaxLength(100)]
        public string? Designation { get; set; }

        /// <summary>
        /// Academic specialisation area (e.g. "Machine Learning", "Civil Engineering").
        /// </summary>
        [MaxLength(255)]
        public string? Specialisation { get; set; }

        public Gender? Gender { get; set; }

        // Navigation property
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department? Department { get; set; }
    }
}
