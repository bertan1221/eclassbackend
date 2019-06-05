using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CourseTeacher
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
