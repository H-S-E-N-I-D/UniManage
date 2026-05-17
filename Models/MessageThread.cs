using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    public enum ThreadType
    {
        STUDENT_TO_LECTURER,
        LECTURER_TO_STUDENT
    }

    public enum ThreadStatus
    {
        OPEN,
        CLOSED,
        ARCHIVED
    }

    /// <summary>
    /// Maps to the <c>message_threads</c> table.
    /// Represents a conversation thread between a student and a lecturer.
    /// </summary>
    [Table("message_threads")]
    public class MessageThread
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(255)]
        public string? Guid { get; set; }

        [MaxLength(150)]
        public string? Subject { get; set; }

        /// <summary>FK to <see cref="ApplicationUser"/> — who initiated the thread.</summary>
        [MaxLength(255)]
        public string? CreatedBy { get; set; }

        public ThreadType? ThreadType { get; set; }

        public ThreadStatus? ThreadStatus { get; set; }

        /// <summary>
        /// Stored as varchar(45) in schema — kept as string to match column type.
        /// </summary>
        [MaxLength(45)]
        public string? LastMessageAt { get; set; }

        /// <summary>FK to <see cref="ApplicationUser"/> — the student participant.</summary>
        [MaxLength(255)]
        public string? StudentId { get; set; }

        /// <summary>FK to <see cref="ApplicationUser"/> — the lecturer participant.</summary>
        [MaxLength(255)]
        public string? LecturerId { get; set; }

        [MaxLength(255)]
        public string? ClosedBy { get; set; }

        public DateTime? ClosedAt { get; set; }

        [MaxLength(255)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        [MaxLength(255)]
        public string? ArchivedBy { get; set; }

        public DateTime? ArchivedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CreatedBy))]
        public virtual ApplicationUser? Creator { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual ApplicationUser? Student { get; set; }

        [ForeignKey(nameof(LecturerId))]
        public virtual ApplicationUser? Lecturer { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = [];
        public virtual ICollection<MessageAuditLog> AuditLogs { get; set; } = [];
    }
}
