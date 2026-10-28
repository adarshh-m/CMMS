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
    public class PermitHazardController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitHazardController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.PermitHazards.ToListAsync());
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permitHazard = await _context.PermitHazards.FindAsync(key);
            if (permitHazard == null)
            {
                return NotFound();
            }
            return Ok(permitHazard);
        }

        public async Task<IActionResult> Post([FromBody] PermitHazard permitHazard)
        {


            _context.PermitHazards.Add(permitHazard);
            await _context.SaveChangesAsync();

            return Created(permitHazard);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitHazard update)
        {
           

            if (key != update.PermitHazardId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitHazard> patch)
        {
            

            var permitHazard = await _context.PermitHazards.FindAsync(key);
            if (permitHazard == null)
            {
                return NotFound();
            }

            patch.Patch(permitHazard);

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

            return Updated(permitHazard);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permitHazard = await _context.PermitHazards.FindAsync(key);
            if (permitHazard == null)
            {
                return NotFound();
            }

            _context.PermitHazards.Remove(permitHazard);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.PermitHazards.Any(e => e.PermitHazardId == key);
        }
    }
}