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
    public class PermitAssetController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitAssetController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PermitAsset> Get()
        {
            return _context.Set<PermitAsset>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permitAsset = await _context.Set<PermitAsset>().FindAsync(key);
            if (permitAsset == null)
            {
                return NotFound();
            }
            return Ok(permitAsset);
        }

        public async Task<IActionResult> Post([FromBody] PermitAsset permitAsset)
        {
            

            _context.Set<PermitAsset>().Add(permitAsset);
            await _context.SaveChangesAsync();

            return Created(permitAsset);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitAsset update)
        {
            

            if (key != update.PermitAssetId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitAsset> patch)
        {
           

            var permitAsset = await _context.Set<PermitAsset>().FindAsync(key);
            if (permitAsset == null)
            {
                return NotFound();
            }

            patch.Patch(permitAsset);

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

            return Updated(permitAsset);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permitAsset = await _context.Set<PermitAsset>().FindAsync(key);
            if (permitAsset == null)
            {
                return NotFound();
            }

            _context.Set<PermitAsset>().Remove(permitAsset);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PermitAsset>().Any(e => e.PermitAssetId == key);
        }
    }
}