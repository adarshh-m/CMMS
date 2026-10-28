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
    public class InventoryTransactionController : ODataController
    {
        private readonly CmmsContext _context;

        public InventoryTransactionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventoryTransaction> Get()
        {
            return _context.Set<InventoryTransaction>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<InventoryTransaction>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] InventoryTransaction inventoryTransaction)
        {
            

            _context.Set<InventoryTransaction>().Add(inventoryTransaction);
            await _context.SaveChangesAsync();

            return Created(inventoryTransaction);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryTransaction inventoryTransaction)
        {
           

            if (key != inventoryTransaction.InventoryTransactionId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryTransaction).State = EntityState.Modified;

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

            return Updated(inventoryTransaction);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryTransaction> delta)
        {
            

            var entity = await _context.Set<InventoryTransaction>().FindAsync(key);
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
            var entity = await _context.Set<InventoryTransaction>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<InventoryTransaction>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<InventoryTransaction>().Any(e => e.InventoryTransactionId == key);
        }
    }
}