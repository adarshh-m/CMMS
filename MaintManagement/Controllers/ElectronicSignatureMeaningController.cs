using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignatureMeaningController : ODataController
    {
        private readonly CmmsContext _context;

        public ElectronicSignatureMeaningController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ElectronicSignatureMeaning> Get()
        {
            return _context.Set<ElectronicSignatureMeaning>();
        }

        [EnableQuery]
        public async Task<SingleResult<ElectronicSignatureMeaning>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<ElectronicSignatureMeaning>().Where(e => e.ElectronicSignatureMeaningId == key));
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignatureMeaning electronicSignatureMeaning)
        {
            
            _context.Set<ElectronicSignatureMeaning>().Add(electronicSignatureMeaning);
            await _context.SaveChangesAsync();

            return Created(electronicSignatureMeaning);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ElectronicSignatureMeaning electronicSignatureMeaning)
        {
           
            if (key != electronicSignatureMeaning.ElectronicSignatureMeaningId)
            {
                return BadRequest();
            }

            _context.Entry(electronicSignatureMeaning).State = EntityState.Modified;

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

            return Updated(electronicSignatureMeaning);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ElectronicSignatureMeaning> delta)
        {
           
            var entity = await _context.Set<ElectronicSignatureMeaning>().FindAsync(key);
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
            var electronicSignatureMeaning = await _context.Set<ElectronicSignatureMeaning>().FindAsync(key);
            if (electronicSignatureMeaning == null)
            {
                return NotFound();
            }

            _context.Set<ElectronicSignatureMeaning>().Remove(electronicSignatureMeaning);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ElectronicSignatureMeaning>().Count(e => e.ElectronicSignatureMeaningId == key) > 0;
        }
    }
}