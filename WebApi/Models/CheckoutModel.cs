using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CheckoutModel
    {
        public List<CourseModel> CourseModels { get; set; }

        public double TotalPrice
        {
            get
            {
                return CourseModels.Sum(x => x.Price * x.Quantity);
            }
        }

        public string StudentEmail { get; set; }
    }

    public class CourseModel
    {
        public string CourseName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}