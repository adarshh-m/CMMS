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
    public class NotificationAttachmentController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationAttachmentController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationAttachment> Get()
        {
            return _context.Set<NotificationAttachment>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<NotificationAttachment>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] NotificationAttachment notificationAttachment)
        {
            

            _context.Set<NotificationAttachment>().Add(notificationAttachment);
            await _context.SaveChangesAsync();

            return Created(notificationAttachment);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationAttachment notificationAttachment)
        {
            

            if (key != notificationAttachment.NotificationAttachmentId)
            {
                return BadRequest();
            }

            _context.Entry(notificationAttachment).State = EntityState.Modified;

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

            return Updated(notificationAttachment);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationAttachment> delta)
        {
            

            var entity = await _context.Set<NotificationAttachment>().FindAsync(key);
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
            var entity = await _context.Set<NotificationAttachment>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<NotificationAttachment>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationAttachment>().Count(e => e.NotificationAttachmentId == key) > 0;
        }
    }
}