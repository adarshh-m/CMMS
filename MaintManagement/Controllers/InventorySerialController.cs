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
    public class InventorySerialController : ODataController
    {
        private readonly CmmsContext _context;

        public InventorySerialController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventorySerial> Get()
        {
            return _context.Set<InventorySerial>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<InventorySerial>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] InventorySerial inventorySerial)
        {
            

            _context.Set<InventorySerial>().Add(inventorySerial);
            await _context.SaveChangesAsync();

            return Created(inventorySerial);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventorySerial inventorySerial)
        {
           

            if (key != inventorySerial.InventorySerialId)
            {
                return BadRequest();
            }

            _context.Entry(inventorySerial).State = EntityState.Modified;

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

            return Updated(inventorySerial);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventorySerial> delta)
        {
            

            var entity = await _context.Set<InventorySerial>().FindAsync(key);
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
            var entity = await _context.Set<InventorySerial>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<InventorySerial>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<InventorySerial>().Count(e => e.InventorySerialId == key) > 0;
        }
    }
}