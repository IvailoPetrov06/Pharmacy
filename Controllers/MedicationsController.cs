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
    public class MedicationsController : ControllerBase
    {
        private readonly PharmacyContext _context;

        public MedicationsController(PharmacyContext context)
        {
            _context = context;
        }

        // GET: api/Medications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetMedication()
        {
          if (_context.Medication == null)
          {
              return NotFound();
          }
            return await _context.Medication.ToListAsync();
        }

        // GET: api/Medications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetMedication(int id)
        {
          if (_context.Medication == null)
          {
              return NotFound();
          }
            var medication = await _context.Medication.FindAsync(id);

            if (medication == null)
            {
                return NotFound();
            }

            return medication;
        }

        // PUT: api/Medications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedication(int id, Medication medication)
        {
            if (id != medication.Id)
            {
                return BadRequest();
            }

            _context.Entry(medication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationExists(id))
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

        // POST: api/Medications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medication>> PostMedication(Medication medication)
        {
          if (_context.Medication == null)
          {
              return Problem("Entity set 'PharmacyContext.Medication'  is null.");
          }
            _context.Medication.Add(medication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedication", new { id = medication.Id }, medication);
        }

        // DELETE: api/Medications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedication(int id)
        {
            if (_context.Medication == null)
            {
                return NotFound();
            }
            var medication = await _context.Medication.FindAsync(id);
            if (medication == null)
            {
                return NotFound();
            }

            _context.Medication.Remove(medication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicationExists(int id)
        {
            return (_context.Medication?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
