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
    public class UserClaimController : ODataController
    {
        private readonly CmmsContext _context;

        public UserClaimController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<UserClaim> Get()
        {
            return _context.Set<UserClaim>();
        }

        [EnableQuery]
        public async Task<SingleResult<UserClaim>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<UserClaim>().Where(userClaim => userClaim.UserClaimId == key));
        }

        public async Task<IActionResult> Post([FromBody]UserClaim userClaim)
        {
            userClaim.UserClaimId = Guid.NewGuid();
            _context.Set<UserClaim>().Add(userClaim);
            await _context.SaveChangesAsync();

            return Created(userClaim);
        }

        public async Task<IActionResult> Put(Guid key,[FromBody] UserClaim userClaim)
        {
            if (key != userClaim.UserClaimId)
            {
                return BadRequest();
            }

            _context.Entry(userClaim).State = EntityState.Modified;

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

            return Updated(userClaim);
        }

        public async Task<IActionResult> Patch(Guid key,[FromBody] Delta<UserClaim> userClaim)
        {
            var entity = await _context.Set<UserClaim>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            userClaim.Patch(entity);

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
            var userClaim = await _context.Set<UserClaim>().FindAsync(key);
            if (userClaim == null)
            {
                return NotFound();
            }

            _context.Set<UserClaim>().Remove(userClaim);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<UserClaim>().Count(e => e.UserClaimId == key) > 0;
        }
    }
}