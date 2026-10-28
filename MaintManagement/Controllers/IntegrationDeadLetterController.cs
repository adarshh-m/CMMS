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
    public class IntegrationDeadLetterController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationDeadLetterController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationDeadLetter> Get()
        {
            return _context.Set<IntegrationDeadLetter>();
        }

        [EnableQuery]
        public async Task<SingleResult<IntegrationDeadLetter>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<IntegrationDeadLetter>().Where(x => x.DeadLetterId == key));
        }

        public async Task<IActionResult> Post([FromBody] IntegrationDeadLetter integrationDeadLetter)
        {
            

            _context.Set<IntegrationDeadLetter>().Add(integrationDeadLetter);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(integrationDeadLetter.DeadLetterId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(integrationDeadLetter);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] IntegrationDeadLetter integrationDeadLetter)
        {
            

            if (key != integrationDeadLetter.DeadLetterId)
            {
                return BadRequest();
            }

            _context.Entry(integrationDeadLetter).State = EntityState.Modified;

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

            return Updated(integrationDeadLetter);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationDeadLetter> integrationDeadLetter)
        {
           

            var entity = await _context.Set<IntegrationDeadLetter>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            integrationDeadLetter.Patch(entity);

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
            var integrationDeadLetter = await _context.Set<IntegrationDeadLetter>().FindAsync(key);
            if (integrationDeadLetter == null)
            {
                return NotFound();
            }

            _context.Set<IntegrationDeadLetter>().Remove(integrationDeadLetter);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<IntegrationDeadLetter>().Count(e => e.DeadLetterId == key) > 0;
        }
    }
}