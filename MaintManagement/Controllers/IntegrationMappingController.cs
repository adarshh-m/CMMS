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
    public class IntegrationMappingController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationMappingController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationMapping> Get()
        {
            return _context.Set<IntegrationMapping>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var integrationMapping = await _context.Set<IntegrationMapping>().FindAsync(key);
            if (integrationMapping == null)
            {
                return NotFound();
            }
            return Ok(integrationMapping);
        }

        public async Task<IActionResult> Post([FromBody] IntegrationMapping integrationMapping)
        {
           

            _context.Set<IntegrationMapping>().Add(integrationMapping);
            await _context.SaveChangesAsync();

            return Created(integrationMapping);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] IntegrationMapping integrationMapping)
        {
            

            if (key != integrationMapping.IntegrationMappingId)
            {
                return BadRequest();
            }

            _context.Entry(integrationMapping).State = EntityState.Modified;

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

            return Updated(integrationMapping);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationMapping> integrationMapping)
        {
            

            var entity = await _context.Set<IntegrationMapping>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            integrationMapping.Patch(entity);

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
            var integrationMapping = await _context.Set<IntegrationMapping>().FindAsync(key);
            if (integrationMapping == null)
            {
                return NotFound();
            }

            _context.Set<IntegrationMapping>().Remove(integrationMapping);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<IntegrationMapping>().Count(e => e.IntegrationMappingId == key) > 0;
        }
    }

   
}