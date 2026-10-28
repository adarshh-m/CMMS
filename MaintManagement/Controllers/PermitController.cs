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
    public class PermitController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Permit> Get()
        {
            return _context.Permits;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permit = await _context.Permits.FindAsync(key);
            if (permit == null)
            {
                return NotFound();
            }
            return Ok(permit);
        }

        public async Task<IActionResult> Post([FromBody] Permit permit)
        {
           

            _context.Permits.Add(permit);
            await _context.SaveChangesAsync();

            return Created(permit);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] Permit update)
        {
           

            if (key != update.PermitId)
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

        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Permit> patch)
        {
            

            var permit = await _context.Permits.FindAsync(key);
            if (permit == null)
            {
                return NotFound();
            }

            patch.Patch(permit);

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

            return Updated(permit);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permit = await _context.Permits.FindAsync(key);
            if (permit == null)
            {
                return NotFound();
            }

            _context.Permits.Remove(permit);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Permits.Count(e => e.PermitId == key) > 0;
        }
    }
}