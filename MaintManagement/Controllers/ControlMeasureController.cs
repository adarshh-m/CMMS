using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
namespace YourNamespace.Controllers
{
    public class ControlMeasureController : ODataController
    {
        private readonly CmmsContext _context;

        public ControlMeasureController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ControlMeasure> Get()
        {
            return _context.Set<ControlMeasure>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] string key)
        {
            var controlMeasure = await _context.Set<ControlMeasure>().FindAsync(key);
            if (controlMeasure == null)
            {
                return NotFound();
            }
            return Ok(controlMeasure);
        }

        public async Task<IActionResult> Post([FromBody] ControlMeasure controlMeasure)
        {
           
            _context.Set<ControlMeasure>().Add(controlMeasure);
            await _context.SaveChangesAsync();

            return Created(controlMeasure);
        }

        public async Task<IActionResult> Put( string key, [FromBody] ControlMeasure controlMeasure)
        {

            if (key != controlMeasure.ControlCode)
            {
                return BadRequest();
            }

            _context.Entry(controlMeasure).State = EntityState.Modified;

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

            return Updated(controlMeasure);
        }

        public async Task<IActionResult> Patch(string key, [FromBody] Delta<ControlMeasure> controlMeasure)
        {
           
            var entity = await _context.Set<ControlMeasure>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            controlMeasure.Patch(entity);

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

        public async Task<IActionResult> Delete([FromBody] string key)
        {
            var controlMeasure = await _context.Set<ControlMeasure>().FindAsync(key);
            if (controlMeasure == null)
            {
                return NotFound();
            }

            _context.Set<ControlMeasure>().Remove(controlMeasure);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(string key)
        {
            return _context.Set<ControlMeasure>().Count(e => e.ControlCode == key) > 0;
        }
    }

}