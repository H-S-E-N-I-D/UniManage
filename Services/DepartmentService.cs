using UniManage.Mappers;
using UniManage.Models;
using UniManage.Repository;

namespace UniManage.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;


        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository
                ?? throw new ArgumentNullException(nameof(departmentRepository));
        }

        public DepartmentVo AddNewDepartment(DepartmentVo departmentVo)
        {
            ArgumentNullException.ThrowIfNull(departmentVo);

            var entity = DepartmentMapper.ToEntity(departmentVo);
            var created = _departmentRepository.AddNewDepartment(entity);

            return DepartmentMapper.ToVo(created);
        }

        public DepartmentVo UpdateDepartment(DepartmentVo departmentVo)
        {
            ArgumentNullException.ThrowIfNull(departmentVo);

            // Fetch the existing entity to confirm it exists before updating
            var existing = _departmentRepository.GetDepartmentById(departmentVo.Id);

            DepartmentMapper.ApplyUpdates(departmentVo, existing);

            var updated = _departmentRepository.UpdateDepartment(existing);

            return DepartmentMapper.ToVo(updated);
        }

        public List<DepartmentVo> GetAllDepartments()
        {
            return _departmentRepository
                .GetAllDepartments()
                .Select(DepartmentMapper.ToVo)
                .ToList();
        }

        public DepartmentVo GetDepartmentById(long id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            return DepartmentMapper.ToVo(department);
        }

        public DepartmentVo GetDepartmentByGuid(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentException("GUID must not be null or empty.", nameof(guid));

            var department = _departmentRepository.GetDepartmentByGuid(guid);
            return DepartmentMapper.ToVo(department);
        }

        public bool DeleteDepartment(long id)
        {
            return _departmentRepository.DeleteDepartment(id);
        }
    }
}