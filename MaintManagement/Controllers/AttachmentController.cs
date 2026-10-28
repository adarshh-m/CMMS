using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 

namespace YourNamespace.Controllers
{
    public class AttachmentController : ODataController
    {
        private readonly CmmsContext _context;

        public AttachmentController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Attachment> Get()
        {
            return _context.Set<Attachment>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var attachment = await _context.Set<Attachment>().FindAsync(key);
            if (attachment == null)
            {
                return NotFound();
            }
            return Ok(attachment);
        }

        public async Task<IActionResult> Post([FromBody] Attachment attachment)
        {
           
            attachment.AttachmentId = Guid.NewGuid();
            _context.Set<Attachment>().Add(attachment);
            await _context.SaveChangesAsync();

            return Created(attachment);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] Attachment attachment)
        {
           

            if (key != attachment.AttachmentId)
            {
                return BadRequest();
            }

            _context.Entry(attachment).State = EntityState.Modified;

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

            return Updated(attachment);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<Attachment> attachment)
        {
            

            var entity = await _context.Set<Attachment>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            attachment.Patch(entity);

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
            var attachment = await _context.Set<Attachment>().FindAsync(key);
            if (attachment == null)
            {
                return NotFound();
            }

            _context.Set<Attachment>().Remove(attachment);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Attachment>().Find(key) != null;
        }
    }
}