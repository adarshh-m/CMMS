using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
 
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 

namespace YourNamespace.Controllers
{
    public class NotificationEventController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationEventController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationEvent> Get()
        {
            return _context.Set<NotificationEvent>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var notificationEvent = await _context.Set<NotificationEvent>().FindAsync(key);
            if (notificationEvent == null)
            {
                return NotFound();
            }
            return Ok(notificationEvent);
        }

        public async Task<IActionResult> Post([FromBody] NotificationEvent notificationEvent)
        {
            

            _context.Set<NotificationEvent>().Add(notificationEvent);
            await _context.SaveChangesAsync();

            return Created(notificationEvent);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationEvent notificationEvent)
        {
            

            if (key != notificationEvent.NotificationEventId)
            {
                return BadRequest();
            }

            _context.Entry(notificationEvent).State = EntityState.Modified;

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

            return Updated(notificationEvent);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationEvent> notificationEvent)
        {
            

            var entity = await _context.Set<NotificationEvent>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            notificationEvent.Patch(entity);

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
            var notificationEvent = await _context.Set<NotificationEvent>().FindAsync(key);
            if (notificationEvent == null)
            {
                return NotFound();
            }

            _context.Set<NotificationEvent>().Remove(notificationEvent);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationEvent>().Count(e => e.NotificationEventId == key) > 0;
        }
    }
}