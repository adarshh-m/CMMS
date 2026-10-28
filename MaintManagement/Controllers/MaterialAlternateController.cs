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
    public class MaterialAlternateController : ODataController
    {
        private readonly CmmsContext db;

        public MaterialAlternateController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<MaterialAlternate> Get()
        {
            return db.MaterialAlternates;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            MaterialAlternate materialAlternate = await db.MaterialAlternates.FindAsync(key);
            if (materialAlternate == null)
            {
                return NotFound();
            }
            return Ok(materialAlternate);
        }

        public async Task<IActionResult> Post([FromBody] MaterialAlternate materialAlternate)
        {
            

            db.MaterialAlternates.Add(materialAlternate);
            await db.SaveChangesAsync();

            return Created(materialAlternate);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] MaterialAlternate materialAlternate)
        {
            

            if (key != materialAlternate.MaterialAlternateId)
            {
                return BadRequest();
            }

            db.Entry(materialAlternate).State = EntityState.Modified;

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

            return Updated(materialAlternate);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<MaterialAlternate> delta)
        {
           

            MaterialAlternate materialAlternate = await db.MaterialAlternates.FindAsync(key);
            if (materialAlternate == null)
            {
                return NotFound();
            }

            delta.Patch(materialAlternate);

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

            return Updated(materialAlternate);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            MaterialAlternate materialAlternate = await db.MaterialAlternates.FindAsync(key);
            if (materialAlternate == null)
            {
                return NotFound();
            }

            db.MaterialAlternates.Remove(materialAlternate);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.MaterialAlternates.Count(e => e.MaterialAlternateId == key) > 0;
        }
    }
}