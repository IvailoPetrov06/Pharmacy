using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly PharmacyContext _context;

        public BatchesController(PharmacyContext context)
        {
            _context = context;
        }

        // GET: api/Batches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatch()
        {
          if (_context.Batch == null)
          {
              return NotFound();
          }
            return await _context.Batch.ToListAsync();
        }

        // GET: api/Batches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Batch>> GetBatch(int id)
        {
          if (_context.Batch == null)
          {
              return NotFound();
          }
            var batch = await _context.Batch.FindAsync(id);

            if (batch == null)
            {
                return NotFound();
            }

            return batch;
        }

        // PUT: api/Batches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatch(int id, Batch batch)
        {
            if (id != batch.Id)
            {
                return BadRequest();
            }

            _context.Entry(batch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchExists(id))
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

        // POST: api/Batches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Batch>> PostBatch(Batch batch)
        {
          if (_context.Batch == null)
          {
              return Problem("Entity set 'PharmacyContext.Batch'  is null.");
          }
            _context.Batch.Add(batch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatch", new { id = batch.Id }, batch);
        }

        // DELETE: api/Batches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            if (_context.Batch == null)
            {
                return NotFound();
            }
            var batch = await _context.Batch.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }

            _context.Batch.Remove(batch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BatchExists(int id)
        {
            return (_context.Batch?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
