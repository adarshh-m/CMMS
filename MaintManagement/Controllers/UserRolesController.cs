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
    public class UserRolesController : ODataController
    {
        private readonly CmmsContext db;

        public UserRolesController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<UserRole> Get()
        {
            return db.UserRoles;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            UserRole userRole = await db.UserRoles.FindAsync(key);
            if (userRole == null)
            {
                return NotFound();
            }
            return Ok(userRole);
        }

        public async Task<IActionResult> Post([FromBody] UserRole userRole)
        {
            
            userRole.UserRoleId = Guid.NewGuid();
            db.UserRoles.Add(userRole);
            await db.SaveChangesAsync();

            return Created(userRole);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] UserRole userRole)
        {
           

            if (key != userRole.UserRoleId)
            {
                return BadRequest();
            }

            db.Entry(userRole).State = EntityState.Modified;

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

            return Updated(userRole);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<UserRole> patch)
        {
            

            UserRole userRole = await db.UserRoles.FindAsync(key);
            if (userRole == null)
            {
                return NotFound();
            }

            patch.Patch(userRole);

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

            return Updated(userRole);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            UserRole userRole = await db.UserRoles.FindAsync(key);
            if (userRole == null)
            {
                return NotFound();
            }

            db.UserRoles.Remove(userRole);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.UserRoles.Count(e => e.UserRoleId == key) > 0;
        }
    }
}