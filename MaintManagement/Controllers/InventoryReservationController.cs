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
    public class InventoryReservationController : ODataController
    {
        private readonly CmmsContext _context;

        public InventoryReservationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventoryReservation> Get()
        {
            return _context.Set<InventoryReservation>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<InventoryReservation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] InventoryReservation inventoryReservation)
        {
            

            _context.Set<InventoryReservation>().Add(inventoryReservation);
            await _context.SaveChangesAsync();

            return Created(inventoryReservation);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryReservation inventoryReservation)
        {
            

            if (key != inventoryReservation.InventoryReservationId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryReservation).State = EntityState.Modified;

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

            return Updated(inventoryReservation);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryReservation> delta)
        {
            

            var entity = await _context.Set<InventoryReservation>().FindAsync(key);
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
            var entity = await _context.Set<InventoryReservation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<InventoryReservation>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<InventoryReservation>().Count(e => e.InventoryReservationId == key) > 0;
        }
    }
}