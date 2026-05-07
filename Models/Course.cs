using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    [Table("courses")]
    public class Course
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("guid")]
        [StringLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        [Column("title")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;


        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("course_code")]
        [StringLength(200)]
        public string CourseCode { get; set; } = string.Empty;

        [Required]
        [Column("duration")]
        [StringLength(200)]
        public Decimal Duration { get; set; }

        [Column("department_id")]
        public long? DepartmentId { get; set; }

        // Navigation property (Many-to-One)
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<CoursePrerequisite> CoursePrerequisites { get; set; }

    }
}
