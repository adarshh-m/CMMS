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
    public class InventoryCycleCountLineController : ODataController
    {
        private readonly CmmsContext db;

        public InventoryCycleCountLineController(CmmsContext context)
        {
            db = context;
        }

       

       
        [EnableQuery]
        public IQueryable<InventoryCycleCountLine> Get()
        {
            return db.InventoryCycleCountLines;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            InventoryCycleCountLine inventoryCycleCountLine = await db.InventoryCycleCountLines.FindAsync(key);
            if (inventoryCycleCountLine == null)
            {
                return NotFound();
            }
            return Ok(inventoryCycleCountLine);
        }

        public async Task<IActionResult> Post([FromBody] InventoryCycleCountLine inventoryCycleCountLine)
        {
            

            db.InventoryCycleCountLines.Add(inventoryCycleCountLine);
            await db.SaveChangesAsync();

            return Created(inventoryCycleCountLine);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] InventoryCycleCountLine inventoryCycleCountLine)
        {
            

            if (key != inventoryCycleCountLine.InventoryCycleCountLineId)
            {
                return BadRequest();
            }

            db.Entry(inventoryCycleCountLine).State = EntityState.Modified;

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

            return Updated(inventoryCycleCountLine);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryCycleCountLine> patch)
        {
            

            InventoryCycleCountLine inventoryCycleCountLine = await db.InventoryCycleCountLines.FindAsync(key);
            if (inventoryCycleCountLine == null)
            {
                return NotFound();
            }

            patch.Patch(inventoryCycleCountLine);

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

            return Updated(inventoryCycleCountLine);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            InventoryCycleCountLine inventoryCycleCountLine = await db.InventoryCycleCountLines.FindAsync(key);
            if (inventoryCycleCountLine == null)
            {
                return NotFound();
            }

            db.InventoryCycleCountLines.Remove(inventoryCycleCountLine);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.InventoryCycleCountLines.Count(e => e.InventoryCycleCountLineId == key) > 0;
        }
    }
}