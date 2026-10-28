using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
namespace YourNamespace.Controllers
{
    public class BreakdownCauseController : ODataController
    {
        private readonly CmmsContext _context;

        public BreakdownCauseController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<BreakdownCause> Get()
        {
            return _context.Set<BreakdownCause>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var breakdownCause = await _context.Set<BreakdownCause>().FindAsync(key);
            if (breakdownCause == null)
            {
                return NotFound();
            }
            return Ok(breakdownCause);
        }

        public async Task<IActionResult> Post([FromBody] BreakdownCause breakdownCause)
        {
           

            _context.Set<BreakdownCause>().Add(breakdownCause);
            await _context.SaveChangesAsync();

            return Created(breakdownCause);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] BreakdownCause update)
        {
            

            if (key != update.BreakdownCauseId)
            {
                return BadRequest();
            }

            _context.Entry(update).State = EntityState.Modified;

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

            return Updated(update);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<BreakdownCause> patch)
        {
            

            var breakdownCause = await _context.Set<BreakdownCause>().FindAsync(key);
            if (breakdownCause == null)
            {
                return NotFound();
            }

            patch.Patch(breakdownCause);

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

            return Updated(breakdownCause);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var breakdownCause = await _context.Set<BreakdownCause>().FindAsync(key);
            if (breakdownCause == null)
            {
                return NotFound();
            }

            _context.Set<BreakdownCause>().Remove(breakdownCause);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<BreakdownCause>().Count(e => e.BreakdownCauseId == key) > 0;
        }
    }
}