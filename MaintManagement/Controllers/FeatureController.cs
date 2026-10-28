using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class FeatureController : ODataController
    {
        private readonly CmmsContext db;

        public FeatureController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<Feature> Get()
        {
            return db.Features;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            Feature feature = await db.Features.FindAsync(key);
            if (feature == null)
            {
                return NotFound();
            }
            return Ok(feature);
        }

        public async Task<IActionResult> Post([FromBody] Feature feature)
        {
            
            db.Features.Add(feature);
            await db.SaveChangesAsync();

            return Created(feature);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] Feature update)
        {
            
            if (key != update.FeatureId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Feature> patch)
        {
            
            Feature feature = await db.Features.FindAsync(key);
            if (feature == null)
            {
                return NotFound();
            }

            patch.Patch(feature);

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

            return Updated(feature);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            Feature feature = await db.Features.FindAsync(key);
            if (feature == null)
            {
                return NotFound();
            }

            db.Features.Remove(feature);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.Features.Count(e => e.FeatureId == key) > 0;
        }
    }
}