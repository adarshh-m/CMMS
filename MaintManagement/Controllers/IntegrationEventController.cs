using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
using System.Collections.Generic;
 
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 
 

namespace YourNamespace.Controllers
{
    public class IntegrationEventController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationEventController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationEvent> Get()
        {
            return _context.Set<IntegrationEvent>();
        }

        [EnableQuery]
        public async Task<SingleResult<IntegrationEvent>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<IntegrationEvent>().Where(i => i.IntegrationEventId == key));
        }

        public async Task<IActionResult> Post([FromBody] IntegrationEvent integrationEvent)
        {
           

            _context.Set<IntegrationEvent>().Add(integrationEvent);
            await _context.SaveChangesAsync();

            return Created(integrationEvent);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] IntegrationEvent integrationEvent)
        {
            

            if (key != integrationEvent.IntegrationEventId)
            {
                return BadRequest();
            }

            _context.Entry(integrationEvent).State = EntityState.Modified;

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

            return Updated(integrationEvent);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationEvent> patch)
        {
            
            var integrationEvent = await _context.Set<IntegrationEvent>().FindAsync(key);
            if (integrationEvent == null)
            {
                return NotFound();
            }

            patch.Patch(integrationEvent);

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

            return Updated(integrationEvent);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var integrationEvent = await _context.Set<IntegrationEvent>().FindAsync(key);
            if (integrationEvent == null)
            {
                return NotFound();
            }

            _context.Set<IntegrationEvent>().Remove(integrationEvent);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<IntegrationEvent>().Count(e => e.IntegrationEventId == key) > 0;
        }
    }

   
}