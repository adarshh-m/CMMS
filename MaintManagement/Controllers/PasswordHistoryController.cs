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
    public class PasswordHistoryController : ODataController
    {
        private readonly CmmsContext _context;

        public PasswordHistoryController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PasswordHistory> Get()
        {
            return _context.Set<PasswordHistory>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var passwordHistory = await _context.Set<PasswordHistory>().FindAsync(key);
            if (passwordHistory == null)
            {
                return NotFound();
            }
            return Ok(passwordHistory);
        }

        public async Task<IActionResult> Post([FromBody] PasswordHistory passwordHistory)
        {
           
            _context.Set<PasswordHistory>().Add(passwordHistory);
            await _context.SaveChangesAsync();

            return Created(passwordHistory);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PasswordHistory passwordHistory)
        {
            

            if (key != passwordHistory.PasswordHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(passwordHistory).State = EntityState.Modified;

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

            return Updated(passwordHistory);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PasswordHistory> passwordHistory)
        {
            

            var entity = await _context.Set<PasswordHistory>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            passwordHistory.Patch(entity);

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
            var passwordHistory = await _context.Set<PasswordHistory>().FindAsync(key);
            if (passwordHistory == null)
            {
                return NotFound();
            }

            _context.Set<PasswordHistory>().Remove(passwordHistory);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PasswordHistory>().Any(e => e.PasswordHistoryId == key);
        }
    }
}