using UniManage.Models;

namespace UniManage.Repository
{
    public interface IDepartmentRepository
    {
        Department AddNewDepartment(Department department);
        Department UpdateDepartment(Department department);
        List<Department> GetAllDepartments();
        Department GetDepartmentById(long id);
        Department GetDepartmentByGuid(string guid);  
        bool DeleteDepartment(long id);               
    }
}