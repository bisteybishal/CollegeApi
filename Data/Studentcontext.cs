using CollegeInformation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeInformation.Data
{
    public class Studentcontext:DbContext
    {
        public Studentcontext(DbContextOptions<Studentcontext> options):base(options)
        {

        }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<College> Colleges { get; set; }


    }
}
