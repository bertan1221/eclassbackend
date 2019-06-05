using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public string Education { get; set; }
    }
}
