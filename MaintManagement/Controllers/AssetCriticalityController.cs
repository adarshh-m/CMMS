using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;using System;
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 

namespace YourNamespace.Controllers
{
    public class AssetCriticalityController : ODataController
    {
        private readonly CmmsContext _context;

        public AssetCriticalityController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<AssetCriticality> Get()
        {
            return _context.Set<AssetCriticality>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var assetCriticality = await _context.Set<AssetCriticality>().FindAsync(key);
            if (assetCriticality == null)
            {
                return NotFound();
            }
            return Ok(assetCriticality);
        }

        public async Task<IActionResult> Post([FromBody] AssetCriticality assetCriticality)
        {
            assetCriticality.AssetCriticalityId=Guid.NewGuid();
            _context.Set<AssetCriticality>().Add(assetCriticality);
            await _context.SaveChangesAsync();

            return Created(assetCriticality);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] AssetCriticality assetCriticality)
        {
            

            if (key != assetCriticality.AssetCriticalityId)
            {
                return BadRequest();
            }

            _context.Entry(assetCriticality).State = EntityState.Modified;

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

            return Updated(assetCriticality);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<AssetCriticality> patch)
        {
            

            var assetCriticality = await _context.Set<AssetCriticality>().FindAsync(key);
            if (assetCriticality == null)
            {
                return NotFound();
            }

            patch.Patch(assetCriticality);

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

            return Updated(assetCriticality);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var assetCriticality = await _context.Set<AssetCriticality>().FindAsync(key);
            if (assetCriticality == null)
            {
                return NotFound();
            }

            _context.Set<AssetCriticality>().Remove(assetCriticality);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<AssetCriticality>().Count(e => e.AssetCriticalityId == key) > 0;
        }
    }
}