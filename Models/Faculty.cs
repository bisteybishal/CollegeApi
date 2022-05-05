using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeInformation.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        
        [Required]
        public string FacultyName { get; set; }
        public string Description { get; set; }
        public int CollegeId { get; set; }
        public College College { get; set; }
        public  ICollection<Student> Students { get; set; }
    }
}
