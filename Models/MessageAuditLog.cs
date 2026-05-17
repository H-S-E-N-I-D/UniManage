using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    public enum MessageActionType
    {
        THREAD_CREATED,
        THREAD_UPDATED,
        MESSAGE_SENT,
        MESSAGE_EDITED,
        MESSAGE_READ,
        THREAD_ARCHIVED,
        THREAD_UNARCHIVED,
        THREAD_DELETED,
        ATTACHMENT_UPLOADED,
        ATTACHMENT_DELETED
    }

    /// <summary>
    /// Maps to the <c>message_audit_logs</c> table.
    /// Records a tamper-evident history of actions performed on threads and messages.
    /// </summary>
    [Table("message_audit_logs")]
    public class MessageAuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long ThreadId { get; set; }

        [Required]
        public long MessageId { get; set; }

        /// <summary>FK to <see cref="ApplicationUser"/> — who performed the action.</summary>
        [MaxLength(255)]
        public string? UserId { get; set; }

        [Required]
        public MessageActionType ActionType { get; set; }

        [MaxLength(500)]
        public string? ActionDescription { get; set; }

        [MaxLength(50)]
        public string? IpAddress { get; set; }

        [MaxLength(500)]
        public string? UserAgent { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey(nameof(ThreadId))]
        public virtual MessageThread? Thread { get; set; }

        [ForeignKey(nameof(MessageId))]
        public virtual Message? Message { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser? User { get; set; }
    }
}
