using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 

namespace YourNamespace.Controllers
{
    public class MaterialController : ODataController
    {
        //private CmmsContext db = new CmmsContext();

        
        private readonly CmmsContext db;

        public MaterialController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<Material> Get()
        {
            return db.Materials;
        }
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            Material material = await db.Materials.FindAsync(key);
            if (material == null)
            {
                return NotFound();
            }
            return Ok(material);
        }

        public async Task<IActionResult> Post([FromBody] Material material)
        {
            ModelState.Remove("Tenant");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materials.Add(material);
            await db.SaveChangesAsync();

            return Created(material);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] Material update)
        {
            ModelState.Remove("Tenant");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != update.MaterialId)
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

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<Material> patch)
        {
            ModelState.Remove("Tenant");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Material material = await db.Materials.FindAsync(key);
            if (material == null)
            {
                return NotFound();
            }

            patch.Patch(material);

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

            return Updated(material);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            Material material = await db.Materials.FindAsync(key);
            if (material == null)
            {
                return NotFound();
            }

            db.Materials.Remove(material);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.Materials.Count(e => e.MaterialId == key) > 0;
        }
    }
}