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
    public class PermitSignatureController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitSignatureController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PermitSignature> Get()
        {
            return _context.Set<PermitSignature>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permitSignature = await _context.Set<PermitSignature>().FindAsync(key);
            if (permitSignature == null)
            {
                return NotFound();
            }
            return Ok(permitSignature);
        }

        public async Task<IActionResult> Post([FromBody] PermitSignature permitSignature)
        {
            

            _context.Set<PermitSignature>().Add(permitSignature);
            await _context.SaveChangesAsync();

            return Created(permitSignature);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitSignature update)
        {
            

            if (key != update.PermitSignatureId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitSignature> delta)
        {
            

            var permitSignature = await _context.Set<PermitSignature>().FindAsync(key);
            if (permitSignature == null)
            {
                return NotFound();
            }

            delta.Patch(permitSignature);

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

            return Updated(permitSignature);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permitSignature = await _context.Set<PermitSignature>().FindAsync(key);
            if (permitSignature == null)
            {
                return NotFound();
            }

            _context.Set<PermitSignature>().Remove(permitSignature);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PermitSignature>().Any(e => e.PermitSignatureId == key);
        }
    }
}