using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class BreakdownPreventiveActionController : ODataController
    {
        private readonly CmmsContext _context;

        public BreakdownPreventiveActionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<BreakdownPreventiveAction> Get()
        {
            return _context.Set<BreakdownPreventiveAction>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<BreakdownPreventiveAction>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] BreakdownPreventiveAction breakdownPreventiveAction)
        {
           

            _context.Set<BreakdownPreventiveAction>().Add(breakdownPreventiveAction);
            await _context.SaveChangesAsync();

            return Created(breakdownPreventiveAction);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] BreakdownPreventiveAction breakdownPreventiveAction)
        {
            

            if (key != breakdownPreventiveAction.PreventiveActionId)
            {
                return BadRequest();
            }

            _context.Entry(breakdownPreventiveAction).State = EntityState.Modified;

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

            return Updated(breakdownPreventiveAction);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<BreakdownPreventiveAction> patch)
        {
            

            var entity = await _context.Set<BreakdownPreventiveAction>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

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

            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var entity = await _context.Set<BreakdownPreventiveAction>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<BreakdownPreventiveAction>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<BreakdownPreventiveAction>().Count(e => e.PreventiveActionId == key) > 0;
        }
    }
}