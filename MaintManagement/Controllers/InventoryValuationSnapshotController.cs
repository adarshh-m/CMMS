using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
using System.Collections.Generic;
 
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 
 

namespace YourNamespace.Controllers
{
    public class InventoryValuationSnapshotController : ODataController
    {
        private readonly CmmsContext db;

        public InventoryValuationSnapshotController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<InventoryValuationSnapshot> Get()
        {
            return db.InventoryValuationSnapshots;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            InventoryValuationSnapshot entity = await db.InventoryValuationSnapshots.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] InventoryValuationSnapshot inventoryValuationSnapshot)
        {
            

            db.InventoryValuationSnapshots.Add(inventoryValuationSnapshot);
            await db.SaveChangesAsync();

            return Created(inventoryValuationSnapshot);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryValuationSnapshot inventoryValuationSnapshot)
        {
            

            if (key != inventoryValuationSnapshot.InventoryValuationSnapshotId)
            {
                return BadRequest();
            }

            db.Entry(inventoryValuationSnapshot).State = EntityState.Modified;

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

            return Updated(inventoryValuationSnapshot);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryValuationSnapshot> delta)
        {
            

            InventoryValuationSnapshot inventoryValuationSnapshot = await db.InventoryValuationSnapshots.FindAsync(key);
            if (inventoryValuationSnapshot == null)
            {
                return NotFound();
            }

            delta.Patch(inventoryValuationSnapshot);

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

            return Updated(inventoryValuationSnapshot);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            InventoryValuationSnapshot inventoryValuationSnapshot = await db.InventoryValuationSnapshots.FindAsync(key);
            if (inventoryValuationSnapshot == null)
            {
                return NotFound();
            }

            db.InventoryValuationSnapshots.Remove(inventoryValuationSnapshot);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.InventoryValuationSnapshots.Any(e => e.InventoryValuationSnapshotId == key);
        }
    }
}