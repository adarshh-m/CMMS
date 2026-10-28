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
    public class PermitControlMeasureController : ODataController
    {
        
        private readonly CmmsContext db;

        public PermitControlMeasureController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<PermitControlMeasure> Get()
        {
            return db.PermitControlMeasures;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            PermitControlMeasure permitControlMeasure = await db.PermitControlMeasures.FindAsync(key);
            if (permitControlMeasure == null)
            {
                return NotFound();
            }
            return Ok(permitControlMeasure);
        }

        public async Task<IActionResult> Post([FromBody] PermitControlMeasure permitControlMeasure)
        {
            

            db.PermitControlMeasures.Add(permitControlMeasure);
            await db.SaveChangesAsync();

            return Created(permitControlMeasure);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] PermitControlMeasure permitControlMeasure)
        {
            

            if (key != permitControlMeasure.PermitControlMeasureId)
            {
                return BadRequest();
            }

            db.Entry(permitControlMeasure).State = EntityState.Modified;

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

            return Updated(permitControlMeasure);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitControlMeasure> delta)
        {
           

            PermitControlMeasure permitControlMeasure = await db.PermitControlMeasures.FindAsync(key);
            if (permitControlMeasure == null)
            {
                return NotFound();
            }

            delta.Patch(permitControlMeasure);

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

            return Updated(permitControlMeasure);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            PermitControlMeasure permitControlMeasure = await db.PermitControlMeasures.FindAsync(key);
            if (permitControlMeasure == null)
            {
                return NotFound();
            }

            db.PermitControlMeasures.Remove(permitControlMeasure);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.PermitControlMeasures.Count(e => e.PermitControlMeasureId == key) > 0;
        }
    }
}