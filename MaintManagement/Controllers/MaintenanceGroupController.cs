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
    public class MaintenanceGroupController : ODataController
    {
        private readonly CmmsContext _context;

        public MaintenanceGroupController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<MaintenanceGroup> Get()
        {
            return _context.Set<MaintenanceGroup>();
        }

        [EnableQuery]
        public async Task<SingleResult<MaintenanceGroup>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<MaintenanceGroup>().Where(mg => mg.MaintenanceGroupId == key));
        }

        public async Task<IActionResult> Post([FromBody] MaintenanceGroup maintenanceGroup)
        {
            ModelState.Remove("Tenant");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Set<MaintenanceGroup>().Add(maintenanceGroup);
            await _context.SaveChangesAsync();

            return Created(maintenanceGroup);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] MaintenanceGroup maintenanceGroup)
        {
            ModelState.Remove("Tenant");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != maintenanceGroup.MaintenanceGroupId)
            {
                return BadRequest();
            }

            _context.Entry(maintenanceGroup).State = EntityState.Modified;

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

            return Updated(maintenanceGroup);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<MaintenanceGroup> maintenanceGroup)
        {
            ModelState.Remove("Tenant");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await _context.Set<MaintenanceGroup>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            maintenanceGroup.Patch(entity);

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
            var maintenanceGroup = await _context.Set<MaintenanceGroup>().FindAsync(key);
            if (maintenanceGroup == null)
            {
                return NotFound();
            }

            _context.Set<MaintenanceGroup>().Remove(maintenanceGroup);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<MaintenanceGroup>().Any(e => e.MaintenanceGroupId == key);
        }
    }

   
}