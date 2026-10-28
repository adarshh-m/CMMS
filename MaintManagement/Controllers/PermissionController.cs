using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
 
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 

namespace YourNamespace.Controllers
{
    public class PermissionController : ODataController
    {
        private readonly CmmsContext _context;

        public PermissionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Permission> Get()
        {
            return _context.Set<Permission>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permission = await _context.Set<Permission>().FindAsync(key);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        public async Task<IActionResult> Post(Permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Set<Permission>().Add(permission);
            await _context.SaveChangesAsync();

            return Created(permission);
        }

        public async Task<IActionResult> Put([FromBody] Guid key, Permission update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != update.PermissionId)
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

        public async Task<IActionResult> Patch([FromBody] Guid key, Delta<Permission> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permission = await _context.Set<Permission>().FindAsync(key);
            if (permission == null)
            {
                return NotFound();
            }

            patch.Patch(permission);

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

            return Updated(permission);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permission = await _context.Set<Permission>().FindAsync(key);
            if (permission == null)
            {
                return NotFound();
            }

            _context.Set<Permission>().Remove(permission);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Permission>().Find(key) != null;
        }
    }
}