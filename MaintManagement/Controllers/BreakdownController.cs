using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;


namespace YourNamespace.Controllers
{
    public class BreakdownController : ODataController
    {
        private readonly CmmsContext _context;

        public BreakdownController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Breakdown> Get()
        {
            return _context.Set<Breakdown>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var breakdown = await _context.Set<Breakdown>().FindAsync(key);
            if (breakdown == null)
            {
                return NotFound();
            }
            return Ok(breakdown);
        }

        public async Task<IActionResult> Post([FromBody] Breakdown breakdown)
        {
            

            _context.Set<Breakdown>().Add(breakdown);
            await _context.SaveChangesAsync();

            return Created(breakdown);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] Breakdown breakdown)
        {
            

            if (key != breakdown.BreakdownId)
            {
                return BadRequest();
            }

            _context.Entry(breakdown).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(breakdown);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Breakdown> patch)
        {
            

            var breakdown = await _context.Set<Breakdown>().FindAsync(key);
            if (breakdown == null)
            {
                return NotFound();
            }

            patch.Patch(breakdown);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(breakdown);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var breakdown = await _context.Set<Breakdown>().FindAsync(key);
            if (breakdown == null)
            {
                return NotFound();
            }

            _context.Set<Breakdown>().Remove(breakdown);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Breakdown>().Count(e => e.BreakdownId == key) > 0;
        }
    }
}