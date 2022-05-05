using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeInformation.Models
{
    public class Student
    { 
        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]

        public string Name { get; set; }
        public String Address { get; set; }
        [Required]
        public Gender Gender { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public DateTime DateofJoin { get; set; } = DateTime.Now;
        public string Imagepath { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }//one to one realtionship (assume one has one faculty only)
        public int CollegeId { get; set; }
        public College College { get; set; }//one to one realtionship( one has one college )




    }
}
