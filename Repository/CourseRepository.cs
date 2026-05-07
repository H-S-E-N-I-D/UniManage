using Microsoft.EntityFrameworkCore;
using UniManage.Data;
using UniManage.Models;

namespace UniManage.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;

        public CourseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Course AddNewCourse(Course course)
        {
            ArgumentNullException.ThrowIfNull(course);

            course.Guid = System.Guid.NewGuid().ToString();

            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            return course;
        }

        public Course UpdateCourse(Course course)
        {
            ArgumentNullException.ThrowIfNull(course);

            var existing = _dbContext.Courses.Find(course.Id)
                ?? throw new KeyNotFoundException($"Course with ID {course.Id} was not found.");

            existing.Title = course.Title;
            existing.Description = course.Description;
            existing.Duration = course.Duration;
            existing.CourseCode = course.CourseCode;
            existing.IsActive = course.IsActive;

            _dbContext.SaveChanges();

            return existing;
        }

        public List<Course> GetAllCourses()
        {
            return _dbContext.Courses.Where(c => c.IsActive == true)
                .AsNoTracking()
                .ToList();
        }

        public Course GetCourseById(long id)
        {
            return _dbContext.Courses
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id)
                ?? throw new KeyNotFoundException($"Course with ID {id} was not found.");
        }

        public Course GetCourseByGuid(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentException("GUID must not be null or empty.", nameof(guid));

            return _dbContext.Courses
                .AsNoTracking()
                .FirstOrDefault(c => c.Guid == guid)
                ?? throw new KeyNotFoundException($"Course with GUID '{guid}' was not found.");
        }

        public bool DeleteCourse(long id)
        {
            var Course = _dbContext.Courses.Find(id);

            if (Course is null)
                return false;

            _dbContext.Courses.Remove(Course);
            _dbContext.SaveChanges();

            return true;
        }
    }
}