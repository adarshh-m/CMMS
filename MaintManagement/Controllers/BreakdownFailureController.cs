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
    public class BreakdownFailureController : ODataController
    {
        private readonly CmmsContext _context;

        public BreakdownFailureController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<BreakdownFailure> Get()
        {
            return _context.Set<BreakdownFailure>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var breakdownFailure = await _context.Set<BreakdownFailure>().FindAsync(key);
            if (breakdownFailure == null)
            {
                return NotFound();
            }
            return Ok(breakdownFailure);
        }

        public async Task<IActionResult> Post([FromBody] BreakdownFailure breakdownFailure)
        {
            

            _context.Set<BreakdownFailure>().Add(breakdownFailure);
            await _context.SaveChangesAsync();

            return Created(breakdownFailure);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] BreakdownFailure update)
        {
           

            if (key != update.BreakdownFailureId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<BreakdownFailure> patch)
        {
            

            var breakdownFailure = await _context.Set<BreakdownFailure>().FindAsync(key);
            if (breakdownFailure == null)
            {
                return NotFound();
            }

            patch.Patch(breakdownFailure);

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

            return Updated(breakdownFailure);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var breakdownFailure = await _context.Set<BreakdownFailure>().FindAsync(key);
            if (breakdownFailure == null)
            {
                return NotFound();
            }

            _context.Set<BreakdownFailure>().Remove(breakdownFailure);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<BreakdownFailure>().Count(e => e.BreakdownFailureId == key) > 0;
        }
    }
}