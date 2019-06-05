using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public double Price { get; set; }
    }
}
