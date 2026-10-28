using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class SessionController : ODataController
    {
        private readonly CmmsContext _context;

        public SessionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Session> Get()
        {
            return _context.Set<Session>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var session = await _context.Set<Session>().FindAsync(key);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        public async Task<IActionResult> Post([FromBody] Session session)
        {
            

            _context.Set<Session>().Add(session);
            await _context.SaveChangesAsync();

            return Created(session);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] Session session)
        {
            

            if (key != session.SessionId)
            {
                return BadRequest();
            }

            _context.Entry(session).State = EntityState.Modified;

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

            return Updated(session);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Session> session)
        {
            

            var entity = await _context.Set<Session>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            session.Patch(entity);

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
            var session = await _context.Set<Session>().FindAsync(key);
            if (session == null)
            {
                return NotFound();
            }

            _context.Set<Session>().Remove(session);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Session>().Count(e => e.SessionId == key) > 0;
        }
    }
}