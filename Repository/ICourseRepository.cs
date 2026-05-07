using UniManage.Models;

namespace UniManage.Repository
{
    public interface ICourseRepository
    {
        Course AddNewCourse(Course course);
        Course UpdateCourse(Course Course);
        List<Course> GetAllCourses();
        Course GetCourseById(long id);
        Course GetCourseByGuid(string guid);  
        bool DeleteCourse(long id);               
    }
}