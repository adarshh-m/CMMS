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
    public class NotificationSubscriptionController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationSubscriptionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationSubscription> Get()
        {
            return _context.Set<NotificationSubscription>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<NotificationSubscription>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] NotificationSubscription notificationSubscription)
        {
            

            _context.Set<NotificationSubscription>().Add(notificationSubscription);
            await _context.SaveChangesAsync();

            return Created(notificationSubscription);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationSubscription notificationSubscription)
        {
            

            if (key != notificationSubscription.NotificationSubscriptionId)
            {
                return BadRequest();
            }

            _context.Entry(notificationSubscription).State = EntityState.Modified;

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

            return Updated(notificationSubscription);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationSubscription> notificationSubscription)
        {
            

            var entity = await _context.Set<NotificationSubscription>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            notificationSubscription.Patch(entity);

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
            var notificationSubscription = await _context.Set<NotificationSubscription>().FindAsync(key);
            if (notificationSubscription == null)
            {
                return NotFound();
            }

            _context.Set<NotificationSubscription>().Remove(notificationSubscription);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationSubscription>().Any(e => e.NotificationSubscriptionId == key);
        }
    }
}