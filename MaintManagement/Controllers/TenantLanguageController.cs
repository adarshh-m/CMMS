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
    public class TenantLanguageController : ODataController
    {
        private readonly CmmsContext _context;

        public TenantLanguageController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<TenantLanguage> Get()
        {
            return _context.Set<TenantLanguage>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var tenantLanguage = await _context.Set<TenantLanguage>().FindAsync(key);
            if (tenantLanguage == null)
            {
                return NotFound();
            }
            return Ok(tenantLanguage);
        }

        public async Task<IActionResult> Post([FromBody] TenantLanguage tenantLanguage)
        {
            //ModelState.Remove("Tenant");
            //ModelState.Remove("Language");
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Set<TenantLanguage>().Add(tenantLanguage);
            await _context.SaveChangesAsync();

            return Created(tenantLanguage);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] TenantLanguage tenantLanguage)
        {
            //ModelState.Remove("Tenant");
            //ModelState.Remove("Language");
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != tenantLanguage.TenantLanguageId)
            {
                return BadRequest();
            }

            _context.Entry(tenantLanguage).State = EntityState.Modified;

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

            return Updated(tenantLanguage);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<TenantLanguage> delta)
        {
            //ModelState.Remove("Tenant");
            //ModelState.Remove("Language");

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var tenantLanguage = await _context.Set<TenantLanguage>().FindAsync(key);
            if (tenantLanguage == null)
            {
                return NotFound();
            }

            delta.Patch(tenantLanguage);

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

            return Updated(tenantLanguage);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var tenantLanguage = await _context.Set<TenantLanguage>().FindAsync(key);
            if (tenantLanguage == null)
            {
                return NotFound();
            }

            _context.Set<TenantLanguage>().Remove(tenantLanguage);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<TenantLanguage>().Count(e => e.TenantLanguageId == key) > 0;
        }
    }
}