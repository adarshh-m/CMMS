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
    public class NotificationRetryController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationRetryController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationRetry> Get()
        {
            return _context.Set<NotificationRetry>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<NotificationRetry>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] NotificationRetry notificationRetry)
        {
            

            _context.Set<NotificationRetry>().Add(notificationRetry);
            await _context.SaveChangesAsync();

            return Created(notificationRetry);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationRetry notificationRetry)
        {
            

            if (key != notificationRetry.NotificationRetryId)
            {
                return BadRequest();
            }

            _context.Entry(notificationRetry).State = EntityState.Modified;

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

            return Updated(notificationRetry);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationRetry> notificationRetry)
        {
           

            var entity = await _context.Set<NotificationRetry>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            notificationRetry.Patch(entity);

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
            var notificationRetry = await _context.Set<NotificationRetry>().FindAsync(key);
            if (notificationRetry == null)
            {
                return NotFound();
            }

            _context.Set<NotificationRetry>().Remove(notificationRetry);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationRetry>().Count(e => e.NotificationRetryId == key) > 0;
        }
    }
}