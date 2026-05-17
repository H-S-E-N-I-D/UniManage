using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    public enum MessageStatus
    {
        SENT,
        DELIVERED,
        EDITED,
        DELETED
    }

    /// <summary>
    /// Maps to the <c>messages</c> table.
    /// An individual message posted within a <see cref="MessageThread"/>.
    /// </summary>
    [Table("messages")]
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public long ThreadId { get; set; }

        /// <summary>FK to <see cref="ApplicationUser"/> — who sent the message.</summary>
        [MaxLength(255)]
        public string? SenderUserId { get; set; }

        /// <summary>FK to <see cref="ApplicationUser"/> — intended recipient.</summary>
        [MaxLength(255)]
        public string? ReceiverUserId { get; set; }

        public string? MessageBody { get; set; }

        public DateTime? SentAt { get; set; }

        public MessageStatus? MessageStatus { get; set; }

        public DateTime? EditedAt { get; set; }

        /// <summary>
        /// Stored as varchar(45) in schema — kept as string to match column type.
        /// </summary>
        [MaxLength(45)]
        public string? DeletedAt { get; set; }

        [MaxLength(255)]
        public string? DeletedBy { get; set; }

        [MaxLength(255)]
        public string? EditedBy { get; set; }

        // Navigation properties
        [ForeignKey(nameof(ThreadId))]
        public virtual MessageThread? Thread { get; set; }

        [ForeignKey(nameof(SenderUserId))]
        public virtual ApplicationUser? Sender { get; set; }

        [ForeignKey(nameof(ReceiverUserId))]
        public virtual ApplicationUser? Receiver { get; set; }

        public virtual ICollection<MessageAttachment> Attachments { get; set; } = [];
        public virtual ICollection<MessageAuditLog> AuditLogs { get; set; } = [];
    }
}
