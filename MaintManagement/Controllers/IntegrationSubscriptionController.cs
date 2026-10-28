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
    public class IntegrationSubscriptionController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationSubscriptionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationSubscription> Get()
        {
            return _context.IntegrationSubscriptions;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var integrationSubscription = await _context.IntegrationSubscriptions.FindAsync(key);
            if (integrationSubscription == null)
            {
                return NotFound();
            }
            return Ok(integrationSubscription);
        }

        public async Task<IActionResult> Post([FromBody] IntegrationSubscription integrationSubscription)
        {
           

            _context.IntegrationSubscriptions.Add(integrationSubscription);
            await _context.SaveChangesAsync();

            return Created(integrationSubscription);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] IntegrationSubscription integrationSubscription)
        {
            

            if (key != integrationSubscription.IntegrationSubscriptionId)
            {
                return BadRequest();
            }

            _context.Entry(integrationSubscription).State = EntityState.Modified;

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

            return Updated(integrationSubscription);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationSubscription> integrationSubscription)
        {
            

            var entity = await _context.IntegrationSubscriptions.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            integrationSubscription.Patch(entity);

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
            var integrationSubscription = await _context.IntegrationSubscriptions.FindAsync(key);
            if (integrationSubscription == null)
            {
                return NotFound();
            }

            _context.IntegrationSubscriptions.Remove(integrationSubscription);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.IntegrationSubscriptions.Any(e => e.IntegrationSubscriptionId == key);
        }
    }
}