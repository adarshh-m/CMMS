using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMExecutionReadingController : ODataController
    {
        private readonly CmmsContext db;

        public PMExecutionReadingController(CmmsContext context)
        {
            db = context;
        }
        // GET: odata/PMExecutionReading
        [EnableQuery]
        public IQueryable<PmexecutionReading> Get()
        {
            return db.PmexecutionReadings;
        }

        // GET: odata/PMExecutionReading(5)
        [EnableQuery]
        public SingleResult<PmexecutionReading> Get([FromBody] Guid key)
        {
            return SingleResult.Create(db.PmexecutionReadings.Where(p => p.PmexecutionReadingId == key));
        }

        // POST: odata/PMExecutionReading
        public async Task<IActionResult> Post([FromBody] PmexecutionReading pMExecutionReading)
        {
            

            db.PmexecutionReadings.Add(pMExecutionReading);
            await db.SaveChangesAsync();

            return Created(pMExecutionReading);
        }

        // PUT: odata/PMExecutionReading(5)
        public async Task<IActionResult> Put(Guid key, [FromBody] PmexecutionReading pMExecutionReading)
        {
            

            if (key != pMExecutionReading.PmexecutionReadingId)
            {
                return BadRequest();
            }

            db.Entry(pMExecutionReading).State = EntityState.Modified;

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

            return Updated(pMExecutionReading);
        }

        // PATCH: odata/PMExecutionReading(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<PmexecutionReading> delta)
        {
            

            PmexecutionReading pMExecutionReading = await db.PmexecutionReadings.FindAsync(key);
            if (pMExecutionReading == null)
            {
                return NotFound();
            }

            delta.Patch(pMExecutionReading);

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

            return Updated(pMExecutionReading);
        }

        // DELETE: odata/PMExecutionReading(5)
        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            PmexecutionReading pMExecutionReading = await db.PmexecutionReadings.FindAsync(key);
            if (pMExecutionReading == null)
            {
                return NotFound();
            }

            db.PmexecutionReadings.Remove(pMExecutionReading);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.PmexecutionReadings.Count(e => e.PmexecutionReadingId == key) > 0;
        }
    }
}