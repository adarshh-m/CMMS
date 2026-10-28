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
    public class WebhookSubscriptionController : ODataController
    {
        private readonly CmmsContext _context;

        public WebhookSubscriptionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WebhookSubscription> Get()
        {
            return _context.WebhookSubscriptions;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var webhookSubscription = await _context.WebhookSubscriptions.FindAsync(key);
            if (webhookSubscription == null)
            {
                return NotFound();
            }
            return Ok(webhookSubscription);
        }

        public async Task<IActionResult> Post([FromBody]WebhookSubscription webhookSubscription)
        {
           webhookSubscription.WebhookSubscriptionId = Guid.NewGuid();
            _context.WebhookSubscriptions.Add(webhookSubscription);
            await _context.SaveChangesAsync();

            return Created(webhookSubscription);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WebhookSubscription webhookSubscription)
        {
           
            if (key != webhookSubscription.WebhookSubscriptionId)
            {
                return BadRequest();
            }

            _context.Entry(webhookSubscription).State = EntityState.Modified;

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

            return Updated(webhookSubscription);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WebhookSubscription> delta)
        {
          
            var webhookSubscription = await _context.WebhookSubscriptions.FindAsync(key);
            if (webhookSubscription == null)
            {
                return NotFound();
            }

            delta.Patch(webhookSubscription);

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

            return Updated(webhookSubscription);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var webhookSubscription = await _context.WebhookSubscriptions.FindAsync(key);
            if (webhookSubscription == null)
            {
                return NotFound();
            }

            _context.WebhookSubscriptions.Remove(webhookSubscription);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.WebhookSubscriptions.Any(e => e.WebhookSubscriptionId == key);
        }
    }
}