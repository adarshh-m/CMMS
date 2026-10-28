using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class RolesController : ODataController
    {
        private readonly CmmsContext _context;

        public RolesController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Role> Get()
        {
            return _context.Roles;
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var role = await _context.Roles.FindAsync(key);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        public async Task<IActionResult> Post([FromBody] Role role)
        {
           role.RoleId =Guid.NewGuid();
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return Created(role);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] Role update)
        {
           
            if (key != update.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(update).State = EntityState.Modified;

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

            return Updated(update);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Role> patch)
        {
            
            var role = await _context.Roles.FindAsync(key);
            if (role == null)
            {
                return NotFound();
            }

            patch.Patch(role);

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

            return Updated(role);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var role = await _context.Roles.FindAsync(key);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Roles.Any(e => e.RoleId == key);
        }
    }
}