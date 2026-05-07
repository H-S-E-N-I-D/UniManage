using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    [Table("academic_year")]
    public class AcademicYear
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("guid")]
        [StringLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        [Column("year_label")]
        [StringLength(200)]
        public string YearLabel { get; set; } = string.Empty;

        [Required]
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
