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
    public class IntegrationEndpointController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationEndpointController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationEndpoint> Get()
        {
            return _context.Set<IntegrationEndpoint>();
        }

        [EnableQuery]
        public async Task<SingleResult<IntegrationEndpoint>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<IntegrationEndpoint>().Where(x => x.IntegrationEndpointId == key));
        }

        public async Task<IActionResult> Post([FromBody] IntegrationEndpoint integrationEndpoint)
        {
            

            _context.Set<IntegrationEndpoint>().Add(integrationEndpoint);
            await _context.SaveChangesAsync();

            return Created(integrationEndpoint);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] IntegrationEndpoint integrationEndpoint)
        {
           

            if (key != integrationEndpoint.IntegrationEndpointId)
            {
                return BadRequest();
            }

            _context.Entry(integrationEndpoint).State = EntityState.Modified;

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

            return Updated(integrationEndpoint);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationEndpoint> integrationEndpoint)
        {
            

            var entity = await _context.Set<IntegrationEndpoint>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            integrationEndpoint.Patch(entity);

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
            var integrationEndpoint = await _context.Set<IntegrationEndpoint>().FindAsync(key);
            if (integrationEndpoint == null)
            {
                return NotFound();
            }

            _context.Set<IntegrationEndpoint>().Remove(integrationEndpoint);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<IntegrationEndpoint>().Any(e => e.IntegrationEndpointId == key);
        }
    }
}