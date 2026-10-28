using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class SystemMessageTranslationController : ODataController
    {
        private readonly CmmsContext _context;

        public SystemMessageTranslationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<SystemMessageTranslation> Get()
        {
            return _context.Set<SystemMessageTranslation>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var entity = await _context.Set<SystemMessageTranslation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] SystemMessageTranslation systemMessageTranslation)
        {
            systemMessageTranslation.MessageTranslationId = Guid.NewGuid();
            _context.Set<SystemMessageTranslation>().Add(systemMessageTranslation);
            await _context.SaveChangesAsync();

            return Created(systemMessageTranslation);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] SystemMessageTranslation systemMessageTranslation)
        {
            
            if (key != systemMessageTranslation.MessageTranslationId)
            {
                return BadRequest();
            }

            _context.Entry(systemMessageTranslation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(systemMessageTranslation);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<SystemMessageTranslation> delta)
        {
            
            var entity = await _context.Set<SystemMessageTranslation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            delta.Patch(entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var entity = await _context.Set<SystemMessageTranslation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<SystemMessageTranslation>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<SystemMessageTranslation>().Find(key) != null;
        }
    }
}