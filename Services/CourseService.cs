using UniManage.Mappers;
using UniManage.Models;
using UniManage.Repository;

namespace UniManage.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;


        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository
                ?? throw new ArgumentNullException(nameof(courseRepository));
        }

        public CourseVo AddNewCourse(CourseVo courseVo)
        {
            ArgumentNullException.ThrowIfNull(courseVo);

            try
            {
                var entity = CourseMapper.ToEntity(courseVo);

                if (entity == null)
                    throw new InvalidOperationException("Course mapping failed while creating a new course.");

                var createdEntity = _courseRepository.AddNewCourse(entity);

                if (createdEntity == null)
                    throw new InvalidOperationException("Course creation failed. Repository returned null.");

                return CourseMapper.ToVo(createdEntity);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while adding the course.", ex);
            }
        }


        public CourseVo UpdateCourse(CourseVo courseVo)
        {
            ArgumentNullException.ThrowIfNull(courseVo);

            try
            {
                var existingEntity = _courseRepository.GetCourseById(courseVo.Id);

                if (existingEntity == null)
                    throw new KeyNotFoundException($"Course with ID '{courseVo.Id}' was not found.");

                CourseMapper.ApplyUpdates(courseVo, existingEntity);

                var updatedEntity = _courseRepository.UpdateCourse(existingEntity);

                if (updatedEntity == null)
                    throw new InvalidOperationException("Course update failed. Repository returned null.");

                return CourseMapper.ToVo(updatedEntity);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while updating course ID '{courseVo.Id}'.", ex);
            }
        }



        public List<CourseVo> GetAllCourses()
        {
            try
            {
                var courses = _courseRepository.GetAllCourses();

                if (courses == null)
                    return new List<CourseVo>();

                return courses
                    .Select(CourseMapper.ToVo)
                    .Where(course => course != null)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving courses.", ex);
            }
        }


        public CourseVo GetCourseById(long id)
        {
            if (id <= 0)
                throw new ArgumentException("Course ID must be greater than zero.", nameof(id));

            try
            {
                var course = _courseRepository.GetCourseById(id);

                if (course == null)
                    throw new KeyNotFoundException($"Course with ID '{id}' was not found.");

                return CourseMapper.ToVo(course);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while retrieving course ID '{id}'.", ex);
            }
        }

        public CourseVo GetCourseByGuid(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentException("Course GUID must not be null or empty.", nameof(guid));

            try
            {
                var course = _courseRepository.GetCourseByGuid(guid);

                if (course == null)
                    throw new KeyNotFoundException($"Course with GUID '{guid}' was not found.");

                return CourseMapper.ToVo(course);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while retrieving course GUID '{guid}'.", ex);
            }
        }

        public bool DeleteCourse(long id)
        {
            if (id <= 0)
                throw new ArgumentException("Course ID must be greater than zero.", nameof(id));

            try
            {
                var existingCourse = _courseRepository.GetCourseById(id);

                if (existingCourse == null)
                    throw new KeyNotFoundException($"Course with ID '{id}' was not found.");

                return _courseRepository.DeleteCourse(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while deleting course ID '{id}'.", ex);
            }
        }
    }
}