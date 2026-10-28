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
    public class PermitClosureController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitClosureController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PermitClosure> Get()
        {
            return _context.PermitClosures;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permitClosure = await _context.PermitClosures.FindAsync(key);
            if (permitClosure == null)
            {
                return NotFound();
            }
            return Ok(permitClosure);
        }

        public async Task<IActionResult> Post([FromBody] PermitClosure permitClosure)
        {
           

            _context.PermitClosures.Add(permitClosure);
            await _context.SaveChangesAsync();

            return Created(permitClosure);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitClosure update)
        {
            

            if (key != update.PermitClosureId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitClosure> patch)
        {
            

            var permitClosure = await _context.PermitClosures.FindAsync(key);
            if (permitClosure == null)
            {
                return NotFound();
            }

            patch.Patch(permitClosure);

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

            return Updated(permitClosure);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permitClosure = await _context.PermitClosures.FindAsync(key);
            if (permitClosure == null)
            {
                return NotFound();
            }

            _context.PermitClosures.Remove(permitClosure);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.PermitClosures.Any(e => e.PermitClosureId == key);
        }
    }
}