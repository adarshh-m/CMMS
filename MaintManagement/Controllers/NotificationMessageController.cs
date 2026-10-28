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
    public class NotificationMessageController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationMessageController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationMessage> Get()
        {
            return _context.Set<NotificationMessage>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<NotificationMessage>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] NotificationMessage notificationMessage)
        {
           

            _context.Set<NotificationMessage>().Add(notificationMessage);
            await _context.SaveChangesAsync();

            return Created(notificationMessage);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationMessage notificationMessage)
        {
           

            if (key != notificationMessage.NotificationMessageId)
            {
                return BadRequest();
            }

            _context.Entry(notificationMessage).State = EntityState.Modified;

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

            return Updated(notificationMessage);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationMessage> delta)
        {
            

            var entity = await _context.Set<NotificationMessage>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            delta.Patch(entity);

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
            var notificationMessage = await _context.Set<NotificationMessage>().FindAsync(key);
            if (notificationMessage == null)
            {
                return NotFound();
            }

            _context.Set<NotificationMessage>().Remove(notificationMessage);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationMessage>().Any(e => e.NotificationMessageId == key);
        }
    }
}