using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Base class for all user profile types. Maps to the shared fields
    /// common across department_admin_profiles, student_profiles,
    /// system_admin_profiles, and lecturer_profiles.
    /// </summary>
    public abstract class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [MaxLength(10)]
        public string? Title { get; set; }

        public DateTime? JoinedDate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual Users? User { get; set; }

        // Computed helper
        [NotMapped]
        public string FullName => $"{Title} {FirstName} {LastName}".Trim();
    }
}
