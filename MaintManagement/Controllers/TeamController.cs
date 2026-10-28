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
    public class TeamController : ODataController
    {
        private readonly CmmsContext _context;

        public TeamController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Team> Get()
        {
            return _context.Set<Team>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var team = await _context.Set<Team>().FindAsync(key);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        public async Task<IActionResult> Post([FromBody]Team team)
        {
           team.TeamId = Guid.NewGuid();
            _context.Set<Team>().Add(team);
            await _context.SaveChangesAsync();

            return Created(team);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] Team update)
        {
          
            if (key != update.TeamId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Team> patch)
        {
           
            var team = await _context.Set<Team>().FindAsync(key);
            if (team == null)
            {
                return NotFound();
            }

            patch.Patch(team);

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

            return Updated(team);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var team = await _context.Set<Team>().FindAsync(key);
            if (team == null)
            {
                return NotFound();
            }

            _context.Set<Team>().Remove(team);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Team>().Count(e => e.TeamId == key) > 0;
        }
    }
}