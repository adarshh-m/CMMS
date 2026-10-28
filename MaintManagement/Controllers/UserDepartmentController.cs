using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class UserDepartmentController : ODataController
    {
        private readonly CmmsContext db;

        public UserDepartmentController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<UserDepartment> Get()
        {
            return db.UserDepartments;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            UserDepartment userDepartment = await db.UserDepartments.FindAsync(key);
            if (userDepartment == null)
            {
                return NotFound();
            }
            return Ok(userDepartment);
        }

        public async Task<IActionResult> Post([FromBody] UserDepartment userDepartment)
        {
            userDepartment.UserDepartmentId = Guid.NewGuid();
            db.UserDepartments.Add(userDepartment);
            await db.SaveChangesAsync();

            return Created(userDepartment);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] UserDepartment userDepartment)
        {
            

            if (key != userDepartment.UserDepartmentId)
            {
                return BadRequest();
            }

            db.Entry(userDepartment).State = EntityState.Modified;

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

            return Updated(userDepartment);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<UserDepartment> patch)
        {
            

            UserDepartment userDepartment = await db.UserDepartments.FindAsync(key);
            if (userDepartment == null)
            {
                return NotFound();
            }

            patch.Patch(userDepartment);

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

            return Updated(userDepartment);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            UserDepartment userDepartment = await db.UserDepartments.FindAsync(key);
            if (userDepartment == null)
            {
                return NotFound();
            }

            db.UserDepartments.Remove(userDepartment);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.UserDepartments.Count(e => e.UserDepartmentId == key) > 0;
        }
    }
}