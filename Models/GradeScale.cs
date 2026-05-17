using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>grade_scale</c> table.
    /// Defines the mark-range to letter-grade mapping used institution-wide.
    /// Note: PK is a non-auto-increment <c>int</c> — assign IDs externally.
    /// </summary>
    [Table("grade_scale")]
    public class GradeScale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string LetterGrade { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal MinMark { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal MaxMark { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal? GradePoint { get; set; }

        public string? Description { get; set; }

        public bool? IsPass { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
