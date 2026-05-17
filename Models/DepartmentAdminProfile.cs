using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>department_admin_profiles</c> table.
    /// Inherits shared identity fields from <see cref="UserProfile"/>.
    /// </summary>
    [Table("department_admin_profiles")]
    public class DepartmentAdminProfile : UserProfile
    {
        /// <summary>
        /// Foreign key to the <c>departments</c> table.
        /// </summary>
        [Required]
        public long DepartmentId { get; set; }

        /// <summary>
        /// Unique staff/employee number.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string StaffNumber { get; set; }

        [MaxLength(100)]
        public string? Designation { get; set; }

        // Navigation property
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department? Department { get; set; }
    }
}
