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
    public class FacultyController : ControllerBase
    {
        private readonly Studentcontext _context;

        public FacultyController(Studentcontext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Faculty faculty)
        {
          await  _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
            return (StatusCode(StatusCodes.Status200OK));
        }
        [HttpGet]
        //public async Task<IActionResult> GetFaculty()
        //{
        //    var faculty = await (_context.faculties.ToListAsync());
        //    return Ok(faculty);
        //}
        [HttpGet]
        public async Task<IActionResult> GetFaculty()
        {
            var facultys = await (from faculty in _context.Faculties
                                  select new
                                  {
                                      Id=faculty.Id,
                                      FacultyName = faculty.FacultyName,
                                      Description = faculty.Description,
                                      CollegeId=faculty.CollegeId
                                  }).ToListAsync();
            return Ok(facultys);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> FacultyDetails(int id)
        {
            var faculty = await (_context.Faculties.Include(x => x.College)
                       .Where(x => x.Id == id).FirstOrDefaultAsync());
            return Ok(faculty);
        }

    }
}
