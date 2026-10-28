using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class HazardMasterController : ODataController
    {
        private readonly CmmsContext db;

        public HazardMasterController(CmmsContext context)
        {
            db = context;
        }
        // GET: odata/HazardMaster
        [EnableQuery]
        public IQueryable<HazardMaster> Get()
        {
            return db.HazardMasters;
        }

        // GET: odata/HazardMaster(5)
        [EnableQuery]
        public SingleResult<HazardMaster> Get([FromBody] Guid key)
        {
            return SingleResult.Create(db.HazardMasters.Where(hazardMaster => hazardMaster.HazardId == key));
        }

        // POST: odata/HazardMaster
        public async Task<IActionResult> Post([FromBody] HazardMaster hazardMaster)
        {
            

            db.HazardMasters.Add(hazardMaster);
            await db.SaveChangesAsync();

            return Created(hazardMaster);
        }

        // PUT: odata/HazardMaster(5)
        public async Task<IActionResult> Put(Guid key, [FromBody] HazardMaster hazardMaster)
        {
            

            if (key != hazardMaster.HazardId)
            {
                return BadRequest();
            }

            db.Entry(hazardMaster).State = EntityState.Modified;

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

            return Updated(hazardMaster);
        }

        // PATCH: odata/HazardMaster(5)
        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<HazardMaster> delta)
        {
            

            HazardMaster hazardMaster = await db.HazardMasters.FindAsync(key);
            if (hazardMaster == null)
            {
                return NotFound();
            }

            delta.Patch(hazardMaster);

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

            return Updated(hazardMaster);
        }

        // DELETE: odata/HazardMaster(5)
        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            HazardMaster hazardMaster = await db.HazardMasters.FindAsync(key);
            if (hazardMaster == null)
            {
                return NotFound();
            }

            db.HazardMasters.Remove(hazardMaster);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.HazardMasters.Count(e => e.HazardId == key) > 0;
        }
    }
}