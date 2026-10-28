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
    public class TenantController : ODataController
    {
        private readonly CmmsContext _context;

        public TenantController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Tenant> Get()
        {
            return _context.Set<Tenant>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var tenant = await _context.Set<Tenant>().FindAsync(key);
            if (tenant == null)
            {
                return NotFound();
            }
            return Ok(tenant);
        }

        public async Task<IActionResult> Post(Tenant tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Set<Tenant>().Add(tenant);
            await _context.SaveChangesAsync();

            return Created(tenant);
        }

        public async Task<IActionResult> Put([FromBody] Guid key, Tenant update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != update.TenantId)
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

        public async Task<IActionResult> Patch([FromBody] Guid key, Delta<Tenant> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tenant = await _context.Set<Tenant>().FindAsync(key);
            if (tenant == null)
            {
                return NotFound();
            }

            patch.Patch(tenant);

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

            return Updated(tenant);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var tenant = await _context.Set<Tenant>().FindAsync(key);
            if (tenant == null)
            {
                return NotFound();
            }

            _context.Set<Tenant>().Remove(tenant);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Tenant>().Any(e => e.TenantId == key);
        }
    }

}