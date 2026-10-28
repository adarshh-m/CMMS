using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class RolePermissionController : ODataController
    {
        private readonly CmmsContext _context;

        public RolePermissionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<RolePermission> Get()
        {
            return _context.Set<RolePermission>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var rolePermission = await _context.Set<RolePermission>().FindAsync(key);
            if (rolePermission == null)
            {
                return NotFound();
            }
            return Ok(rolePermission);
        }

        public async Task<IActionResult> Post([FromBody] RolePermission rolePermission)
        {
            
            rolePermission.RolePermissionId = Guid.NewGuid();
            _context.Set<RolePermission>().Add(rolePermission);
            await _context.SaveChangesAsync();

            return Created(rolePermission);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] RolePermission rolePermission)
        {
            

            if (key != rolePermission.RolePermissionId)
            {
                return BadRequest();
            }

            _context.Entry(rolePermission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return Updated(rolePermission);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<RolePermission> patch)
        {
            
            var rolePermission = await _context.Set<RolePermission>().FindAsync(key);
            if (rolePermission == null)
            {
                return NotFound();
            }

            patch.Patch(rolePermission);

            try
            {
                await _context.SaveChangesAsync();
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

            return Updated(rolePermission);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var rolePermission = await _context.Set<RolePermission>().FindAsync(key);
            if (rolePermission == null)
            {
                return NotFound();
            }

            _context.Set<RolePermission>().Remove(rolePermission);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<RolePermission>().Count(e => e.RolePermissionId == key) > 0;
        }
    }
}