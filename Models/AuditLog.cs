using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>audit_logs</c> table.
    /// General-purpose application audit trail; records any user action against
    /// any entity type.
    /// </summary>
    [Table("audit_logs")]
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>FK to <see cref="ApplicationUser"/>.</summary>
        [Required]
        [MaxLength(255)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Action { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string EntityType { get; set; } = string.Empty;

        public int? EntityId { get; set; }

        public string? Details { get; set; }

        [MaxLength(45)]
        public string? IpAddress { get; set; }

        public DateTime? CreatedAt { get; set; }

        // Navigation property
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser? User { get; set; }
    }
}
