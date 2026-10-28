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
    public class WebhookRequestLogController : ODataController
    {
        private readonly CmmsContext _context;

        public WebhookRequestLogController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WebhookRequestLog> Get()
        {
            return _context.Set<WebhookRequestLog>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var webhookRequestLog = await _context.Set<WebhookRequestLog>().FindAsync(key);
            if (webhookRequestLog == null)
            {
                return NotFound();
            }
            return Ok(webhookRequestLog);
        }

        public async Task<IActionResult> Post([FromBody]WebhookRequestLog webhookRequestLog)
        {
           webhookRequestLog.WebhookRequestLogId = Guid.NewGuid();
            _context.Set<WebhookRequestLog>().Add(webhookRequestLog);
            await _context.SaveChangesAsync();

            return Created(webhookRequestLog);
        }

        public async Task<IActionResult> Put(Guid key,[FromBody] WebhookRequestLog webhookRequestLog)
        {
          
            if (key != webhookRequestLog.WebhookRequestLogId)
            {
                return BadRequest();
            }

            _context.Entry(webhookRequestLog).State = EntityState.Modified;

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

            return Updated(webhookRequestLog);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WebhookRequestLog> delta)
        {
           
            var webhookRequestLog = await _context.Set<WebhookRequestLog>().FindAsync(key);
            if (webhookRequestLog == null)
            {
                return NotFound();
            }

            delta.Patch(webhookRequestLog);

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

            return Updated(webhookRequestLog);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var webhookRequestLog = await _context.Set<WebhookRequestLog>().FindAsync(key);
            if (webhookRequestLog == null)
            {
                return NotFound();
            }

            _context.Set<WebhookRequestLog>().Remove(webhookRequestLog);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WebhookRequestLog>().Count(e => e.WebhookRequestLogId == key) > 0;
        }
    }
}