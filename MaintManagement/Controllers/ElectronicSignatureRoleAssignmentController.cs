using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignatureRoleAssignmentController : ODataController
    {
        private readonly CmmsContext db;

        public ElectronicSignatureRoleAssignmentController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<ElectronicSignatureRoleAssignment> Get()
        {
            return db.ElectronicSignatureRoleAssignments;
        }

        [EnableQuery]
        public async Task<SingleResult<ElectronicSignatureRoleAssignment>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(db.ElectronicSignatureRoleAssignments.Where(e => e.ElectronicSignatureRoleAssignmentId == key));
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignatureRoleAssignment electronicSignatureRoleAssignment)
        {
            
            db.ElectronicSignatureRoleAssignments.Add(electronicSignatureRoleAssignment);
            await db.SaveChangesAsync();

            return Created(electronicSignatureRoleAssignment);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ElectronicSignatureRoleAssignment electronicSignatureRoleAssignment)
        {
            
            if (key != electronicSignatureRoleAssignment.ElectronicSignatureRoleAssignmentId)
            {
                return BadRequest();
            }

            db.Entry(electronicSignatureRoleAssignment).State = EntityState.Modified;

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

            return Updated(electronicSignatureRoleAssignment);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ElectronicSignatureRoleAssignment> delta)
        {
            
            var entity = await db.ElectronicSignatureRoleAssignments.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            delta.Patch(entity);

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

            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var electronicSignatureRoleAssignment = await db.ElectronicSignatureRoleAssignments.FindAsync(key);
            if (electronicSignatureRoleAssignment == null)
            {
                return NotFound();
            }

            db.ElectronicSignatureRoleAssignments.Remove(electronicSignatureRoleAssignment);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.ElectronicSignatureRoleAssignments.Count(e => e.ElectronicSignatureRoleAssignmentId == key) > 0;
        }
    }
}