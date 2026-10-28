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
    public class CauseCodeController : ODataController
    {
        private readonly CmmsContext db;

        public CauseCodeController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<CauseCode> Get()
        {
            return db.CauseCodes;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            CauseCode causeCode = await db.CauseCodes.FindAsync(key);
            if (causeCode == null)
            {
                return NotFound();
            }
            return Ok(causeCode);
        }

        public async Task<IActionResult> Post([FromBody] CauseCode causeCode)
        {
            

            db.CauseCodes.Add(causeCode);
            await db.SaveChangesAsync();

            return Created(causeCode);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] CauseCode causeCode)
        {
            
            if (key != causeCode.CauseCodeId)
            {
                return BadRequest();
            }

            db.Entry(causeCode).State = EntityState.Modified;

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

            return Updated(causeCode);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<CauseCode> delta)
        {
            
            CauseCode causeCode = await db.CauseCodes.FindAsync(key);
            if (causeCode == null)
            {
                return NotFound();
            }

            delta.Patch(causeCode);

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

            return Updated(causeCode);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            CauseCode causeCode = await db.CauseCodes.FindAsync(key);
            if (causeCode == null)
            {
                return NotFound();
            }

            db.CauseCodes.Remove(causeCode);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.CauseCodes.Count(e => e.CauseCodeId == key) > 0;
        }
    }
}