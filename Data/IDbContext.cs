using Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Data
{
    public interface IDbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Database GetDatabase();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<Teacher> Teachers { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<CourseTeacher> CourseTeachers { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<CourseStudent> CourseStudents { get; set; }
    }
}
