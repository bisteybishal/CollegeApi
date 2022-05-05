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
    public class CollegeController : ControllerBase
    {
        private readonly Studentcontext _context;

        public CollegeController(Studentcontext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] College college)
        {
            await _context.Colleges.AddAsync(college);
            await _context.SaveChangesAsync();
            return (StatusCode(StatusCodes.Status200OK));
        }
        [HttpGet]
        public async Task<IActionResult> GetCollege()
        {
            var coleges = await (from colege in _context.Colleges
                                 select new
                                 {
                                     Id=colege.Id,
                                     Name = colege.Name,
                                     Address = colege.Address,
                                     ImagePath = colege.ImagePath,
                                     
                                 }).ToListAsync();
            return Ok(coleges);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> CollegeDetails(int id)
        {
            var colege = await (_context.Colleges.Where(x => x.Id == id)
                .FirstOrDefaultAsync());
            return Ok(colege);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchCollege(string query)
        {
            var colege = await (from college in _context.Colleges
                                where college.Name.StartsWith(query)
                                select new
                                {

                                    Id = college.Id,
                                    Name = college.Name,
                                    Address = college.Address,
                                    ImagePath = college.ImagePath,
                                    
                                }).ToListAsync();
            return Ok(colege);
        }
       
    }
}
