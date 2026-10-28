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
    public class InventoryLotController : ODataController
    {
        private readonly CmmsContext db;


        public InventoryLotController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<InventoryLot> Get()
        {
            return db.InventoryLots;
        }

        [EnableQuery]
        public SingleResult<InventoryLot> Get([FromBody] Guid key)
        {
            return SingleResult.Create(db.InventoryLots.Where(inventoryLot => inventoryLot.InventoryLotId == key));
        }

        public async Task<IActionResult> Post([FromBody] InventoryLot inventoryLot)
        {
            

            db.InventoryLots.Add(inventoryLot);
            await db.SaveChangesAsync();

            return Created(inventoryLot);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryLot inventoryLot)
        {
            

            if (key != inventoryLot.InventoryLotId)
            {
                return BadRequest();
            }

            db.Entry(inventoryLot).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(inventoryLot);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryLot> inventoryLot)
        {
            

            var entity = await db.InventoryLots.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            inventoryLot.Patch(entity);

            try
            {
                await db.SaveChangesAsync();
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
            var inventoryLot = await db.InventoryLots.FindAsync(key);
            if (inventoryLot == null)
            {
                return NotFound();
            }

            db.InventoryLots.Remove(inventoryLot);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.InventoryLots.Any(e => e.InventoryLotId == key);
        }
    }
}