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
    public class PermitAttachmentController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitAttachmentController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PermitAttachment> Get()
        {
            return _context.Set<PermitAttachment>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permitAttachment = await _context.Set<PermitAttachment>().FindAsync(key);
            if (permitAttachment == null)
            {
                return NotFound();
            }
            return Ok(permitAttachment);
        }

        public async Task<IActionResult> Post(PermitAttachment permitAttachment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Set<PermitAttachment>().Add(permitAttachment);
            await _context.SaveChangesAsync();

            return Created(permitAttachment);
        }

        public async Task<IActionResult> Put([FromBody] Guid key, PermitAttachment update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != update.PermitAttachmentId)
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

        public async Task<IActionResult> Patch([FromBody] Guid key, Delta<PermitAttachment> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permitAttachment = await _context.Set<PermitAttachment>().FindAsync(key);
            if (permitAttachment == null)
            {
                return NotFound();
            }

            delta.Patch(permitAttachment);

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

            return Updated(permitAttachment);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permitAttachment = await _context.Set<PermitAttachment>().FindAsync(key);
            if (permitAttachment == null)
            {
                return NotFound();
            }

            _context.Set<PermitAttachment>().Remove(permitAttachment);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PermitAttachment>().Any(e => e.PermitAttachmentId == key);
        }
    }
}