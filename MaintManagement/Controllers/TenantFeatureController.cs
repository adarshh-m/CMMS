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
    public class TenantFeatureController : ODataController
    {
        private readonly CmmsContext _context;

        public TenantFeatureController(CmmsContext context)
        {
            _context = context;
        }
       

        [EnableQuery]
        public IQueryable<TenantFeature> Get()
        {
            return _context.TenantFeatures;
        }

        [EnableQuery]
        public async Task<SingleResult<TenantFeature>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.TenantFeatures.Where(tenantFeature => tenantFeature.TenantFeatureId == key));
        }

        public async Task<IActionResult> Post([FromBody]TenantFeature tenantFeature)
        {
            tenantFeature.TenantFeatureId = Guid.NewGuid();
            _context.TenantFeatures.Add(tenantFeature);
            await _context.SaveChangesAsync();

            return Created(tenantFeature);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] TenantFeature tenantFeature)
        {
           
            if (key != tenantFeature.TenantFeatureId)
            {
                return BadRequest();
            }

            _context.Entry(tenantFeature).State = EntityState.Modified;

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

            return Updated(tenantFeature);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<TenantFeature> patch)
        {

            TenantFeature tenantFeature = await _context.TenantFeatures.FindAsync(key);
            if (tenantFeature == null)
            {
                return NotFound();
            }

            patch.Patch(tenantFeature);

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

            return Updated(tenantFeature);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            TenantFeature tenantFeature = await _context.TenantFeatures.FindAsync(key);
            if (tenantFeature == null)
            {
                return NotFound();
            }

            _context.TenantFeatures.Remove(tenantFeature);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.TenantFeatures.Count(e => e.TenantFeatureId == key) > 0;
        }
    }
}