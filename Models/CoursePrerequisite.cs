using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    [Table("course_prerequisites")]
    public class CoursePrerequisite
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("guid")]
        [StringLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        [Column("prerequisite_name")]
        [StringLength(250)]
        public string PrerequisiteName { get; set; } = string.Empty;

        [Column("course_id")]
        public long? CourseId { get; set; }

        // Navigation property (Many-to-One)
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }


        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
