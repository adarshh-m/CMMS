using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 
 

namespace YourNamespace.Controllers
{
    public class PMWorkOrderController : ODataController
    {
        private readonly CmmsContext db;

        public PMWorkOrderController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<PmworkOrder> Get()
        {
            return db.PmworkOrders;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            PmworkOrder pMWorkOrder = await db.PmworkOrders.FindAsync(key);
            if (pMWorkOrder == null)
            {
                return NotFound();
            }
            return Ok(pMWorkOrder);
        }

        public async Task<IActionResult> Post([FromBody] PmworkOrder pMWorkOrder)
        {
            

            db.PmworkOrders.Add(pMWorkOrder);
            await db.SaveChangesAsync();

            return Created(pMWorkOrder);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] PmworkOrder update)
        {
            

            if (key != update.PmworkOrderId)
            {
                return BadRequest();
            }

            db.Entry(update).State = EntityState.Modified;

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

            return Updated(update);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<PmworkOrder> patch)
        {
           

            PmworkOrder pMWorkOrder = await db.PmworkOrders.FindAsync(key);
            if (pMWorkOrder == null)
            {
                return NotFound();
            }

            patch.Patch(pMWorkOrder);

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

            return Updated(pMWorkOrder);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            PmworkOrder pMWorkOrder = await db.PmworkOrders.FindAsync(key);
            if (pMWorkOrder == null)
            {
                return NotFound();
            }

            db.PmworkOrders.Remove(pMWorkOrder);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.PmworkOrders.Any(e => e.PmworkOrderId == key);
        }
    }
}