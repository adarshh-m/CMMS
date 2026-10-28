using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 

namespace YourNamespace.Controllers
{
    public class ApiClientController : ODataController
    {
        private readonly CmmsContext _context;

        public ApiClientController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ApiClient> Get()
        {
            return _context.Set<ApiClient>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var apiClient = await _context.Set<ApiClient>().FindAsync(key);
            if (apiClient == null)
            {
                return NotFound();
            }
            return Ok(apiClient);
        }

        public async Task<IActionResult> Post([FromBody] ApiClient apiClient)
        {
            
            apiClient.ApiClientId=Guid.NewGuid();
            _context.Set<ApiClient>().Add(apiClient);
            await _context.SaveChangesAsync();

            return Created(apiClient);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] ApiClient update)
        {
            

            if (key != update.ApiClientId)
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

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<ApiClient> patch)
        {
            

            var apiClient = await _context.Set<ApiClient>().FindAsync(key);
            if (apiClient == null)
            {
                return NotFound();
            }

            patch.Patch(apiClient);

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

            return Updated(apiClient);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var apiClient = await _context.Set<ApiClient>().FindAsync(key);
            if (apiClient == null)
            {
                return NotFound();
            }

            _context.Set<ApiClient>().Remove(apiClient);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ApiClient>().Count(e => e.ApiClientId == key) > 0;
        }
    }
}