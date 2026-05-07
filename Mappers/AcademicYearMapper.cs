using UniManage.Models;

namespace UniManage.Mappers
{
    public static class AcademicYearMapper
    {
        public static AcademicYearVo ToVo(AcademicYear academicYear)
        {
            ArgumentNullException.ThrowIfNull(academicYear);

            return new AcademicYearVo
            {
                Id = academicYear.Id,
                Guid = academicYear.Guid,
                YearLabel = academicYear.YearLabel,
                StartDate = academicYear.StartDate,
                EndDate = academicYear.EndDate,
                IsActive = academicYear.IsActive,
            };
        }

        public static AcademicYear ToEntity(AcademicYearVo vo)
        {
            ArgumentNullException.ThrowIfNull(vo);

            return new AcademicYear
            {
                Id = vo.Id,
                Guid = vo.Guid,
                YearLabel = vo.YearLabel,
                StartDate = vo.StartDate,
                EndDate = vo.EndDate,
                IsActive = vo.IsActive
                // CreatedAt and UpdatedAt intentionally omitted — DB managed
            };
        }

        public static void ApplyUpdates(AcademicYearVo vo, AcademicYear entity)
        {
            ArgumentNullException.ThrowIfNull(vo);
            ArgumentNullException.ThrowIfNull(entity);

            entity.YearLabel = vo.YearLabel;
            entity.StartDate = vo.StartDate;
            entity.EndDate = vo.EndDate;
            entity.IsActive = vo.IsActive;
            // Guid, CreatedAt, UpdatedAt intentionally excluded —
            // Guid is immutable after creation, timestamps are DB-managed
        }

        public static List<AcademicYearVo> ToVoList(IEnumerable<AcademicYear> academicYears)
        {
            ArgumentNullException.ThrowIfNull(academicYears);

            return academicYears.Select(ToVo).ToList();
        }
    }
}