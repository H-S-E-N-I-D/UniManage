using UniManage.Models;

namespace UniManage.Mappers
{
    public static class CourseMapper
    {
        public static CourseVo ToVo(Course course)
        {
            ArgumentNullException.ThrowIfNull(course);

            return new CourseVo
            {
                Id = course.Id,
                Guid = course.Guid,
                Title = course.Title,
                Description = course.Description,
                CourseCode = course.CourseCode,
                Duration = course.Duration,
                DepartmentId = course.DepartmentId,
                IsActive = course.IsActive,

                // Map nested Department only if loaded (avoid null ref on lazy/eager loading)
                Department = course.Department is not null
                                ? DepartmentMapper.ToVo(course.Department)
                                : null!
            };
        }

        public static Course ToEntity(CourseVo vo)
        {
            ArgumentNullException.ThrowIfNull(vo);

            return new Course
            {
                Id = vo.Id,
                Guid = vo.Guid,
                Title = vo.Title,
                Description = vo.Description,
                CourseCode = vo.CourseCode,
                Duration = vo.Duration,
                DepartmentId = vo.DepartmentId,
                IsActive = vo.IsActive
                // Department navigation property intentionally omitted —
                // EF Core resolves it via DepartmentId foreign key
            };
        }

        public static void ApplyUpdates(CourseVo vo, Course entity)
        {
            ArgumentNullException.ThrowIfNull(vo);
            ArgumentNullException.ThrowIfNull(entity);

            entity.Title = vo.Title;
            entity.Description = vo.Description;
            entity.CourseCode = vo.CourseCode;
            entity.Duration = vo.Duration;
            entity.DepartmentId = vo.DepartmentId;
            entity.IsActive = vo.IsActive;
            // Guid, CreatedAt, UpdatedAt intentionally excluded —
            // Guid is immutable after creation, timestamps are DB-managed
        }

        public static List<CourseVo> ToVoList(IEnumerable<Course> courses)
        {
            ArgumentNullException.ThrowIfNull(courses);

            return courses.Select(ToVo).ToList();
        }
    }
}