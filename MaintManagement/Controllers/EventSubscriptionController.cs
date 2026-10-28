using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class EventSubscriptionController : ODataController
    {
        private readonly CmmsContext _context;

        public EventSubscriptionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<EventSubscription> Get()
        {
            return _context.Set<EventSubscription>();
        }

        [EnableQuery]
        public async Task<SingleResult<EventSubscription>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<EventSubscription>().Where(e => e.EventSubscriptionId == key));
        }

        public async Task<IActionResult> Post([FromBody] EventSubscription eventSubscription)
        {
            

            _context.Set<EventSubscription>().Add(eventSubscription);
            await _context.SaveChangesAsync();

            return Created(eventSubscription);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] EventSubscription eventSubscription)
        {
           

            if (key != eventSubscription.EventSubscriptionId)
            {
                return BadRequest();
            }

            _context.Entry(eventSubscription).State = EntityState.Modified;

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

            return Updated(eventSubscription);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<EventSubscription> patch)
        {
            
            var eventSubscription = await _context.Set<EventSubscription>().FindAsync(key);
            if (eventSubscription == null)
            {
                return NotFound();
            }

            patch.Patch(eventSubscription);

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

            return Updated(eventSubscription);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var eventSubscription = await _context.Set<EventSubscription>().FindAsync(key);
            if (eventSubscription == null)
            {
                return NotFound();
            }

            _context.Set<EventSubscription>().Remove(eventSubscription);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<EventSubscription>().Any(e => e.EventSubscriptionId == key);
        }
    }
}