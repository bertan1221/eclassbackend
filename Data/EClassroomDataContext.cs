using Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data
{
    public class EClassroomDataContext : DbContext, IDbContext
    {
        public new Database Database { get; private set; }

        public EClassroomDataContext() : base("EClassroomDataContext")
        {
            Database.SetInitializer<EClassroomDataContext>(null);
        }

        #region Entities

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }

        #endregion Entities


        public Database GetDatabase()
        {
            return this.Database;
        }

        public new DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return (new EClassroomDataContext().Entry(entity) as DbEntityEntry<T>);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
