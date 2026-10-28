using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMForecastController : ODataController
    {
        private readonly CmmsContext _context;

        public PMForecastController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Pmforecast> Get()
        {
            return _context.Set<Pmforecast>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<Pmforecast>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] Pmforecast pMForecast)
        {
            

            _context.Set<Pmforecast>().Add(pMForecast);
            await _context.SaveChangesAsync();

            return Created(pMForecast);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] Pmforecast pMForecast)
        {
            

            if (key != pMForecast.PmforecastId)
            {
                return BadRequest();
            }

            _context.Entry(pMForecast).State = EntityState.Modified;

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

            return Updated(pMForecast);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Pmforecast> delta)
        {
            

            var entity = await _context.Set<Pmforecast>().FindAsync(key);
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
            var entity = await _context.Set<Pmforecast>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<Pmforecast>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Pmforecast>().Find(key) != null;
        }
    }
}