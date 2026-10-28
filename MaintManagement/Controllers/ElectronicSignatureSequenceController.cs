using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignatureSequenceController : ODataController
    {
        private readonly CmmsContext db;

        public ElectronicSignatureSequenceController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<ElectronicSignatureSequence> Get()
        {
            return db.ElectronicSignatureSequences;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            ElectronicSignatureSequence electronicSignatureSequence = await db.ElectronicSignatureSequences.FindAsync(key);
            if (electronicSignatureSequence == null)
            {
                return NotFound();
            }
            return Ok(electronicSignatureSequence);
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignatureSequence electronicSignatureSequence)
        {
            
            db.ElectronicSignatureSequences.Add(electronicSignatureSequence);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(electronicSignatureSequence.ElectronicSignatureSequenceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Created(electronicSignatureSequence);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ElectronicSignatureSequence electronicSignatureSequence)
        {
            
            if (key != electronicSignatureSequence.ElectronicSignatureSequenceId)
            {
                return BadRequest();
            }
            db.Entry(electronicSignatureSequence).State = EntityState.Modified;
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
            return Updated(electronicSignatureSequence);
        }

        public async Task<IActionResult> Patch(Guid key,[FromBody] Delta<ElectronicSignatureSequence> delta)
        {
            
            ElectronicSignatureSequence electronicSignatureSequence = await db.ElectronicSignatureSequences.FindAsync(key);
            if (electronicSignatureSequence == null)
            {
                return NotFound();
            }
            delta.Patch(electronicSignatureSequence);
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
            return Updated(electronicSignatureSequence);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            ElectronicSignatureSequence electronicSignatureSequence = await db.ElectronicSignatureSequences.FindAsync(key);
            if (electronicSignatureSequence == null)
            {
                return NotFound();
            }
            db.ElectronicSignatureSequences.Remove(electronicSignatureSequence);
            await db.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.ElectronicSignatureSequences.Count(e => e.ElectronicSignatureSequenceId == key) > 0;
        }
    }
}