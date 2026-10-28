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
    public class LookupBaseController : ODataController
    {
        //private CmmsContext db;

        //public LookupBaseController()
        //{
        //    db = new CmmsContext();
        //}

        private readonly CmmsContext db;

        public LookupBaseController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<LookupBase> Get()
        {
            return db.LookupBases;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            LookupBase lookupBase = await db.LookupBases.FindAsync(key);
            if (lookupBase == null)
            {
                return NotFound();
            }
            return Ok(lookupBase);
        }

        public async Task<IActionResult> Post([FromBody] LookupBase lookupBase)
        {
            //ModelState.Remove("Tenant");

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.LookupBases.Add(lookupBase);
            await db.SaveChangesAsync();

            return Created(lookupBase);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] LookupBase update)
        {
            //ModelState.Remove("Tenant");

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != update.LookupId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<LookupBase> patch)
        {
            //ModelState.Remove("Tenant");

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            LookupBase lookupBase = await db.LookupBases.FindAsync(key);
            if (lookupBase == null)
            {
                return NotFound();
            }

            patch.Patch(lookupBase);

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

            return Updated(lookupBase);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            LookupBase lookupBase = await db.LookupBases.FindAsync(key);
            if (lookupBase == null)
            {
                return NotFound();
            }

            db.LookupBases.Remove(lookupBase);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.LookupBases.Count(e => e.LookupId == key) > 0;
        }
    }
}