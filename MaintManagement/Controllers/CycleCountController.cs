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
    public class CycleCountController : ODataController
    {
        private readonly CmmsContext _context;

        public CycleCountController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<CycleCount> Get()
        {
            return _context.Set<CycleCount>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var cycleCount = await _context.Set<CycleCount>().FindAsync(key);
            if (cycleCount == null)
            {
                return NotFound();
            }
            return Ok(cycleCount);
        }

        public async Task<IActionResult> Post([FromBody] CycleCount cycleCount)
        {
            

            _context.Set<CycleCount>().Add(cycleCount);
            await _context.SaveChangesAsync();

            return Created(cycleCount);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] CycleCount cycleCount)
        {
            

            if (key != cycleCount.CycleCountId)
            {
                return BadRequest();
            }

            _context.Entry(cycleCount).State = EntityState.Modified;

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

            return Updated(cycleCount);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<CycleCount> cycleCount)
        {
            

            var entity = await _context.Set<CycleCount>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            cycleCount.Patch(entity);

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
            var cycleCount = await _context.Set<CycleCount>().FindAsync(key);
            if (cycleCount == null)
            {
                return NotFound();
            }

            _context.Set<CycleCount>().Remove(cycleCount);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CycleCount>().Any(e => e.CycleCountId == key);
        }
    }
}