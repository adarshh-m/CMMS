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
    public class InventoryReturnController : ODataController
    {
        private readonly CmmsContext _context;

        public InventoryReturnController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventoryReturn> Get()
        {
            return _context.Set<InventoryReturn>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<InventoryReturn>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] InventoryReturn inventoryReturn)
        {
            

            _context.Set<InventoryReturn>().Add(inventoryReturn);
            await _context.SaveChangesAsync();

            return Created(inventoryReturn);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryReturn inventoryReturn)
        {
            

            if (key != inventoryReturn.InventoryReturnId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryReturn).State = EntityState.Modified;

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

            return Updated(inventoryReturn);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryReturn> inventoryReturn)
        {
           

            var entity = await _context.Set<InventoryReturn>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            inventoryReturn.Patch(entity);

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
            var inventoryReturn = await _context.Set<InventoryReturn>().FindAsync(key);
            if (inventoryReturn == null)
            {
                return NotFound();
            }

            _context.Set<InventoryReturn>().Remove(inventoryReturn);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<InventoryReturn>().Any(e => e.InventoryReturnId == key);
        }
    }
}