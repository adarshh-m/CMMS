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
    public class NotificationRecipientController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationRecipientController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationRecipient> Get()
        {
            return _context.Set<NotificationRecipient>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var notificationRecipient = await _context.Set<NotificationRecipient>().FindAsync(key);
            if (notificationRecipient == null)
            {
                return NotFound();
            }
            return Ok(notificationRecipient);
        }

        public async Task<IActionResult> Post([FromBody] NotificationRecipient notificationRecipient)
        {
            

            _context.Set<NotificationRecipient>().Add(notificationRecipient);
            await _context.SaveChangesAsync();

            return Created(notificationRecipient);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationRecipient notificationRecipient)
        {
            

            if (key != notificationRecipient.NotificationRecipientId)
            {
                return BadRequest();
            }

            _context.Entry(notificationRecipient).State = EntityState.Modified;

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

            return Updated(notificationRecipient);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationRecipient> notificationRecipient)
        {
            

            var entity = await _context.Set<NotificationRecipient>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            notificationRecipient.Patch(entity);

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
            var notificationRecipient = await _context.Set<NotificationRecipient>().FindAsync(key);
            if (notificationRecipient == null)
            {
                return NotFound();
            }

            _context.Set<NotificationRecipient>().Remove(notificationRecipient);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationRecipient>().Count(e => e.NotificationRecipientId == key) > 0;
        }
    }
}