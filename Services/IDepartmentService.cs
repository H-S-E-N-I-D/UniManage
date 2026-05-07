using UniManage.Models;

namespace UniManage.Services
{
    public interface IDepartmentService
    {
        DepartmentVo AddNewDepartment(DepartmentVo department);
        DepartmentVo UpdateDepartment(DepartmentVo department);
        List<DepartmentVo> GetAllDepartments();
        DepartmentVo GetDepartmentById(long id);
        DepartmentVo GetDepartmentByGuid(string guid);
        bool DeleteDepartment(long id);
    }
}
