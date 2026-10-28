using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 

namespace YourNamespace.Controllers
{
    public class AbcclassificationController : ODataController
    {
        //private CmmsContext db;

        //public ABCClassificationController()
        //{
        //    db = new CmmsContext();
        //}

        private readonly CmmsContext db;

        public AbcclassificationController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<Abcclassification> Get()
        {
            return db.Abcclassifications;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            Abcclassification abcClassification = await db.Abcclassifications.FindAsync(key);
            if (abcClassification == null)
            {
                return NotFound();
            }
            return Ok(abcClassification);
        }

        public async Task<IActionResult> Post([FromBody] Abcclassification abcClassification)
        {

            abcClassification.AbcclassificationId = Guid.NewGuid();

            db.Abcclassifications.Add(abcClassification);
            await db.SaveChangesAsync();

            return Created(abcClassification);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] Abcclassification abcClassification)
        {
            

            if (key != abcClassification.AbcclassificationId)
            {
                return BadRequest();
            }

            db.Entry(abcClassification).State = EntityState.Modified;

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

            return Updated(abcClassification);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<Abcclassification> delta)
        {
            

            Abcclassification abcClassification = await db.Abcclassifications.FindAsync(key);
            if (abcClassification == null)
            {
                return NotFound();
            }

            delta.Patch(abcClassification);

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

            return Updated(abcClassification);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            Abcclassification abcClassification = await db.Abcclassifications.FindAsync(key);
            if (abcClassification == null)
            {
                return NotFound();
            }

            db.Abcclassifications.Remove(abcClassification);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        

        private bool Exists(Guid key)
        {
            return db.Abcclassifications.Any(e => e.AbcclassificationId == key);
        }
    }
}