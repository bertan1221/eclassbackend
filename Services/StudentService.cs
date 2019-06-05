using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StudentService
    {
        private readonly IDbContext _dbContext;

        public StudentService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student GetStudentById(int id)
        {
            return _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();
        }

        public Student GetStudentByEmail(string email)
        {
            return _dbContext.Students.Where(x => x.Email.Equals(email)).FirstOrDefault();
        }

        public List<Student> GetStudents()
        {
            return _dbContext.Students.ToList();
        }

        public void InsertStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _dbContext.Students.AddOrUpdate(student);
            _dbContext.SaveChanges();
        }

        public void RemoveStudent(Student student)
        {
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }

        public bool Checkout(List<Course> courses, string StudentEmail)
        {
            var student = _dbContext.Students.FirstOrDefault(x => x.Email.ToLower() == StudentEmail.ToLower());

            if(student == null)
            {
                return false;
            }

            foreach (var course in courses)
            {
                var courseStudent = new CourseStudent()
                {
                    CourseId = course.Id,
                    StudentId = student.Id
                };

                _dbContext.CourseStudents.Add(courseStudent);
            }

            return true;
        }
    }
}
