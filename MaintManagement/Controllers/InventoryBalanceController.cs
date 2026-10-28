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
    public class InventoryBalanceController : ODataController
    {
        //private CmmsContext db = new CmmsContext();
        private readonly CmmsContext db;

        public InventoryBalanceController(CmmsContext context)
        {
            db = context;
        }
        // GET: odata/InventoryBalance
        [EnableQuery]
        public IQueryable<InventoryBalance> GetInventoryBalances()
        {
            return db.InventoryBalances;
        }

        // GET: odata/InventoryBalance(5)
        [EnableQuery]
        public SingleResult<InventoryBalance> GetInventoryBalance([FromBody] Guid key)
        {
            return SingleResult.Create(db.InventoryBalances.Where(inventoryBalance => inventoryBalance.InventoryBalanceId == key));
        }

        // POST: odata/InventoryBalance
        public async Task<IActionResult> Post([FromBody] InventoryBalance inventoryBalance)
        {
           

            db.InventoryBalances.Add(inventoryBalance);
            await db.SaveChangesAsync();

            return Created(inventoryBalance);
        }

        // PUT: odata/InventoryBalance(5)
        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryBalance inventoryBalance)
        {
            

            if (key != inventoryBalance.InventoryBalanceId)
            {
                return BadRequest();
            }

            db.Entry(inventoryBalance).State = EntityState.Modified;

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

            return Updated(inventoryBalance);
        }

        // PATCH: odata/InventoryBalance(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryBalance> delta)
        {
            

            InventoryBalance inventoryBalance = await db.InventoryBalances.FindAsync(key);
            if (inventoryBalance == null)
            {
                return NotFound();
            }

            delta.Patch(inventoryBalance);

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

            return Updated(inventoryBalance);
        }

        // DELETE: odata/InventoryBalance(5)
        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            InventoryBalance inventoryBalance = await db.InventoryBalances.FindAsync(key);
            if (inventoryBalance == null)
            {
                return NotFound();
            }

            db.InventoryBalances.Remove(inventoryBalance);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.InventoryBalances.Count(e => e.InventoryBalanceId == key) > 0;
        }
    }
}