using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React_InvestApp.Models;

namespace React_InvestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactAppsController : ControllerBase
    {
        private readonly react_investContext _context;

        public ReactAppsController(react_investContext context)
        {
            _context = context;
        }

        // GET: api/ReactApps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReactApp>>> GetReactApps()
        {
            return await _context.ReactApps.ToListAsync();
        }

        // GET: api/ReactApps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReactApp>> GetReactApp(int id)
        {
            var reactApp = await _context.ReactApps.FindAsync(id);

            if (reactApp == null)
            {
                return NotFound();
            }

            return reactApp;
        }

        // PUT: api/ReactApps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReactApp(int id, ReactApp reactApp)
        {
            if (id != reactApp.Id)
            {
                return BadRequest();
            }

            _context.Entry(reactApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReactAppExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReactApps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReactApp>> PostReactApp(ReactApp reactApp)
        {
            _context.ReactApps.Add(reactApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReactApp", new { id = reactApp.Id }, reactApp);
        }

        // DELETE: api/ReactApps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReactApp(int id)
        {
            var reactApp = await _context.ReactApps.FindAsync(id);
            if (reactApp == null)
            {
                return NotFound();
            }

            _context.ReactApps.Remove(reactApp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReactAppExists(int id)
        {
            return _context.ReactApps.Any(e => e.Id == id);
        }
    }
}
