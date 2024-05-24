using CourseProvider.Entities;
using CourseProvider.Services;
using HotChocolate.Authorization;

namespace CourseProvider.GraphQL
{
    public class Query
    {
        //private readonly CourseService _service;

        //public Query(CourseService service)
        //{
        //    _service = service;
        //}

        [GraphQLName("getCourse")]
        [Authorize]

        public async Task<CourseEntity> GetCourseAsync([Service] CourseService service, int id)
        {
            return await service.GetCourseAsync(id);
        }

        [GraphQLName("getAllCourses")]
        [Authorize]

        public async Task<IEnumerable<CourseEntity>> GetAllCoursesAsync([Service] CourseService service)
        {
            return await service.GetAllCoursesAsync();
        }
    }
}
