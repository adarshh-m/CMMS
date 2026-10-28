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
    public class IntegrationBatchController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationBatchController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationBatch> Get()
        {
            return _context.IntegrationBatches;
        }

        [EnableQuery]
        public async Task<SingleResult<IntegrationBatch>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.IntegrationBatches.Where(integrationBatch => integrationBatch.IntegrationBatchId == key));
        }

        public async Task<IActionResult> Post([FromBody] IntegrationBatch integrationBatch)
        {
            

            _context.IntegrationBatches.Add(integrationBatch);
            await _context.SaveChangesAsync();

            return Created(integrationBatch);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] IntegrationBatch integrationBatch)
        {
            

            if (key != integrationBatch.IntegrationBatchId)
            {
                return BadRequest();
            }

            _context.Entry(integrationBatch).State = EntityState.Modified;

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

            return Updated(integrationBatch);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<IntegrationBatch> patch)
        {
            

            var integrationBatch = await _context.IntegrationBatches.FindAsync(key);
            if (integrationBatch == null)
            {
                return NotFound();
            }

            patch.Patch(integrationBatch);

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

            return Updated(integrationBatch);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var integrationBatch = await _context.IntegrationBatches.FindAsync(key);
            if (integrationBatch == null)
            {
                return NotFound();
            }

            _context.IntegrationBatches.Remove(integrationBatch);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.IntegrationBatches.Any(e => e.IntegrationBatchId == key);
        }
    }
}