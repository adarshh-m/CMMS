using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMGenerationLogController : ODataController
    {
        private readonly CmmsContext db;

        public PMGenerationLogController(CmmsContext context)
        {
            db = context;
        }
        // GET: odata/PMGenerationLog
        [EnableQuery]
        public IQueryable<PmgenerationLog> Get()
        {
            return db.PmgenerationLogs;
        }

        // GET: odata/PMGenerationLog(5d23d1b4-0c8e-4a6c-b9c1-8f0e7b1a2d3e)
        [EnableQuery]
        public SingleResult<PmgenerationLog> Get([FromBody] Guid key)
        {
            return SingleResult.Create(db.PmgenerationLogs.Where(p => p.PmgenerationLogId == key));
        }

        // POST: odata/PMGenerationLog
        public async Task<IActionResult> Post([FromBody] PmgenerationLog pMGenerationLog)
        {
            

            db.PmgenerationLogs.Add(pMGenerationLog);
            await db.SaveChangesAsync();

            return Created(pMGenerationLog);
        }

        // PUT: odata/PMGenerationLog(5d23d1b4-0c8e-4a6c-b9c1-8f0e7b1a2d3e)
        public async Task<IActionResult> Put( Guid key, [FromBody] PmgenerationLog pMGenerationLog)
        {
           

            if (key != pMGenerationLog.PmgenerationLogId)
            {
                return BadRequest();
            }

            db.Entry(pMGenerationLog).State = EntityState.Modified;

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

            return Updated(pMGenerationLog);
        }

        // PATCH: odata/PMGenerationLog(5d23d1b4-0c8e-4a6c-b9c1-8f0e7b1a2d3e)
        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<PmgenerationLog> patch)
        {
            

            PmgenerationLog pMGenerationLog = await db.PmgenerationLogs.FindAsync(key);
            if (pMGenerationLog == null)
            {
                return NotFound();
            }

            patch.Patch(pMGenerationLog);

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

            return Updated(pMGenerationLog);
        }

        // DELETE: odata/PMGenerationLog(5d23d1b4-0c8e-4a6c-b9c1-8f0e7b1a2d3e)
        public async Task<IActionResult> DeletePMGenerationLog([FromBody] Guid key)
        {
            PmgenerationLog pMGenerationLog = await db.PmgenerationLogs.FindAsync(key);
            if (pMGenerationLog == null)
            {
                return NotFound();
            }

            db.PmgenerationLogs.Remove(pMGenerationLog);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.PmgenerationLogs.Count(e => e.PmgenerationLogId == key) > 0;
        }
    }
}