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
    public class PermitEmployeeController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitEmployeeController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PermitEmployee> Get()
        {
            return _context.Set<PermitEmployee>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permitEmployee = await _context.Set<PermitEmployee>().FindAsync(key);
            if (permitEmployee == null)
            {
                return NotFound();
            }
            return Ok(permitEmployee);
        }

        public async Task<IActionResult> Post([FromBody] PermitEmployee permitEmployee)
        {
            

            _context.Set<PermitEmployee>().Add(permitEmployee);
            await _context.SaveChangesAsync();

            return Created(permitEmployee);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitEmployee permitEmployee)
        {
            

            if (key != permitEmployee.PermitEmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(permitEmployee).State = EntityState.Modified;

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

            return Updated(permitEmployee);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitEmployee> delta)
        {
            

            var permitEmployee = await _context.Set<PermitEmployee>().FindAsync(key);
            if (permitEmployee == null)
            {
                return NotFound();
            }

            delta.Patch(permitEmployee);

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

            return Updated(permitEmployee);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permitEmployee = await _context.Set<PermitEmployee>().FindAsync(key);
            if (permitEmployee == null)
            {
                return NotFound();
            }

            _context.Set<PermitEmployee>().Remove(permitEmployee);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PermitEmployee>().Count(e => e.PermitEmployeeId == key) > 0;
        }
    }
}