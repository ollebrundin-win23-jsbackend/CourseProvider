using CourseProvider.Entities;
using CourseProvider.Services;

namespace CourseProvider.GraphQL
{
    public class Mutation
    {
        //private readonly CourseService _service;

        //public Mutation(CourseService service)
        //{
        //    _service = service;
        //}

        [GraphQLName("createCourse")]

        public async Task<CourseEntity> CreateCourseAsync([Service]CourseService service, CourseEntity entity)
        {
            return await service.CreateCourseAsync(entity);
        }

        [GraphQLName("updateCourse")]

        public async Task<CourseEntity> UpdateCourseAsync([Service] CourseService service, CourseEntity entity)
        {
            return await service.UpdateCourseAsync(entity);
        }

        [GraphQLName("deleteCourse")]

        public async Task<bool> DeleteCourseAsync([Service] CourseService service, int id)
        {
            return await service.DeleteCourseAsync(id);
        }
    }
}
