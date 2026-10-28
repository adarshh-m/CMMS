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
    public class InventoryIntegrationLogController : ODataController
    {
        private readonly CmmsContext _context;

        public InventoryIntegrationLogController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventoryIntegrationLog> Get()
        {
            return _context.Set<InventoryIntegrationLog>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<InventoryIntegrationLog>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] InventoryIntegrationLog inventoryIntegrationLog)
        {
            

            _context.Set<InventoryIntegrationLog>().Add(inventoryIntegrationLog);
            await _context.SaveChangesAsync();

            return Created(inventoryIntegrationLog);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryIntegrationLog inventoryIntegrationLog)
        {
            

            if (key != inventoryIntegrationLog.InventoryIntegrationLogId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryIntegrationLog).State = EntityState.Modified;

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

            return Updated(inventoryIntegrationLog);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryIntegrationLog> delta)
        {
            

            var entity = await _context.Set<InventoryIntegrationLog>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            delta.Patch(entity);

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
            var entity = await _context.Set<InventoryIntegrationLog>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<InventoryIntegrationLog>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<InventoryIntegrationLog>().Count(e => e.InventoryIntegrationLogId == key) > 0;
        }
    }
}