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
    public class MaintenanceRequestController : ODataController
    {
        private readonly CmmsContext _context;

        public MaintenanceRequestController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<MaintenanceRequest> Get()
        {
            return _context.Set<MaintenanceRequest>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<MaintenanceRequest>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] MaintenanceRequest maintenanceRequest)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Set<MaintenanceRequest>().Add(maintenanceRequest);
            await _context.SaveChangesAsync();

            return Created(maintenanceRequest);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] MaintenanceRequest maintenanceRequest)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != maintenanceRequest.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(maintenanceRequest).State = EntityState.Modified;

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

            return Updated(maintenanceRequest);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<MaintenanceRequest> delta)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var entity = await _context.Set<MaintenanceRequest>().FindAsync(key);
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
            var entity = await _context.Set<MaintenanceRequest>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<MaintenanceRequest>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<MaintenanceRequest>().Count(e => e.RequestId == key) > 0;
        }
    }
}