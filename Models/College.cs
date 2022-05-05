using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeInformation.Models
{
    public class College
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Faculty> Faculties { get; set; }// college have many faculities
       
        public ICollection<Student> Students  { get; set; }// college have many students
    }
}
