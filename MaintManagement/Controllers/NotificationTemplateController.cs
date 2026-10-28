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
    public class NotificationTemplateController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationTemplateController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationTemplate> Get()
        {
            return _context.Set<NotificationTemplate>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var notificationTemplate = await _context.Set<NotificationTemplate>().FindAsync(key);
            if (notificationTemplate == null)
            {
                return NotFound();
            }
            return Ok(notificationTemplate);
        }

        public async Task<IActionResult> Post([FromBody] NotificationTemplate notificationTemplate)
        {
            

            _context.Set<NotificationTemplate>().Add(notificationTemplate);
            await _context.SaveChangesAsync();

            return Created(notificationTemplate);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationTemplate notificationTemplate)
        {
           

            if (key != notificationTemplate.NotificationTemplateId)
            {
                return BadRequest();
            }

            _context.Entry(notificationTemplate).State = EntityState.Modified;

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

            return Updated(notificationTemplate);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationTemplate> notificationTemplate)
        {
            

            var entity = await _context.Set<NotificationTemplate>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            notificationTemplate.Patch(entity);

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
            var notificationTemplate = await _context.Set<NotificationTemplate>().FindAsync(key);
            if (notificationTemplate == null)
            {
                return NotFound();
            }

            _context.Set<NotificationTemplate>().Remove(notificationTemplate);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationTemplate>().Count(e => e.NotificationTemplateId == key) > 0;
        }
    }
}