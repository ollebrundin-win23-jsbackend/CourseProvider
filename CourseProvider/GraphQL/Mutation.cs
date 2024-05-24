using CourseProvider.Entities;
using CourseProvider.Services;
using HotChocolate.Authorization;

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
        [Authorize]

        public async Task<CourseEntity> CreateCourseAsync([Service]CourseService service, CourseEntity entity) //Istället för dependency injection i konstruktorn, så bör man använda detta sättet för att injecta en service i Hotchocolate GraphQL. Annars blir det problem med vårt DbContext
        {
            return await service.CreateCourseAsync(entity);
        }

        [GraphQLName("updateCourse")]
        [Authorize]

        public async Task<CourseEntity> UpdateCourseAsync([Service] CourseService service, CourseEntity entity)
        {
            return await service.UpdateCourseAsync(entity);
        }

        [GraphQLName("deleteCourse")]
        [Authorize]

        public async Task<bool> DeleteCourseAsync([Service] CourseService service, int id)
        {
            return await service.DeleteCourseAsync(id);
        }
    }
}
