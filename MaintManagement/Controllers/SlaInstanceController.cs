using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class SlaInstanceController : ODataController
    {
        private readonly CmmsContext _context;

        public SlaInstanceController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<SlaInstance> Get()
        {
            return _context.Set<SlaInstance>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<SlaInstance>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] SlaInstance slaInstance)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Set<SlaInstance>().Add(slaInstance);
            await _context.SaveChangesAsync();

            return Created(slaInstance);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] SlaInstance slaInstance)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != slaInstance.SlaInstanceId)
            {
                return BadRequest();
            }

            _context.Entry(slaInstance).State = EntityState.Modified;

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

            return Updated(slaInstance);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<SlaInstance> delta)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var entity = await _context.Set<SlaInstance>().FindAsync(key);
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
            var entity = await _context.Set<SlaInstance>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<SlaInstance>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<SlaInstance>().Find(key) != null;
        }
    }
}