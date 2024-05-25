using CourseProvider.Entities;
using CourseProvider.Repos;

namespace CourseProvider.Services
{
    public class CourseService
    {
        private readonly CourseRepo _repo;

        public CourseService(CourseRepo repo)
        {
            _repo = repo;
        }

        public async Task<CourseEntity> CreateCourseAsync(CourseEntity entity)
        {
            try
            {
                //var entity = _factory.CreateEntityFromModel(model);

                var result = await _repo.CreateAsync(entity);

                if (result)
                {
                    return entity;
                }
            }
            catch { }
            return null!;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            try
            {
                var result = await _repo.DeleteAsync(x => x.Id == id);

                if (result)
                {
                    return true;
                }
            }
            catch { }
            return false;
        }

        public async Task<CourseEntity> GetCourseAsync(int id)
        {
            try
            {
                var entity = await _repo.GetOneAsync(x => x.Id == id);

                if (entity != null)
                {
                    //var model = _factory.CreateModelFromEntity(entity);
                    return entity;
                }
            }
            catch { }
            return null!;
        }

        public async Task<IEnumerable<CourseEntity>> GetAllCoursesAsync()
        {
            try
            {
                var list = await _repo.GetAllAsync();

                if (list != null)
                {
                    return list;
                }
            }
            catch { }
            return null!;
        }

        public async Task<bool> UpdateCourseAsync(CourseEntity entity)
        {
            try
            {
                var result = await _repo.UpdateAsync(x => x.Id == entity.Id, entity);

                if (result)
                {
                    return result;
                }
            }
            catch { }
            return false;
        }
    }
}
