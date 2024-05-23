using CourseProvider.Entities;
using CourseProvider.Services;

namespace CourseProvider.GraphQL
{
    public class Query
    {
        private readonly CourseService _service;

        public Query(CourseService service)
        {
            _service = service;
        }

        [GraphQLName("getCourse")]

        public async Task<CourseEntity> GetCourseAsync(int id)
        {
            return await _service.GetCourseAsync(id);
        }

        [GraphQLName("getAllCourses")]

        public async Task<IEnumerable<CourseEntity>> GetAllCoursesAsync()
        {
            return await _service.GetAllCoursesAsync();
        }
    }
}
