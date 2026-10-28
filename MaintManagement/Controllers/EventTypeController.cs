using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class EventTypeController : ODataController
    {
        private readonly CmmsContext db;

        public EventTypeController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<EventType> Get()
        {
            return db.EventTypes;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            EventType eventType = await db.EventTypes.FindAsync(key);
            if (eventType == null)
            {
                return NotFound();
            }
            return Ok(eventType);
        }

        public async Task<IActionResult> Post([FromBody] EventType eventType)
        {
           
            db.EventTypes.Add(eventType);
            await db.SaveChangesAsync();

            return Created(eventType);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] EventType eventType)
        {
           
            if (key != eventType.EventTypeId)
            {
                return BadRequest();
            }

            db.Entry(eventType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(eventType);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<EventType> delta)
        {
           
            EventType eventType = await db.EventTypes.FindAsync(key);
            if (eventType == null)
            {
                return NotFound();
            }

            delta.Patch(eventType);

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(eventType);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            EventType eventType = await db.EventTypes.FindAsync(key);
            if (eventType == null)
            {
                return NotFound();
            }

            db.EventTypes.Remove(eventType);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.EventTypes.Count(e => e.EventTypeId == key) > 0;
        }
    }
}