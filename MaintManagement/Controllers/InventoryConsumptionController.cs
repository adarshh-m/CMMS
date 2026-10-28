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
    public class InventoryConsumptionController : ODataController
    {
        private readonly CmmsContext _context;

        public InventoryConsumptionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventoryConsumption> Get()
        {
            return _context.Set<InventoryConsumption>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<InventoryConsumption>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] InventoryConsumption inventoryConsumption)
        {
            

            _context.Set<InventoryConsumption>().Add(inventoryConsumption);
            await _context.SaveChangesAsync();

            return Created(inventoryConsumption);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] InventoryConsumption inventoryConsumption)
        {
            

            if (key != inventoryConsumption.InventoryConsumptionId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryConsumption).State = EntityState.Modified;

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

            return Updated(inventoryConsumption);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryConsumption> inventoryConsumption)
        {
            

            var entity = await _context.Set<InventoryConsumption>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            inventoryConsumption.Patch(entity);

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
            var inventoryConsumption = await _context.Set<InventoryConsumption>().FindAsync(key);
            if (inventoryConsumption == null)
            {
                return NotFound();
            }

            _context.Set<InventoryConsumption>().Remove(inventoryConsumption);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<InventoryConsumption>().Count(e => e.InventoryConsumptionId == key) > 0;
        }
    }
}