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
    public class NotificationDeliveryController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationDeliveryController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationDelivery> Get()
        {
            return _context.Set<NotificationDelivery>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var notificationDelivery = await _context.Set<NotificationDelivery>().FindAsync(key);
            if (notificationDelivery == null)
            {
                return NotFound();
            }
            return Ok(notificationDelivery);
        }

        public async Task<IActionResult> Post([FromBody] NotificationDelivery notificationDelivery)
        {
            

            _context.Set<NotificationDelivery>().Add(notificationDelivery);
            await _context.SaveChangesAsync();

            return Created(notificationDelivery);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationDelivery notificationDelivery)
        {
            

            if (key != notificationDelivery.NotificationDeliveryId)
            {
                return BadRequest();
            }

            _context.Entry(notificationDelivery).State = EntityState.Modified;

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

            return Updated(notificationDelivery);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationDelivery> delta)
        {
            

            var notificationDelivery = await _context.Set<NotificationDelivery>().FindAsync(key);
            if (notificationDelivery == null)
            {
                return NotFound();
            }

            delta.Patch(notificationDelivery);

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

            return Updated(notificationDelivery);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var notificationDelivery = await _context.Set<NotificationDelivery>().FindAsync(key);
            if (notificationDelivery == null)
            {
                return NotFound();
            }

            _context.Set<NotificationDelivery>().Remove(notificationDelivery);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationDelivery>().Count(e => e.NotificationDeliveryId == key) > 0;
        }
    }
}