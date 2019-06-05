using Data;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    public class StudentController : ApiController
    {
        private readonly StudentService _studentService = new StudentService(new EClassroomDataContext());
        private readonly CourseService _courseService = new CourseService(new EClassroomDataContext());

        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Checkout(CheckoutModel model)
        {
            try
            {
                List<Course> courses = _courseService.GetCoursesByNames(model.CourseModels.Select(x => x.CourseName).ToList());               

                return Ok(_studentService.Checkout(courses, model.StudentEmail));
            }
            catch(Exception)
            {
                return BadRequest();
            }            
        }

        public IHttpActionResult GetSelectedCourses(string currentUserEmail)
        {
            var student = _studentService.GetStudentByEmail(currentUserEmail);

            if(student == null)
            {
                return BadRequest();
            }

            return Ok(_courseService.GetCoursesForStudent(student));
        }

    }
}
