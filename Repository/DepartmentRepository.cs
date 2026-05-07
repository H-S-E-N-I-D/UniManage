using Microsoft.EntityFrameworkCore;
using UniManage.Data;
using UniManage.Models;

namespace UniManage.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Department AddNewDepartment(Department department)
        {
            ArgumentNullException.ThrowIfNull(department);

            department.Guid = System.Guid.NewGuid().ToString();

            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();

            return department;
        }

        public Department UpdateDepartment(Department department)
        {
            ArgumentNullException.ThrowIfNull(department);

            var existing = _dbContext.Departments.Find(department.Id)
                ?? throw new KeyNotFoundException($"Department with ID {department.Id} was not found.");

            existing.Name = department.Name;
            existing.Description = department.Description;
            existing.IsActive = department.IsActive;

            _dbContext.SaveChanges();

            return existing;
        }

        public List<Department> GetAllDepartments()
        {
            return _dbContext.Departments
                .AsNoTracking()
                .ToList();
        }

        public Department GetDepartmentById(long id)
        {
            return _dbContext.Departments
                .AsNoTracking()
                .FirstOrDefault(d => d.Id == id)
                ?? throw new KeyNotFoundException($"Department with ID {id} was not found.");
        }

        public Department GetDepartmentByGuid(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentException("GUID must not be null or empty.", nameof(guid));

            return _dbContext.Departments
                .AsNoTracking()
                .FirstOrDefault(d => d.Guid == guid)
                ?? throw new KeyNotFoundException($"Department with GUID '{guid}' was not found.");
        }

        public bool DeleteDepartment(long id)
        {
            var department = _dbContext.Departments.Find(id);

            if (department is null)
                return false;

            _dbContext.Departments.Remove(department);
            _dbContext.SaveChanges();

            return true;
        }
    }
}