using CourseProvider.Entities;
using CourseProvider.Services;

namespace CourseProvider.GraphQL
{
    public class Mutation
    {
        private readonly CourseService _service;

        public Mutation(CourseService service)
        {
            _service = service;
        }

        [GraphQLName("createCourse")]

        public async Task<CourseEntity> CreateCourseAsync(CourseEntity entity)
        {
            return await _service.CreateCourseAsync(entity);
        }

        [GraphQLName("updateCourse")]

        public async Task<CourseEntity> UpdateCourseAsync(CourseEntity entity)
        {
            return await _service.UpdateCourseAsync(entity);
        }

        [GraphQLName("deleteCourse")]

        public async Task<bool> DeleteCourseAsync(int id)
        {
            return await _service.DeleteCourseAsync(id);
        }
    }
}
