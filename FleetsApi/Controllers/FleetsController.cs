using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetsApi.Data;
using FleetsApi.Models;

namespace FleetsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetsController : ControllerBase
    {
        private readonly FleetsApiContext _context;

        public FleetsController(FleetsApiContext context)
        {
            _context = context;
        }

        // GET: api/Fleets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fleet>>> GetFleet()
        {
            return await _context.Fleet.ToListAsync();
        }

        // GET: api/Fleets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fleet>> GetFleet(Guid id)
        {
            var fleet = await _context.Fleet.FindAsync(id);

            if (fleet == null)
            {
                return NotFound();
            }

            return fleet;
        }

        // PUT: api/Fleets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFleet(Guid id, Fleet fleet)
        {
            if (id != fleet.Id)
            {
                return BadRequest();
            }

            _context.Entry(fleet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FleetExists(id))
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

        // POST: api/Fleets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fleet>> PostFleet(Fleet fleet)
        {
            _context.Fleet.Add(fleet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFleet", new { id = fleet.Id }, fleet);
        }

        // DELETE: api/Fleets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFleet(Guid id)
        {
            var fleet = await _context.Fleet.FindAsync(id);
            if (fleet == null)
            {
                return NotFound();
            }

            _context.Fleet.Remove(fleet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FleetExists(Guid id)
        {
            return _context.Fleet.Any(e => e.Id == id);
        }
    }
}
