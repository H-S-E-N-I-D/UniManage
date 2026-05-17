using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>enrollment_requests_documents</c> table.
    /// Stores supporting documents attached to an <see cref="EnrollmentRequest"/>.
    /// Note: the schema uses a non-auto-increment <c>int</c> PK — assign IDs externally.
    /// </summary>
    [Table("enrollment_requests_documents")]
    public class EnrollmentRequestDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public long EnrollmentRequestId { get; set; }

        [MaxLength(45)]
        public string? FileName { get; set; }

        [MaxLength(45)]
        public string? FilePath { get; set; }

        [MaxLength(45)]
        public string? FileType { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        [ForeignKey(nameof(EnrollmentRequestId))]
        public virtual EnrollmentRequest? EnrollmentRequest { get; set; }
    }
}
