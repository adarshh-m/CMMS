using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class EventInboxController : ODataController
    {
        private readonly CmmsContext _context;

        public EventInboxController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<EventInbox> Get()
        {
            return _context.Set<EventInbox>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<EventInbox>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] EventInbox eventInbox)
        {
            
            _context.Set<EventInbox>().Add(eventInbox);
            await _context.SaveChangesAsync();

            return Created(eventInbox);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] EventInbox eventInbox)
        {
            
            if (key != eventInbox.EventInboxId)
            {
                return BadRequest();
            }

            _context.Entry(eventInbox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
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

            return Updated(eventInbox);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<EventInbox> patch)
        {
           
            var entity = await _context.Set<EventInbox>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
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
            var entity = await _context.Set<EventInbox>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<EventInbox>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<EventInbox>().Any(e => e.EventInboxId == key);
        }
    }
}