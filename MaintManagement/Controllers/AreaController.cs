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
    public class AreaController : ODataController
    {
        private readonly CmmsContext _context;

        public AreaController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Area> Get()
        {
            return _context.Set<Area>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var area = await _context.Set<Area>().FindAsync(key);
            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        public async Task<IActionResult> Post([FromBody] Area area)
        {
            
            area.AreaId=Guid.NewGuid();
            _context.Set<Area>().Add(area);
            await _context.SaveChangesAsync();

            return Created(area);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] Area update)
        {
            

            if (key != update.AreaId)
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

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<Area> patch)
        {

            

            var area = await _context.Set<Area>().FindAsync(key);
            if (area == null)
            {
                return NotFound();
            }

            patch.Patch(area);

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

            return Updated(area);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var area = await _context.Set<Area>().FindAsync(key);
            if (area == null)
            {
                return NotFound();
            }

            _context.Set<Area>().Remove(area);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Area>().Count(e => e.AreaId == key) > 0;
        }
    }
}