using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realtors.DataContext;
using Realtors.Models;

namespace Realtors.Controllers
{
    [Produces("application/json")]
    [Route("api/Realtor")]
    public class RealtorController : Controller
    {
        private ApplicationContext _context;

        public RealtorController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTable()
        {
            var result = await (from realtor in _context.Realtors
                                join subDivision in _context.SubDivisions
                                on realtor.SubDivision equals subDivision.Id
                                select new
                                {
                                    id = realtor.Id,
                                    guid = realtor.Guid,
                                    lastName = realtor.LastName,
                                    firstName = realtor.FirstName,
                                    subDivision = subDivision.Name,
                                    registrationDate = realtor.RegistrationDate
                                }).ToListAsync();

            return Ok(result);
        }

        [Route("/GetDateInterval")]
        [HttpGet]
        public async Task<IActionResult> GetDateInterval()
        {
            var result = await (from realtor in _context.Realtors
                                group realtor by true into r
                                select new
                                {
                                    min = r.Min(z => z.RegistrationDate),
                                    max = r.Max(z => z.RegistrationDate)
                                }).ToListAsync();;
            return Ok(result);
        }


        [HttpGet("{id}", Name = "GetRealtor")]
        public async Task<IActionResult> GetRealtor(int id)
        {
            var result = await _context.Realtors.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> SaveRealtor([FromBody]Realtor value)
        {
            _context.Realtors.Add(value);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRealtor([FromBody]Realtor value)
        {
            _context.Realtors.Update(value);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealtor(int id)
        {
            var itemToRemove = await _context.Realtors.SingleOrDefaultAsync(x => x.Id == id);
            _context.Realtors.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
