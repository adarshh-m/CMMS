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
    public class ChecklistTemplateController : ODataController
    {
        private readonly CmmsContext _context;

        public ChecklistTemplateController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ChecklistTemplate> Get()
        {
            return _context.Set<ChecklistTemplate>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<ChecklistTemplate>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistTemplate checklistTemplate)
        {
           

            _context.Set<ChecklistTemplate>().Add(checklistTemplate);
            await _context.SaveChangesAsync();

            return Created(checklistTemplate);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] ChecklistTemplate checklistTemplate)
        {
            
            if (key != checklistTemplate.ChecklistTemplateId)
            {
                return BadRequest();
            }

            _context.Entry(checklistTemplate).State = EntityState.Modified;

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

            return Updated(checklistTemplate);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistTemplate> delta)
        {
            
            var entity = await _context.Set<ChecklistTemplate>().FindAsync(key);
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

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var entity = await _context.Set<ChecklistTemplate>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<ChecklistTemplate>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ChecklistTemplate>().Any(e => e.ChecklistTemplateId == key);
        }
    }
}