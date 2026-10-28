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
    public class WorkflowVariableController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowVariableController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowVariable> Get()
        {
            return _context.Set<WorkflowVariable>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var entity = await _context.Set<WorkflowVariable>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowVariable workflowVariable)
        {
           workflowVariable.WorkflowVariableId= Guid.NewGuid();
            _context.Set<WorkflowVariable>().Add(workflowVariable);
            await _context.SaveChangesAsync();

            return Created(workflowVariable);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkflowVariable workflowVariable)
        {

            if (key != workflowVariable.WorkflowVariableId)
            {
                return BadRequest();
            }

            _context.Entry(workflowVariable).State = EntityState.Modified;

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

            return Updated(workflowVariable);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<WorkflowVariable> delta)
        {
           
            var entity = await _context.Set<WorkflowVariable>().FindAsync(key);
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

        public async Task<IActionResult> Delete(Guid key)
        {
            var entity = await _context.Set<WorkflowVariable>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowVariable>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowVariable>().Count(e => e.WorkflowVariableId == key) > 0;
        }
    }
}