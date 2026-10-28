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
    public class PermitExtensionController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitExtensionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PermitExtension> Get()
        {
            return _context.Set<PermitExtension>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permitExtension = await _context.Set<PermitExtension>().FindAsync(key);
            if (permitExtension == null)
            {
                return NotFound();
            }
            return Ok(permitExtension);
        }

        public async Task<IActionResult> Post([FromBody] PermitExtension permitExtension)
        {
            

            _context.Set<PermitExtension>().Add(permitExtension);
            await _context.SaveChangesAsync();

            return Created(permitExtension);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitExtension update)
        {
            

            if (key != update.PermitExtensionId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitExtension> patch)
        {
            

            var permitExtension = await _context.Set<PermitExtension>().FindAsync(key);
            if (permitExtension == null)
            {
                return NotFound();
            }

            patch.Patch(permitExtension);

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

            return Updated(permitExtension);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permitExtension = await _context.Set<PermitExtension>().FindAsync(key);
            if (permitExtension == null)
            {
                return NotFound();
            }

            _context.Set<PermitExtension>().Remove(permitExtension);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PermitExtension>().Any(e => e.PermitExtensionId == key);
        }
    }
}