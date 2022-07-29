using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trading.Models;

namespace Trading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WireModelsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WireModelsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/WireModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WireModel>>> GetWires()
        {
          if (_context.Wires == null)
          {
              return NotFound();
          }
            return await _context.Wires.ToListAsync();
        }

        // GET: api/WireModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WireModel>> GetWireModel(int id)
        {
          if (_context.Wires == null)
          {
              return NotFound();
          }
            var wireModel = await _context.Wires.FindAsync(id);

            if (wireModel == null)
            {
                return NotFound();
            }

            return wireModel;
        }

        // PUT: api/WireModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWireModel(int id, WireModel wireModel)
        {
            if (id != wireModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(wireModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WireModelExists(id))
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

        // POST: api/WireModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WireModel>> PostWireModel(WireModel wireModel)
        {
          if (_context.Wires == null)
          {
              return Problem("Entity set 'DatabaseContext.Wires'  is null.");
          }
            _context.Wires.Add(wireModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWireModel", new { id = wireModel.Id }, wireModel);
        }

        // DELETE: api/WireModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWireModel(int id)
        {
            if (_context.Wires == null)
            {
                return NotFound();
            }
            var wireModel = await _context.Wires.FindAsync(id);
            if (wireModel == null)
            {
                return NotFound();
            }

            _context.Wires.Remove(wireModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WireModelExists(int id)
        {
            return (_context.Wires?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
