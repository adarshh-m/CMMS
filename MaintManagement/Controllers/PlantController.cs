using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 

namespace YourNamespace.Controllers
{
    public class PlantController : ODataController
    {
        //private CmmsContext db;

        //public PlantController()
        //{
        //    db = new CmmsContext();
        //}

        
        private readonly CmmsContext db;

        public PlantController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<Plant> Get()
        {
            return db.Plants;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            Plant plant = await db.Plants.FindAsync(key);
            if (plant == null)
            {
                return NotFound();
            }
            return Ok(plant);
        }

        public async Task<IActionResult> Post([FromBody] Plant plant)
        {
            ModelState.Remove("Tenant");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plants.Add(plant);
            await db.SaveChangesAsync();

            return Created(plant);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] Plant update)
        {
            ModelState.Remove("Tenant");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != update.PlantId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Plant> patch)
        {
            ModelState.Remove("Tenant");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Plant plant = await db.Plants.FindAsync(key);
            if (plant == null)
            {
                return NotFound();
            }

            patch.Patch(plant);

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

            return Updated(plant);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            Plant plant = await db.Plants.FindAsync(key);
            if (plant == null)
            {
                return NotFound();
            }

            db.Plants.Remove(plant);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.Plants.Count(e => e.PlantId == key) > 0;
        }
    }
}