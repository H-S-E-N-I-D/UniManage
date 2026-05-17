using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>system_admin_profiles</c> table.
    /// Inherits shared identity fields from <see cref="UserProfile"/>.
    /// </summary>
    [Table("system_admin_profiles")]
    public class SystemAdminProfile : UserProfile
    {
        /// <summary>
        /// Unique staff/employee number.
        /// </summary>
        [MaxLength(20)]
        public string? StaffNumber { get; set; }

        [MaxLength(100)]
        public string? Designation { get; set; }
    }
}
