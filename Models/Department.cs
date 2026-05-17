using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>departments</c> table.
    /// Represents a university department that owns courses and staff profiles.
    /// </summary>
    [Table("departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Course> Courses { get; set; } = [];
        public virtual ICollection<LecturerProfile> LecturerProfiles { get; set; } = [];
        public virtual ICollection<DepartmentAdminProfile> DepartmentAdminProfiles { get; set; } = [];
    }
}
