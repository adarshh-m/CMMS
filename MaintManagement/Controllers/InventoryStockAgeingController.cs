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
    public class InventoryStockAgeingController : ODataController
    {
        private readonly CmmsContext db;


        public InventoryStockAgeingController(CmmsContext context)
        {
            db = context;
        }

        // GET: odata/InventoryStockAgeing
        [EnableQuery]
        public IQueryable<InventoryStockAgeing> GetInventoryStockAgeings()
        {
            return db.InventoryStockAgeings;
        }

        // GET: odata/InventoryStockAgeing(5)
        //[EnableQuery]
        //public SingleResult<InventoryStockAgeing> GetInventoryStockAgeing([FromBody] Guid key)
        //{
        //    return SingleResult.Create(db.InventoryStockAgeings.Where(inventoryStockAgeing => inventoryStockAgeing.InventoryStockAgeingId == key));
        //}

        //// POST: odata/InventoryStockAgeing
        //public async Task<IActionResult> Post([FromBody] InventoryStockAgeing inventoryStockAgeing)
        //{


        //    db.InventoryStockAgeings.Add(inventoryStockAgeing);
        //    await db.SaveChangesAsync();

        //    return Created(inventoryStockAgeing);
        //}
        // GET: /odata/InventoryStockAgeing
        [EnableQuery]
        public IQueryable<InventoryStockAgeing> Get()
        {
            return db.InventoryStockAgeings;
        }

        // GET: /odata/InventoryStockAgeing(guid'...')
        [EnableQuery]
        public SingleResult<InventoryStockAgeing> Get([FromRoute] Guid key)
        {
            return SingleResult.Create(
                db.InventoryStockAgeings.Where(
                    x => x.InventoryStockAgeingId == key));
        }
        // PUT: odata/InventoryStockAgeing(5)
        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryStockAgeing inventoryStockAgeing)
        {
           

            if (key != inventoryStockAgeing.InventoryStockAgeingId)
            {
                return BadRequest();
            }

            db.Entry(inventoryStockAgeing).State = EntityState.Modified;

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

            return Updated(inventoryStockAgeing);
        }

        // PATCH: odata/InventoryStockAgeing(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch([FromBody] Guid key, Delta<InventoryStockAgeing> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            InventoryStockAgeing inventoryStockAgeing = await db.InventoryStockAgeings.FindAsync(key);
            if (inventoryStockAgeing == null)
            {
                return NotFound();
            }

            patch.Patch(inventoryStockAgeing);

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

            return Updated(inventoryStockAgeing);
        }

        // DELETE: odata/InventoryStockAgeing(5)
        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            InventoryStockAgeing inventoryStockAgeing = await db.InventoryStockAgeings.FindAsync(key);
            if (inventoryStockAgeing == null)
            {
                return NotFound();
            }

            db.InventoryStockAgeings.Remove(inventoryStockAgeing);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.InventoryStockAgeings.Count(e => e.InventoryStockAgeingId == key) > 0;
        }
    }
}