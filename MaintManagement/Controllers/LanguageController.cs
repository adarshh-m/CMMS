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
    public class LanguageController : ODataController
    {
        private readonly CmmsContext _context;

        public LanguageController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Language> Get()
        {
            return _context.Languages;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var language = await _context.Languages.FindAsync(key);
            if (language == null)
            {
                return NotFound();
            }
            return Ok(language);
        }

        public async Task<IActionResult> Post([FromBody] Language language)
        {
           

            _context.Languages.Add(language);
            await _context.SaveChangesAsync();

            return Created(language);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] Language language)
        {
           

            if (key != language.LanguageId)
            {
                return BadRequest();
            }

            _context.Entry(language).State = EntityState.Modified;

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

            return Updated(language);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Language> language)
        {
            

            var entity = await _context.Languages.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            language.Patch(entity);

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
            var language = await _context.Languages.FindAsync(key);
            if (language == null)
            {
                return NotFound();
            }

            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Languages.Any(e => e.LanguageId == key);
        }
    }
}