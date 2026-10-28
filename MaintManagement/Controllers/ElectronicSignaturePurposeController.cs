using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignaturePurposeController : ODataController
    {
        private readonly CmmsContext _context;

        public ElectronicSignaturePurposeController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ElectronicSignaturePurpose> Get()
        {
            return _context.Set<ElectronicSignaturePurpose>();
        }

        [EnableQuery]
        public async Task<SingleResult<ElectronicSignaturePurpose>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<ElectronicSignaturePurpose>().Where(e => e.ElectronicSignaturePurposeId == key));
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignaturePurpose electronicSignaturePurpose)
        {
            
            _context.Set<ElectronicSignaturePurpose>().Add(electronicSignaturePurpose);
            await _context.SaveChangesAsync();

            return Created(electronicSignaturePurpose);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ElectronicSignaturePurpose electronicSignaturePurpose)
        {
            
            if (key != electronicSignaturePurpose.ElectronicSignaturePurposeId)
            {
                return BadRequest();
            }

            _context.Entry(electronicSignaturePurpose).State = EntityState.Modified;

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

            return Updated(electronicSignaturePurpose);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ElectronicSignaturePurpose> delta)
        {
            
            var entity = await _context.Set<ElectronicSignaturePurpose>().FindAsync(key);
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
            var electronicSignaturePurpose = await _context.Set<ElectronicSignaturePurpose>().FindAsync(key);
            if (electronicSignaturePurpose == null)
            {
                return NotFound();
            }

            _context.Set<ElectronicSignaturePurpose>().Remove(electronicSignaturePurpose);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ElectronicSignaturePurpose>().Count(e => e.ElectronicSignaturePurposeId == key) > 0;
        }
    }
}