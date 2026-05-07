namespace UniManage.Models
{
    public class AcademicYearVo
    {
        public long Id { get; set; }
        public string Guid { get; set; } = string.Empty;
        public string YearLabel { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
