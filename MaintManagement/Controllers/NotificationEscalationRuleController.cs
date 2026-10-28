using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 

namespace YourNamespace.Controllers
{
    public class NotificationEscalationRuleController : ODataController
    {
        private readonly CmmsContext _context;

        public NotificationEscalationRuleController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<NotificationEscalationRule> Get()
        {
            return _context.Set<NotificationEscalationRule>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<NotificationEscalationRule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] NotificationEscalationRule notificationEscalationRule)
        {
            

            _context.Set<NotificationEscalationRule>().Add(notificationEscalationRule);
            await _context.SaveChangesAsync();

            return Created(notificationEscalationRule);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] NotificationEscalationRule notificationEscalationRule)
        {
            

            if (key != notificationEscalationRule.NotificationEscalationRuleId)
            {
                return BadRequest();
            }

            _context.Entry(notificationEscalationRule).State = EntityState.Modified;

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

            return Updated(notificationEscalationRule);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<NotificationEscalationRule> notificationEscalationRule)
        {
            

            var entity = await _context.Set<NotificationEscalationRule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            notificationEscalationRule.Patch(entity);

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
            var notificationEscalationRule = await _context.Set<NotificationEscalationRule>().FindAsync(key);
            if (notificationEscalationRule == null)
            {
                return NotFound();
            }

            _context.Set<NotificationEscalationRule>().Remove(notificationEscalationRule);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<NotificationEscalationRule>().Find(key) != null;
        }
    }
}