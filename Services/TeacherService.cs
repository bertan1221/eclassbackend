using Data;
using Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Services
{
    public class TeacherService
    {
        private readonly IDbContext _dbContext;

        public TeacherService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Teacher GetTeacherById(int id)
        {
            return _dbContext.Teachers.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Teacher> GetTeachers()
        {
            return _dbContext.Teachers.ToList();
        }

        public void InsertCourse(Teacher teacher)
        {
            _dbContext.Teachers.Add(teacher);
            _dbContext.SaveChanges();
        }

        public void UpdateCourse(Teacher teacher)
        {
            _dbContext.Teachers.AddOrUpdate(teacher);
            _dbContext.SaveChanges();
        }

        public void RemoveCourse(Teacher teacher)
        {
            _dbContext.Teachers.Remove(teacher);
            _dbContext.SaveChanges();
        }
    }
}
