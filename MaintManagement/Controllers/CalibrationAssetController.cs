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
    public class CalibrationAssetController : ODataController
    {
        private readonly CmmsContext _context;

        public CalibrationAssetController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<CalibrationAsset> Get()
        {
            return _context.Set<CalibrationAsset>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var calibrationAsset = await _context.Set<CalibrationAsset>().FindAsync(key);
            if (calibrationAsset == null)
            {
                return NotFound();
            }
            return Ok(calibrationAsset);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationAsset calibrationAsset)
        {
           

            _context.Set<CalibrationAsset>().Add(calibrationAsset);
            await _context.SaveChangesAsync();

            return Created(calibrationAsset);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] CalibrationAsset calibrationAsset)
        {
            

            if (key != calibrationAsset.CalibrationAssetId)
            {
                return BadRequest();
            }

            _context.Entry(calibrationAsset).State = EntityState.Modified;

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

            return Updated(calibrationAsset);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<CalibrationAsset> calibrationAsset)
        {
            

            var entity = await _context.Set<CalibrationAsset>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            calibrationAsset.Patch(entity);

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
            var calibrationAsset = await _context.Set<CalibrationAsset>().FindAsync(key);
            if (calibrationAsset == null)
            {
                return NotFound();
            }

            _context.Set<CalibrationAsset>().Remove(calibrationAsset);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CalibrationAsset>().Count(e => e.CalibrationAssetId == key) > 0;
        }
    }
}