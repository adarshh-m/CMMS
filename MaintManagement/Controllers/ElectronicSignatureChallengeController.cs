using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignatureChallengeController : ODataController
    {
        private readonly CmmsContext db;

        public ElectronicSignatureChallengeController(CmmsContext context)
        {
            db = context;
        }
        // GET: odata/ElectronicSignatureChallenge
        [EnableQuery]
        public IQueryable<ElectronicSignatureChallenge> Get()
        {
            return db.ElectronicSignatureChallenges;
        }

        // GET: odata/ElectronicSignatureChallenge(5)
        [EnableQuery]
        public SingleResult<ElectronicSignatureChallenge> Get([FromBody] Guid key)
        {
            return SingleResult.Create(db.ElectronicSignatureChallenges.Where(e => e.ElectronicSignatureChallengeId == key));
        }

        // POST: odata/ElectronicSignatureChallenge
        public async Task<IActionResult> Post([FromBody] ElectronicSignatureChallenge electronicSignatureChallenge)
        {
            

            db.ElectronicSignatureChallenges.Add(electronicSignatureChallenge);
            await db.SaveChangesAsync();

            return Created(electronicSignatureChallenge);
        }

        // PUT: odata/ElectronicSignatureChallenge(5)
        public async Task<IActionResult> Put( Guid key, [FromBody] ElectronicSignatureChallenge electronicSignatureChallenge)
        {
            

            if (key != electronicSignatureChallenge.ElectronicSignatureChallengeId)
            {
                return BadRequest();
            }

            db.Entry(electronicSignatureChallenge).State = EntityState.Modified;

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

            return Updated(electronicSignatureChallenge);
        }

        // PATCH: odata/ElectronicSignatureChallenge(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ElectronicSignatureChallenge> delta)
        {
            
            ElectronicSignatureChallenge electronicSignatureChallenge = await db.ElectronicSignatureChallenges.FindAsync(key);
            if (electronicSignatureChallenge == null)
            {
                return NotFound();
            }

            delta.Patch(electronicSignatureChallenge);

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

            return Updated(electronicSignatureChallenge);
        }

        // DELETE: odata/ElectronicSignatureChallenge(5)
        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            ElectronicSignatureChallenge electronicSignatureChallenge = await db.ElectronicSignatureChallenges.FindAsync(key);
            if (electronicSignatureChallenge == null)
            {
                return NotFound();
            }

            db.ElectronicSignatureChallenges.Remove(electronicSignatureChallenge);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.ElectronicSignatureChallenges.Count(e => e.ElectronicSignatureChallengeId == key) > 0;
        }
    }
}