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
    public class AssetStatusController : ODataController
    {
        private readonly CmmsContext _context;

        public AssetStatusController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<AssetStatus> Get()
        {
            return _context.Set<AssetStatus>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var assetStatus = await _context.Set<AssetStatus>().FindAsync(key);
            if (assetStatus == null)
            {
                return NotFound();
            }
            return Ok(assetStatus);
        }

        public async Task<IActionResult> Post([FromBody] AssetStatus assetStatus)
        {
            
            assetStatus.AssetStatusId=Guid.NewGuid();
            _context.Set<AssetStatus>().Add(assetStatus);
            await _context.SaveChangesAsync();

            return Created(assetStatus);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] AssetStatus assetStatus)
        {
           
            if (key != assetStatus.AssetStatusId)
            {
                return BadRequest();
            }

            _context.Entry(assetStatus).State = EntityState.Modified;

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

            return Updated(assetStatus);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<AssetStatus> assetStatus)
        {
           
            var entity = await _context.Set<AssetStatus>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            assetStatus.Patch(entity);

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
            var assetStatus = await _context.Set<AssetStatus>().FindAsync(key);
            if (assetStatus == null)
            {
                return NotFound();
            }

            _context.Set<AssetStatus>().Remove(assetStatus);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<AssetStatus>().Count(e => e.AssetStatusId == key) > 0;
        }
    }
}