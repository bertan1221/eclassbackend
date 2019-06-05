using Data;
using Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Services
{
    public class CourseService 
    {
        private readonly IDbContext _dbContext;

        public CourseService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Course GetCourseById(int id)
        {
            return _dbContext.Courses.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Course> GetCourses()
        {
            return _dbContext.Courses.ToList();
        }

        public List<Course> GetCoursesByNames(List<string> courseNames)
        {
            return _dbContext.Courses.Where(x => courseNames.Contains(x.Name)).ToList();
        }

        public void InsertCourse(Course course)
        {
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _dbContext.Courses.AddOrUpdate(course);
            _dbContext.SaveChanges();
        }

        public void RemoveCourse(Course course)
        {
            _dbContext.Courses.Remove(course);
            _dbContext.SaveChanges();
        }

        public List<CourseStudent> GetCoursesForStudent(Student student)
        {
            return _dbContext.CourseStudents.Where(x => x.StudentId == student.Id).ToList();
        }

    }
}
