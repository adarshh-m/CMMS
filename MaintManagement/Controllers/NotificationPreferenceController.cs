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
    public class NotificationPreferenceController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationPreferenceController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationPreference> Get()
        {
            return _context.Set<NotificationPreference>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<NotificationPreference>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] NotificationPreference notificationPreference)
        {
            

            _context.Set<NotificationPreference>().Add(notificationPreference);
            await _context.SaveChangesAsync();

            return Created(notificationPreference);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationPreference notificationPreference)
        {
           

            if (key != notificationPreference.NotificationPreferenceId)
            {
                return BadRequest();
            }

            _context.Entry(notificationPreference).State = EntityState.Modified;

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

            return Updated(notificationPreference);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationPreference> notificationPreference)
        {
            

            var entity = await _context.Set<NotificationPreference>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            notificationPreference.Patch(entity);

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
            var notificationPreference = await _context.Set<NotificationPreference>().FindAsync(key);
            if (notificationPreference == null)
            {
                return NotFound();
            }

            _context.Set<NotificationPreference>().Remove(notificationPreference);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationPreference>().Count(e => e.NotificationPreferenceId == key) > 0;
        }
    }
}