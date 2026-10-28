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
    public class PermitWorkIsolationController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitWorkIsolationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PermitWorkIsolation> Get()
        {
            return _context.PermitWorkIsolations;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.PermitWorkIsolations.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] PermitWorkIsolation permitWorkIsolation)
        {
            

            _context.PermitWorkIsolations.Add(permitWorkIsolation);
            await _context.SaveChangesAsync();

            return Created(permitWorkIsolation);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitWorkIsolation permitWorkIsolation)
        {
            

            if (key != permitWorkIsolation.PermitWorkIsolationId)
            {
                return BadRequest();
            }

            _context.Entry(permitWorkIsolation).State = EntityState.Modified;

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

            return Updated(permitWorkIsolation);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitWorkIsolation> delta)
        {
            

            var entity = await _context.PermitWorkIsolations.FindAsync(key);
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
            var entity = await _context.PermitWorkIsolations.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.PermitWorkIsolations.Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.PermitWorkIsolations.Any(e => e.PermitWorkIsolationId == key);
        }
    }
}