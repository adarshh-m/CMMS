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
    public class ChecklistResponseAttachmentController : ODataController
    {
        private readonly CmmsContext db;

        public ChecklistResponseAttachmentController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<ChecklistResponseAttachment> Get()
        {
            return db.ChecklistResponseAttachments;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            ChecklistResponseAttachment checklistResponseAttachment = await db.ChecklistResponseAttachments.FindAsync(key);
            if (checklistResponseAttachment == null)
            {
                return NotFound();
            }
            return Ok(checklistResponseAttachment);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistResponseAttachment checklistResponseAttachment)
        {
            
            db.ChecklistResponseAttachments.Add(checklistResponseAttachment);
            await db.SaveChangesAsync();

            return Created(checklistResponseAttachment);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ChecklistResponseAttachment checklistResponseAttachment)
        {
            
            if (key != checklistResponseAttachment.ChecklistResponseAttachmentId)
            {
                return BadRequest();
            }

            db.Entry(checklistResponseAttachment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(checklistResponseAttachment);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistResponseAttachment> patch)
        {
            
            ChecklistResponseAttachment checklistResponseAttachment = await db.ChecklistResponseAttachments.FindAsync(key);
            if (checklistResponseAttachment == null)
            {
                return NotFound();
            }

            patch.Patch(checklistResponseAttachment);

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(checklistResponseAttachment);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            ChecklistResponseAttachment checklistResponseAttachment = await db.ChecklistResponseAttachments.FindAsync(key);
            if (checklistResponseAttachment == null)
            {
                return NotFound();
            }

            db.ChecklistResponseAttachments.Remove(checklistResponseAttachment);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.ChecklistResponseAttachments.Count(e => e.ChecklistResponseAttachmentId == key) > 0;
        }
    }
}