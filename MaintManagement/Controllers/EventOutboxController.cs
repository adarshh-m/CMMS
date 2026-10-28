using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Controllers
{
    //[ODataRoutePrefix("EventOutbox")]
    public class EventOutboxController : ODataController
    {
        private readonly CmmsContext _context;

        public EventOutboxController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_context.Set<EventOutbox>());
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public async Task<IActionResult> Get([FromRoute] Guid key)
        {
            var entity = await _context.Set<EventOutbox>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventOutbox entity)
        {
            
            _context.Set<EventOutbox>().Add(entity);
            await _context.SaveChangesAsync();

            return Created(entity);
        }

        [HttpPut("{key}")]
        public async Task<IActionResult> Put( Guid key, [FromBody] EventOutbox entity)
        {
            
            if (key != entity.EventOutboxId)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

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

        [HttpPatch("{key}")]
        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<EventOutbox> patch)
        {
            
            var entity = await _context.Set<EventOutbox>().FindAsync(key);
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

        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete([FromRoute] Guid key)
        {
            var entity = await _context.Set<EventOutbox>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<EventOutbox>().Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Exists(Guid key)
        {
            return _context.Set<EventOutbox>().Any(e => e.EventOutboxId == key);
        }
    }

    
}