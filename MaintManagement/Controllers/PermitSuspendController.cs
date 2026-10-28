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
    public class PermitSuspendController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitSuspendController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PermitSuspend> Get()
        {
            return _context.Set<PermitSuspend>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permitSuspend = await _context.Set<PermitSuspend>().FindAsync(key);
            if (permitSuspend == null)
            {
                return NotFound();
            }
            return Ok(permitSuspend);
        }

        public async Task<IActionResult> Post([FromBody] PermitSuspend permitSuspend)
        {
            

            _context.Set<PermitSuspend>().Add(permitSuspend);
            await _context.SaveChangesAsync();

            return Created(permitSuspend);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitSuspend permitSuspend)
        {
            

            if (key != permitSuspend.PermitSuspendId)
            {
                return BadRequest();
            }

            _context.Entry(permitSuspend).State = EntityState.Modified;

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

            return Updated(permitSuspend);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitSuspend> delta)
        {
            

            var permitSuspend = await _context.Set<PermitSuspend>().FindAsync(key);
            if (permitSuspend == null)
            {
                return NotFound();
            }

            delta.Patch(permitSuspend);

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

            return Updated(permitSuspend);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permitSuspend = await _context.Set<PermitSuspend>().FindAsync(key);
            if (permitSuspend == null)
            {
                return NotFound();
            }

            _context.Set<PermitSuspend>().Remove(permitSuspend);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PermitSuspend>().Count(e => e.PermitSuspendId == key) > 0;
        }
    }
}