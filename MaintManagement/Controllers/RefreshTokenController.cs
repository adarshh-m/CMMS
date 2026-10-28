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
    public class RefreshTokenController : ODataController
    {
        private readonly CmmsContext _context;

        public RefreshTokenController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<RefreshToken> Get()
        {
            return _context.Set<RefreshToken>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var refreshToken = await _context.Set<RefreshToken>().FindAsync(key);
            if (refreshToken == null)
            {
                return NotFound();
            }
            return Ok(refreshToken);
        }

        public async Task<IActionResult> Post([FromBody] RefreshToken refreshToken)
        {
            
            refreshToken.RefreshTokenId = Guid.NewGuid();
            _context.Set<RefreshToken>().Add(refreshToken);
            await _context.SaveChangesAsync();

            return Created(refreshToken);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] RefreshToken refreshToken)
        {
            

            if (key != refreshToken.RefreshTokenId)
            {
                return BadRequest();
            }

            _context.Entry(refreshToken).State = EntityState.Modified;

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

            return Updated(refreshToken);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<RefreshToken> refreshToken)
        {
           

            var entity = await _context.Set<RefreshToken>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            refreshToken.Patch(entity);

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
            var refreshToken = await _context.Set<RefreshToken>().FindAsync(key);
            if (refreshToken == null)
            {
                return NotFound();
            }

            _context.Set<RefreshToken>().Remove(refreshToken);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<RefreshToken>().Count(e => e.RefreshTokenId == key) > 0;
        }
    }
}