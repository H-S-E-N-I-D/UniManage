namespace UniManage.Models
{
    public class DepartmentVo
    {

        public long Id { get; set; }
        public string Guid { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CourseVo> Courses { get; set; }
    }
}
