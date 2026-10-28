using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class EventBatchController : ODataController
    {
        private readonly CmmsContext _context;

        public EventBatchController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<EventBatch> Get()
        {
            return _context.Set<EventBatch>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var eventBatch = await _context.Set<EventBatch>().FindAsync(key);
            if (eventBatch == null)
            {
                return NotFound();
            }
            return Ok(eventBatch);
        }

        public async Task<IActionResult> Post([FromBody] EventBatch eventBatch)
        {
            
            _context.Set<EventBatch>().Add(eventBatch);
            await _context.SaveChangesAsync();

            return Created(eventBatch);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] EventBatch eventBatch)
        {
            
            if (key != eventBatch.EventBatchId)
            {
                return BadRequest();
            }

            _context.Entry(eventBatch).State = EntityState.Modified;

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

            return Updated(eventBatch);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<EventBatch> patch)
        {
            
            var eventBatch = await _context.Set<EventBatch>().FindAsync(key);
            if (eventBatch == null)
            {
                return NotFound();
            }

            patch.Patch(eventBatch);

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

            return Updated(eventBatch);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var eventBatch = await _context.Set<EventBatch>().FindAsync(key);
            if (eventBatch == null)
            {
                return NotFound();
            }

            _context.Set<EventBatch>().Remove(eventBatch);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<EventBatch>().Count(e => e.EventBatchId == key) > 0;
        }
    }

    
}