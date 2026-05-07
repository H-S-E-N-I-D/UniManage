using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    [Table("departments")]
    public class Department
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("guid")]
        [StringLength(255)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
