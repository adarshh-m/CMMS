using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class SystemMessageController : ODataController
    {
        private readonly CmmsContext _context;

        public SystemMessageController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<SystemMessage> Get()
        {
            return _context.Set<SystemMessage>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(string key)
        {
            var entity = await _context.Set<SystemMessage>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] SystemMessage systemMessage)
        {
            //systemMessage.id
            _context.Set<SystemMessage>().Add(systemMessage);
            await _context.SaveChangesAsync();

            return Created(systemMessage);
        }

        public async Task<IActionResult> Put( string key, [FromBody] SystemMessage systemMessage)
        {
           
            if (key != systemMessage.MessageCode)
            {
                return BadRequest();
            }

            _context.Entry(systemMessage).State = EntityState.Modified;

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

            return Updated(systemMessage);
        }

        public async Task<IActionResult> Patch( string key, [FromBody] Delta<SystemMessage> delta)
        {
            var entity = await _context.Set<SystemMessage>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            delta.Patch(entity);

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

        public async Task<IActionResult> Delete( string key)
        {
            var systemMessage = await _context.Set<SystemMessage>().FindAsync(key);
            if (systemMessage == null)
            {
                return NotFound();
            }

            _context.Set<SystemMessage>().Remove(systemMessage);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(string key)
        {
            return _context.Set<SystemMessage>().Find(key) != null;
        }
    }

}