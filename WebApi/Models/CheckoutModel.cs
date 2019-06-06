using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CheckoutModel
    {
        public List<CourseModel> items { get; set; }

        public double price
        {
            get
            {
                return items.Sum(x => x.price * x.quantity);
            }
        }

        public string StudentEmail { get; set; }
    }

    public class CourseModel
    {
        public int id { get; set; }

        public string title { get; set; }


        public string thumbnail_url { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }
    }
}