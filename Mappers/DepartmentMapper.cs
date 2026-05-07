using UniManage.Models;

namespace UniManage.Mappers
{
    public static class DepartmentMapper
    {
        public static DepartmentVo ToVo(Department department)
        {
            ArgumentNullException.ThrowIfNull(department);

            return new DepartmentVo
            {
                Id = department.Id,
                Guid = department.Guid,
                Name = department.Name,
                Description = department.Description,
                IsActive = department.IsActive,
                Courses = department.Courses is not null
                                ? CourseMapper.ToVoList(department.Courses)
                                : new List<CourseVo>()
            };
        }

        public static Department ToEntity(DepartmentVo vo)
        {
            ArgumentNullException.ThrowIfNull(vo);

            return new Department
            {
                Id = vo.Id,
                Guid = vo.Guid,
                Name = vo.Name,
                Description = vo.Description,
                IsActive = vo.IsActive
            };
        }

        public static void ApplyUpdates(DepartmentVo vo, Department entity)
        {
            ArgumentNullException.ThrowIfNull(vo);
            ArgumentNullException.ThrowIfNull(entity);

            entity.Name = vo.Name;
            entity.Description = vo.Description;
            entity.IsActive = vo.IsActive;
        }
    }
}