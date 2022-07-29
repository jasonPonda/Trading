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
    public class TradeModelsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TradeModelsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TradeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeModel>>> GetTrades()
        {
          if (_context.Trades == null)
          {
              return NotFound();
          }
            return await _context.Trades.ToListAsync();
        }

        // GET: api/TradeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TradeModel>> GetTradeModel(int id)
        {
          if (_context.Trades == null)
          {
              return NotFound();
          }
            var tradeModel = await _context.Trades.FindAsync(id);

            if (tradeModel == null)
            {
                return NotFound();
            }

            return tradeModel;
        }

        // PUT: api/TradeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeModel(int id, TradeModel tradeModel)
        {
            if (id != tradeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(tradeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeModelExists(id))
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

        // POST: api/TradeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TradeModel>> PostTradeModel(TradeModel tradeModel)
        {
          if (_context.Trades == null)
          {
              return Problem("Entity set 'DatabaseContext.Trades'  is null.");
          }
            _context.Trades.Add(tradeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTradeModel", new { id = tradeModel.Id }, tradeModel);
        }

        // DELETE: api/TradeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeModel(int id)
        {
            if (_context.Trades == null)
            {
                return NotFound();
            }
            var tradeModel = await _context.Trades.FindAsync(id);
            if (tradeModel == null)
            {
                return NotFound();
            }

            _context.Trades.Remove(tradeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TradeModelExists(int id)
        {
            return (_context.Trades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
