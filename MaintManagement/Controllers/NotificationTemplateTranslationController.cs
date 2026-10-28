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
    public class NotificationTemplateTranslationController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationTemplateTranslationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationTemplateTranslation> Get()
        {
            return _context.Set<NotificationTemplateTranslation>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<NotificationTemplateTranslation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] NotificationTemplateTranslation notificationTemplateTranslation)
        {
            

            _context.Set<NotificationTemplateTranslation>().Add(notificationTemplateTranslation);
            await _context.SaveChangesAsync();

            return Created(notificationTemplateTranslation);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationTemplateTranslation notificationTemplateTranslation)
        {
            

            if (key != notificationTemplateTranslation.NotificationTemplateTranslationId)
            {
                return BadRequest();
            }

            _context.Entry(notificationTemplateTranslation).State = EntityState.Modified;

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

            return Updated(notificationTemplateTranslation);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationTemplateTranslation> patch)
        {
            

            var entity = await _context.Set<NotificationTemplateTranslation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

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
            var notificationTemplateTranslation = await _context.Set<NotificationTemplateTranslation>().FindAsync(key);
            if (notificationTemplateTranslation == null)
            {
                return NotFound();
            }

            _context.Set<NotificationTemplateTranslation>().Remove(notificationTemplateTranslation);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationTemplateTranslation>().Count(e => e.NotificationTemplateTranslationId == key) > 0;
        }
    }
}