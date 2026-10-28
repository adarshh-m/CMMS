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
    public class MenuPermissionController : ODataController
    {
        private readonly CmmsContext _context;

        public MenuPermissionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<MenuPermission> Get()
        {
            return _context.Set<MenuPermission>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<MenuPermission>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] MenuPermission menuPermission)
        {
           

            _context.Set<MenuPermission>().Add(menuPermission);
            await _context.SaveChangesAsync();

            return Created(menuPermission);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] MenuPermission menuPermission)
        {
            

            if (key != menuPermission.MenuPermissionId)
            {
                return BadRequest();
            }

            _context.Entry(menuPermission).State = EntityState.Modified;

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

            return Updated(menuPermission);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<MenuPermission> delta)
        {
            

            var entity = await _context.Set<MenuPermission>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            delta.Patch(entity);

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

            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var entity = await _context.Set<MenuPermission>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<MenuPermission>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<MenuPermission>().Find(key) != null;
        }
    }
}