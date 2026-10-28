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
    public class WorkCenterController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkCenterController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkCenter> Get()
        {
            return _context.Set<WorkCenter>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var workCenter = await _context.Set<WorkCenter>().FindAsync(key);
            if (workCenter == null)
            {
                return NotFound();
            }
            return Ok(workCenter);
        }

        public async Task<IActionResult> Post([FromBody]  WorkCenter workCenter)
        {
            
            workCenter.WorkCenterId = Guid.NewGuid();
            _context.Set<WorkCenter>().Add(workCenter);
            await _context.SaveChangesAsync();

            return Created(workCenter);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] WorkCenter workCenter)
        {
            

            if (key != workCenter.WorkCenterId)
            {
                return BadRequest();
            }

            _context.Entry(workCenter).State = EntityState.Modified;

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

            return Updated(workCenter);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WorkCenter> workCenter)
        {
            

            var entity = await _context.Set<WorkCenter>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            workCenter.Patch(entity);

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

        public async Task<IActionResult> Delete(Guid key)
        {
            var workCenter = await _context.Set<WorkCenter>().FindAsync(key);
            if (workCenter == null)
            {
                return NotFound();
            }

            _context.Set<WorkCenter>().Remove(workCenter);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkCenter>().Count(e => e.WorkCenterId == key) > 0;
        }
    }
}