using CourseProvider.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProvider.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CourseEntity> Courses { get; set; }
    }
}
