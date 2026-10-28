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
    public class BreakdownVerificationController : ODataController
    {
        private readonly CmmsContext _context;

        public BreakdownVerificationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<BreakdownVerification> Get()
        {
            return _context.Set<BreakdownVerification>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<BreakdownVerification>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] BreakdownVerification breakdownVerification)
        {
            

            _context.Set<BreakdownVerification>().Add(breakdownVerification);
            await _context.SaveChangesAsync();

            return Created(breakdownVerification);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] BreakdownVerification breakdownVerification)
        {
           

            if (key != breakdownVerification.VerificationId)
            {
                return BadRequest();
            }

            _context.Entry(breakdownVerification).State = EntityState.Modified;

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

            return Updated(breakdownVerification);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<BreakdownVerification> patch)
        {
           

            var entity = await _context.Set<BreakdownVerification>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

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
            var entity = await _context.Set<BreakdownVerification>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<BreakdownVerification>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<BreakdownVerification>().Count(e => e.VerificationId == key) > 0;
        }
    }
}