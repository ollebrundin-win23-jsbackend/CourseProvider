using CourseProvider.Contexts;
using CourseProvider.Entities;

namespace CourseProvider.Repos
{
    public class CourseRepo : BaseRepo<CourseEntity, DataContext>
    {
        public CourseRepo(DataContext context) : base(context)
        {
        }
    }
}
