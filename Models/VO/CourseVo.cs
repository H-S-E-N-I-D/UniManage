namespace UniManage.Models
{
    public class CourseVo
    {

        public long Id { get; set; }
        public string Guid { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string CourseCode { get; set; } = string.Empty;

        public Decimal Duration { get; set; }

        public long? DepartmentId { get; set; }

        public virtual DepartmentVo Department { get; set; }

        public bool IsActive { get; set; }
    }
}
