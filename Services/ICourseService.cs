using UniManage.Models;

namespace UniManage.Services
{
    public interface ICourseService
    {
        CourseVo AddNewCourse(CourseVo course);
        CourseVo UpdateCourse(CourseVo course);
        List<CourseVo> GetAllCourses();
        CourseVo GetCourseById(long id);
        CourseVo GetCourseByGuid(string guid);
        bool DeleteCourse(long id);
    }
}
