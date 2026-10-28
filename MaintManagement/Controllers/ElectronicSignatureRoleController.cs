using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignatureRoleController : ODataController
    {
        private readonly CmmsContext db;

        public ElectronicSignatureRoleController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<ElectronicSignatureRole> Get()
        {
            return db.ElectronicSignatureRoles;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            ElectronicSignatureRole electronicSignatureRole = await db.ElectronicSignatureRoles.FindAsync(key);
            if (electronicSignatureRole == null)
            {
                return NotFound();
            }
            return Ok(electronicSignatureRole);
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignatureRole electronicSignatureRole)
        {
            
            db.ElectronicSignatureRoles.Add(electronicSignatureRole);
            await db.SaveChangesAsync();

            return Created(electronicSignatureRole);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ElectronicSignatureRole electronicSignatureRole)
        {
            
            if (key != electronicSignatureRole.ElectronicSignatureRoleId)
            {
                return BadRequest();
            }

            db.Entry(electronicSignatureRole).State = EntityState.Modified;

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

            return Updated(electronicSignatureRole);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ElectronicSignatureRole> delta)
        {
            
            ElectronicSignatureRole electronicSignatureRole = await db.ElectronicSignatureRoles.FindAsync(key);
            if (electronicSignatureRole == null)
            {
                return NotFound();
            }

            delta.Patch(electronicSignatureRole);

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

            return Updated(electronicSignatureRole);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            ElectronicSignatureRole electronicSignatureRole = await db.ElectronicSignatureRoles.FindAsync(key);
            if (electronicSignatureRole == null)
            {
                return NotFound();
            }

            db.ElectronicSignatureRoles.Remove(electronicSignatureRole);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.ElectronicSignatureRoles.Count(e => e.ElectronicSignatureRoleId == key) > 0;
        }
    }
}