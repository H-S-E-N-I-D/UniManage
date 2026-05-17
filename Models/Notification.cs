using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    public enum NotificationType
    {
        system,
        email,
        sms
    }

    public enum NotificationStatus
    {
        pending,
        queued,
        sent,
        delivered,
        failed,
        read
    }

    /// <summary>
    /// Maps to the <c>notifications</c> table.
    /// Stores all outbound notifications (system, email, SMS) dispatched to users.
    /// Note: <see cref="Id"/> is a string (GUID/UUID) — not numeric — as per the schema.
    /// Note: there is no FK constraint to <c>users</c> in the schema; the navigation
    /// property is mapped via the <see cref="UserId"/> shadow property.
    /// </summary>
    [Table("notifications")]
    public class Notification
    {
        /// <summary>
        /// String primary key (UUID) — assigned by the application before insert.
        /// </summary>
        [Key]
        [MaxLength(255)]
        public string Id { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public NotificationType NotificationType { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Subject { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? RecipientEmail { get; set; }

        [MaxLength(20)]
        public string? RecipientPhone { get; set; }

        [Required]
        public NotificationStatus Status { get; set; } = NotificationStatus.pending;

        [MaxLength(50)]
        public string? ReferenceType { get; set; }

        public ulong? ReferenceId { get; set; }

        [Required]
        public bool IsRead { get; set; } = false;

        public DateTime? ReadAt { get; set; }

        public DateTime? SentAt { get; set; }

        public DateTime? ScheduledAt { get; set; }

        public string? FailureReason { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser? User { get; set; }
    }
}
