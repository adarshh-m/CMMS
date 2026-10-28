using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
 
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 

namespace YourNamespace.Controllers
{
    public class BreakdownCorrectiveActionController : ODataController
    {
        private readonly CmmsContext _context;

        public BreakdownCorrectiveActionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<BreakdownCorrectiveAction> Get()
        {
            return _context.Set<BreakdownCorrectiveAction>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<BreakdownCorrectiveAction>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] BreakdownCorrectiveAction breakdownCorrectiveAction)
        {
            

            _context.Set<BreakdownCorrectiveAction>().Add(breakdownCorrectiveAction);
            await _context.SaveChangesAsync();

            return Created(breakdownCorrectiveAction);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] BreakdownCorrectiveAction breakdownCorrectiveAction)
        {
           

            if (key != breakdownCorrectiveAction.CorrectiveActionId)
            {
                return BadRequest();
            }

            _context.Entry(breakdownCorrectiveAction).State = EntityState.Modified;

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

            return Updated(breakdownCorrectiveAction);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<BreakdownCorrectiveAction> patch)
        {
            

            var entity = await _context.Set<BreakdownCorrectiveAction>().FindAsync(key);
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
            var entity = await _context.Set<BreakdownCorrectiveAction>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<BreakdownCorrectiveAction>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<BreakdownCorrectiveAction>().Count(e => e.CorrectiveActionId == key) > 0;
        }
    }
}