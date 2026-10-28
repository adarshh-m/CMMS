using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class EventReplayRequestController : ODataController
    {
        private readonly CmmsContext db;

        public EventReplayRequestController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<EventReplayRequest> Get()
        {
            return db.EventReplayRequests;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            EventReplayRequest eventReplayRequest = await db.EventReplayRequests.FindAsync(key);
            if (eventReplayRequest == null)
            {
                return NotFound();
            }
            return Ok(eventReplayRequest);
        }

        public async Task<IActionResult> Post([FromBody] EventReplayRequest eventReplayRequest)
        {
           
            db.EventReplayRequests.Add(eventReplayRequest);
            await db.SaveChangesAsync();

            return Created(eventReplayRequest);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] EventReplayRequest eventReplayRequest)
        {
            
            if (key != eventReplayRequest.EventReplayRequestId)
            {
                return BadRequest();
            }

            db.Entry(eventReplayRequest).State = EntityState.Modified;

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

            return Updated(eventReplayRequest);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<EventReplayRequest> patch)
        {
            
            EventReplayRequest eventReplayRequest = await db.EventReplayRequests.FindAsync(key);
            if (eventReplayRequest == null)
            {
                return NotFound();
            }

            patch.Patch(eventReplayRequest);

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

            return Updated(eventReplayRequest);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            EventReplayRequest eventReplayRequest = await db.EventReplayRequests.FindAsync(key);
            if (eventReplayRequest == null)
            {
                return NotFound();
            }

            db.EventReplayRequests.Remove(eventReplayRequest);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.EventReplayRequests.Count(e => e.EventReplayRequestId == key) > 0;
        }
    }
}