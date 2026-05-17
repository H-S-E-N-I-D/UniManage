using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>message_attachments</c> table.
    /// A file uploaded as part of a <see cref="Message"/>.
    /// </summary>
    [Table("message_attachments")]
    public class MessageAttachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public long MessageId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string FilePath { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? FileExtension { get; set; }

        [MaxLength(100)]
        public string? MimeType { get; set; }

        public long? FileSizeKb { get; set; }

        [Required]
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey(nameof(MessageId))]
        public virtual Message? Message { get; set; }
    }
}
