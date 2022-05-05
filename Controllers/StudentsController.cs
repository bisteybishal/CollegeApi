using CollegeInformation.Data;
using CollegeInformation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Studentcontext _context;

        public StudentsController(Studentcontext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return (StatusCode(StatusCodes.Status200OK));
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await (from std in _context.Students
                                 select new
                                 {
                                     Id=std.Id,
                                     Name = std.Name,
                                     Address = std.Address,
                                     Gender=std.Gender,
                                     Email=std.Email,
                                     ImagePath = std.Imagepath,
                                     FacultyId = std.FacultyId,
                                     CollegeId=std.CollegeId
 
                                 }).ToListAsync();
            return Ok(students);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> StudentDetails(int id)
        {
            var std = await (_context.Students
                .Include(x=>x.Faculty)
                .Include(x => x.College)
             
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync());
            return Ok(std);
        }
           

    }
}

