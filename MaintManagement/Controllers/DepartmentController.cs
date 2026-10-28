using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class DepartmentController : ODataController
    {
        private readonly CmmsContext _context;

        public DepartmentController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Department> Get()
        {
            return _context.Set<Department>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var department = await _context.Set<Department>().FindAsync(key);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        public async Task<IActionResult> Post([FromBody] Department department)
        {
            department.DepartmentId= Guid.NewGuid();
            _context.Set<Department>().Add(department);
            await _context.SaveChangesAsync();

            return Created(department);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] Department update)
        {
            

            if (key != update.DepartmentId)
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

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<Department> patch)
        {
          

            var department = await _context.Set<Department>().FindAsync(key);
            if (department == null)
            {
                return NotFound();
            }

            patch.Patch(department);

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

            return Updated(department);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var department = await _context.Set<Department>().FindAsync(key);
            if (department == null)
            {
                return NotFound();
            }

            _context.Set<Department>().Remove(department);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Department>().Find(key) != null;
        }
    }
}