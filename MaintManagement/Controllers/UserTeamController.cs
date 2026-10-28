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
    public class UserTeamController : ODataController
    {
        private readonly CmmsContext _context;

        public UserTeamController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<UserTeam> Get()
        {
            return _context.UserTeams;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            UserTeam userTeam = await _context.UserTeams.FindAsync(key);
            if (userTeam == null)
            {
                return NotFound();
            }
            return Ok(userTeam);
        }

        public async Task<IActionResult> Post([FromBody]UserTeam userTeam)
        {
            userTeam.UserTeamId = Guid.NewGuid();
            _context.UserTeams.Add(userTeam);
            await _context.SaveChangesAsync();

            return Created(userTeam);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] UserTeam userTeam)
        {
            if (key != userTeam.UserTeamId)
            {
                return BadRequest();
            }

            _context.Entry(userTeam).State = EntityState.Modified;

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

            return Updated(userTeam);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<UserTeam> patch)
        {
            UserTeam userTeam = await _context.UserTeams.FindAsync(key);
            if (userTeam == null)
            {
                return NotFound();
            }

            patch.Patch(userTeam);

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

            return Updated(userTeam);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            UserTeam userTeam = await _context.UserTeams.FindAsync(key);
            if (userTeam == null)
            {
                return NotFound();
            }

            _context.UserTeams.Remove(userTeam);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.UserTeams.Any(e => e.UserTeamId == key);
        }
    }
}