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
    public class ChecklistSectionController : ODataController
    {
        private readonly CmmsContext _context;

        //public ChecklistSectionController()
        //{
        //    _context = new CmmsContext();
        //}

        public ChecklistSectionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ChecklistSection> Get()
        {
            return _context.ChecklistSections;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var checklistSection = await _context.ChecklistSections.FindAsync(key);
            if (checklistSection == null)
            {
                return NotFound();
            }
            return Ok(checklistSection);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistSection checklistSection)
        {
            

            _context.ChecklistSections.Add(checklistSection);
            await _context.SaveChangesAsync();

            return Created(checklistSection);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ChecklistSection checklistSection)
        {
            
            if (key != checklistSection.ChecklistSectionId)
            {
                return BadRequest();
            }

            _context.Entry(checklistSection).State = EntityState.Modified;

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

            return Updated(checklistSection);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistSection> checklistSection)
        {
            
            var entity = await _context.ChecklistSections.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            checklistSection.Patch(entity);

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
            var checklistSection = await _context.ChecklistSections.FindAsync(key);
            if (checklistSection == null)
            {
                return NotFound();
            }

            _context.ChecklistSections.Remove(checklistSection);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.ChecklistSections.Any(e => e.ChecklistSectionId == key);
        }
    }
}