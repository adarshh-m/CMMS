using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class EventSchemaController : ODataController
    {
        private readonly CmmsContext _context;

        public EventSchemaController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<EventSchema> Get()
        {
            return _context.Set<EventSchema>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var eventSchema = await _context.Set<EventSchema>().FindAsync(key);
            if (eventSchema == null)
            {
                return NotFound();
            }
            return Ok(eventSchema);
        }

        public async Task<IActionResult> Post([FromBody] EventSchema eventSchema)
        {
            

            _context.Set<EventSchema>().Add(eventSchema);
            await _context.SaveChangesAsync();

            return Created(eventSchema);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] EventSchema eventSchema)
        {
            
            if (key != eventSchema.EventSchemaId)
            {
                return BadRequest();
            }

            _context.Entry(eventSchema).State = EntityState.Modified;

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

            return Updated(eventSchema);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<EventSchema> delta)
        {
            

            var eventSchema = await _context.Set<EventSchema>().FindAsync(key);
            if (eventSchema == null)
            {
                return NotFound();
            }

            delta.Patch(eventSchema);

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

            return Updated(eventSchema);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var eventSchema = await _context.Set<EventSchema>().FindAsync(key);
            if (eventSchema == null)
            {
                return NotFound();
            }

            _context.Set<EventSchema>().Remove(eventSchema);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<EventSchema>().Any(e => e.EventSchemaId == key);
        }
    }
}