using Data;
using Entities;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[Authorize]
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

        //[HttpPost]
        //public IHttpActionResult Checkout(CheckoutModel model)
        //{
        //    try
        //    {
        //        List<Course> courses = _courseService.GetCoursesByNames(model.items.Select(x => x.title).ToList());               

        //        return Ok(_studentService.Checkout(courses, model.StudentEmail));
        //    }
        //    catch(Exception)
        //    {
        //        return BadRequest();
        //    }            
        //}

        public IHttpActionResult GetSelectedCourses(string currentUserEmail)
        {
            var student = _studentService.GetStudentByEmail(currentUserEmail);

            if (student == null)
            {
                return BadRequest();
            }

            return Ok(_courseService.GetCoursesForStudent(student));
        }

        [HttpPost]
        public IHttpActionResult ShopCart()
        {
            var request = Request.Content;
            var bodyString = Request.Content.ReadAsStringAsync().Result;
            //using (StreamReader reader = new StreamReader(request))
            //{
            //    bodyString = reader.ReadToEnd();
            //}
            var deserializedJson = JsonConvert.DeserializeObject<CheckoutModel>(bodyString);
            List<Course> courses = _courseService.GetCoursesByNames(deserializedJson.items.Select(x => x.title).ToList());
            var newCourses = deserializedJson.items.Where(x => !courses.Select(y => y.Name)
            .ToList().Contains(x.title)).Select(x => new Course()
            {
                Id = x.id,
                Name = x.title,
                Price = x.price
            }).ToList();

            return Ok(_studentService.Checkout(courses, newCourses, deserializedJson.StudentEmail));
        }

    }
}
