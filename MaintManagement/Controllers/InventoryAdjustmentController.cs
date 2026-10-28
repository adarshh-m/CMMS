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
    public class InventoryAdjustmentController : ODataController
    {
        //private CmmsContext db = new CmmsContext();
        private readonly CmmsContext db;

        public InventoryAdjustmentController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<InventoryAdjustment> Get()
        {
            return db.InventoryAdjustments;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            InventoryAdjustment inventoryAdjustment = await db.InventoryAdjustments.FindAsync(key);
            if (inventoryAdjustment == null)
            {
                return NotFound();
            }
            return Ok(inventoryAdjustment);
        }

        public async Task<IActionResult> Post([FromBody] InventoryAdjustment inventoryAdjustment)
        {
           

            db.InventoryAdjustments.Add(inventoryAdjustment);
            await db.SaveChangesAsync();

            return Created(inventoryAdjustment);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] InventoryAdjustment inventoryAdjustment)
        {
            

            if (key != inventoryAdjustment.InventoryAdjustmentId)
            {
                return BadRequest();
            }

            db.Entry(inventoryAdjustment).State = EntityState.Modified;

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

            return Updated(inventoryAdjustment);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryAdjustment> delta)
        {
           

            InventoryAdjustment inventoryAdjustment = await db.InventoryAdjustments.FindAsync(key);
            if (inventoryAdjustment == null)
            {
                return NotFound();
            }

            delta.Patch(inventoryAdjustment);

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

            return Updated(inventoryAdjustment);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            InventoryAdjustment inventoryAdjustment = await db.InventoryAdjustments.FindAsync(key);
            if (inventoryAdjustment == null)
            {
                return NotFound();
            }

            db.InventoryAdjustments.Remove(inventoryAdjustment);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.InventoryAdjustments.Count(e => e.InventoryAdjustmentId == key) > 0;
        }
    }
}