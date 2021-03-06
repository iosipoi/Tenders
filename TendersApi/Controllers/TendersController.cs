using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TendersApi.Data;
using TendersApi.Model;

namespace TendersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TendersController : ControllerBase
    {
        private readonly TendersApiContext _context;

        public TendersController(TendersApiContext context)
        {
            _context = context;
        }

        // GET: api/Tenders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tender>>> GetTender()
        {
            return await _context.Tender.ToListAsync();
        }

        // GET: api/Tenders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tender>> GetTender(int id)
        {
            var tender = await _context.Tender.FindAsync(id);

            if (tender == null)
            {
                return NotFound();
            }

            return tender;
        }

        // PUT: api/Tenders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTender(int id, Tender tender)
        {
            if (id != tender.Id)
            {
                return BadRequest();
            }

            _context.Entry(tender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenderExists(id))
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

        // POST: api/Tenders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tender>> PostTender(Tender tender)
        {
            _context.Tender.Add(tender);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTender", new { id = tender.Id }, tender);
        }

        // DELETE: api/Tenders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tender>> DeleteTender(int id)
        {
            var tender = await _context.Tender.FindAsync(id);
            if (tender == null)
            {
                return NotFound();
            }

            _context.Tender.Remove(tender);
            await _context.SaveChangesAsync();

            return tender;
        }

        private bool TenderExists(int id)
        {
            return _context.Tender.Any(e => e.Id == id);
        }
    }
}
