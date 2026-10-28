using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class SpareRequestItemController : ODataController
    {
       // private CmmsContext db = new CmmsContext();

        private readonly CmmsContext db;

        public SpareRequestItemController(CmmsContext context)
        {
            db = context;
        }
        // GET: odata/SpareRequestItems
        [EnableQuery]
        public IQueryable<SpareRequestItem> Get()
        {
            return db.SpareRequestItems;
        }

        // GET: odata/SpareRequestItems(5)
        [EnableQuery]
        public SingleResult<SpareRequestItem> Get([FromBody] Guid key)
        {
            return SingleResult.Create(db.SpareRequestItems.Where(spareRequestItem => spareRequestItem.SpareRequestItemId == key));
        }

        // POST: odata/SpareRequestItems
        public async Task<IActionResult> Post([FromBody] SpareRequestItem spareRequestItem)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.SpareRequestItems.Add(spareRequestItem);
            await db.SaveChangesAsync();

            return Created(spareRequestItem);
        }

        // PUT: odata/SpareRequestItems(5)
        public async Task<IActionResult> Put( Guid key, [FromBody] SpareRequestItem spareRequestItem)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != spareRequestItem.SpareRequestItemId)
            {
                return BadRequest();
            }

            db.Entry(spareRequestItem).State = EntityState.Modified;

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

            return Updated(spareRequestItem);
        }

        // PATCH: odata/SpareRequestItems(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<SpareRequestItem> delta)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            SpareRequestItem spareRequestItem = await db.SpareRequestItems.FindAsync(key);
            if (spareRequestItem == null)
            {
                return NotFound();
            }

            delta.Patch(spareRequestItem);

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

            return Updated(spareRequestItem);
        }

        // DELETE: odata/SpareRequestItems(5)
        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            SpareRequestItem spareRequestItem = await db.SpareRequestItems.FindAsync(key);
            if (spareRequestItem == null)
            {
                return NotFound();
            }

            db.SpareRequestItems.Remove(spareRequestItem);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.SpareRequestItems.Count(e => e.SpareRequestItemId == key) > 0;
        }
    }
}