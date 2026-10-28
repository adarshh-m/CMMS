using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class AuditEventController : ODataController
    {
        private readonly CmmsContext _context;

        public AuditEventController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<AuditEvent> Get()
        {
            return _context.Set<AuditEvent>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( long key)
        {
            var auditEvent = await _context.Set<AuditEvent>().FindAsync(key);
            if (auditEvent == null)
            {
                return NotFound();
            }
            return Ok(auditEvent);
        }

        public async Task<IActionResult> Post([FromBody] AuditEvent auditEvent)
        {
            _context.Set<AuditEvent>().Add(auditEvent);
            await _context.SaveChangesAsync();
            return Created(auditEvent);
        }

        public async Task<IActionResult> Put( long key, [FromBody] AuditEvent auditEvent)
        {
           
            if (key != auditEvent.AuditEventId)
            {
                return BadRequest();
            }
            _context.Entry(auditEvent).State = EntityState.Modified;
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
            return Updated(auditEvent);
        }

        public async Task<IActionResult> Patch( long key, [FromBody] Delta<AuditEvent> delta)
        {
           
            var auditEvent = await _context.Set<AuditEvent>().FindAsync(key);
            if (auditEvent == null)
            {
                return NotFound();
            }
            delta.Patch(auditEvent);
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
            return Updated(auditEvent);
        }

        public async Task<IActionResult> Delete([FromBody] long key)
        {
            var auditEvent = await _context.Set<AuditEvent>().FindAsync(key);
            if (auditEvent == null)
            {
                return NotFound();
            }
            _context.Set<AuditEvent>().Remove(auditEvent);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool Exists(long key)
        {
            return _context.Set<AuditEvent>().Count(e => e.AuditEventId == key) > 0;
        }
    }
}