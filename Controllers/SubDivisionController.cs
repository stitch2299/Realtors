using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realtors.DataContext;

namespace Realtors.Controllers
{
    [Produces("application/json")]
    [Route("api/SubDivision")]
    public class SubDivisionController : Controller
    {
        private ApplicationContext _context;

        public SubDivisionController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/SubDivision
        [HttpGet]
        public async Task<IActionResult> GetTable()
        {
            var result = await _context.SubDivisions.Select(x => new { x.Id, x.Name }).ToListAsync();
            return Ok(result);

        }
    }
}
