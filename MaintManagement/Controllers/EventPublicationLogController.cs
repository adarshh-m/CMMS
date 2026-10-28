using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class EventPublicationLogController : ODataController
    {
        private readonly CmmsContext _context;

        public EventPublicationLogController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<EventPublicationLog> Get()
        {
            return _context.Set<EventPublicationLog>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<EventPublicationLog>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] EventPublicationLog eventPublicationLog)
        {
            
            _context.Set<EventPublicationLog>().Add(eventPublicationLog);
            await _context.SaveChangesAsync();

            return Created(eventPublicationLog);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] EventPublicationLog eventPublicationLog)
        {
           
            if (key != eventPublicationLog.EventPublicationLogId)
            {
                return BadRequest();
            }

            _context.Entry(eventPublicationLog).State = EntityState.Modified;

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

            return Updated(eventPublicationLog);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<EventPublicationLog> patch)
        {
            
            var entity = await _context.Set<EventPublicationLog>().FindAsync(key);
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
            var entity = await _context.Set<EventPublicationLog>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<EventPublicationLog>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<EventPublicationLog>().Count(e => e.EventPublicationLogId == key) > 0;
        }
    }
}