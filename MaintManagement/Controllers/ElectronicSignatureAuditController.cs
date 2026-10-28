using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignatureAuditController : ODataController
    {
        private readonly CmmsContext db;

        public ElectronicSignatureAuditController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<ElectronicSignatureAudit> Get()
        {
            return db.ElectronicSignatureAudits;
        }

        [EnableQuery]
        public async Task<SingleResult<ElectronicSignatureAudit>> Get([FromBody] long key)
        {
            return SingleResult.Create(db.ElectronicSignatureAudits.Where(electronicSignatureAudit => electronicSignatureAudit.ElectronicSignatureAuditId == key));
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignatureAudit electronicSignatureAudit)
        {
            
            db.ElectronicSignatureAudits.Add(electronicSignatureAudit);
            await db.SaveChangesAsync();

            return Created(electronicSignatureAudit);
        }

        public async Task<IActionResult> Put( long key, [FromBody] ElectronicSignatureAudit electronicSignatureAudit)
        {
            
            if (key != electronicSignatureAudit.ElectronicSignatureAuditId)
            {
                return BadRequest();
            }

            db.Entry(electronicSignatureAudit).State = EntityState.Modified;

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

            return Updated(electronicSignatureAudit);
        }

        public async Task<IActionResult> Patch(long key, [FromBody] Delta<ElectronicSignatureAudit> delta)
        {
            
            ElectronicSignatureAudit electronicSignatureAudit = await db.ElectronicSignatureAudits.FindAsync(key);
            if (electronicSignatureAudit == null)
            {
                return NotFound();
            }

            delta.Patch(electronicSignatureAudit);

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

            return Updated(electronicSignatureAudit);
        }

        public async Task<IActionResult> Delete([FromBody] long key)
        {
            ElectronicSignatureAudit electronicSignatureAudit = await db.ElectronicSignatureAudits.FindAsync(key);
            if (electronicSignatureAudit == null)
            {
                return NotFound();
            }

            db.ElectronicSignatureAudits.Remove(electronicSignatureAudit);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(long key)
        {
            return db.ElectronicSignatureAudits.Any(e => e.ElectronicSignatureAuditId == key);
        }
    }
}