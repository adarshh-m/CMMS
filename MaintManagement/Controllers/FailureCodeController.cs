using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class FailureCodeController : ODataController
    {
        private readonly CmmsContext _context;

        public FailureCodeController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<FailureCode> Get()
        {
            return _context.Set<FailureCode>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var failureCode = await _context.Set<FailureCode>().FindAsync(key);
            if (failureCode == null)
            {
                return NotFound();
            }
            return Ok(failureCode);
        }

        public async Task<IActionResult> Post([FromBody] FailureCode failureCode)
        {
           
            _context.Set<FailureCode>().Add(failureCode);
            await _context.SaveChangesAsync();

            return Created(failureCode);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] FailureCode update)
        {
           
            if (key != update.FailureCodeId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<FailureCode> patch)
        {
           
            var failureCode = await _context.Set<FailureCode>().FindAsync(key);
            if (failureCode == null)
            {
                return NotFound();
            }

            patch.Patch(failureCode);

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

            return Updated(failureCode);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var failureCode = await _context.Set<FailureCode>().FindAsync(key);
            if (failureCode == null)
            {
                return NotFound();
            }

            _context.Set<FailureCode>().Remove(failureCode);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<FailureCode>().Count(e => e.FailureCodeId == key) > 0;
        }
    }

    
}