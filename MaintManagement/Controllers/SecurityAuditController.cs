//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.OData.Routing.Controllers;
//using Microsoft.AspNetCore.OData.Query;
//using Microsoft.AspNetCore.OData.Deltas;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Results;
//using MaintManagement.Models;

//namespace YourNamespace.Controllers
//{
//    public class SecurityAuditController : ODataController
//    {
//        private readonly CmmsContext _context;

//        public SecurityAuditController(CmmsContext context)
//        {
//            _context = context;
//        }

//        [EnableQuery]
//        public IQueryable<SecurityAudit> Get()
//        {
//            return _context.Set<SecurityAudit>();
//        }

//        [EnableQuery]
//        public async Task<SingleResult<SecurityAudit>> Get([FromBody] long securityAuditId, [FromBody] Guid tenantId, [FromBody] DateTime eventTime)
//        {
//            var securityAudit = _context.Set<SecurityAudit>().Where(e => e.SecurityAuditId == securityAuditId && e.TenantId == tenantId && e.EventTime == eventTime);
//            return SingleResult.Create(securityAudit);
//        }

//        public async Task<IActionResult> Post([FromBody] SecurityAudit securityAudit)
//        {


//            _context.Set<SecurityAudit>().Add(securityAudit);
//            await _context.SaveChangesAsync();

//            return Created(securityAudit);
//        }

//        public async Task<IActionResult> Put( long securityAuditId,  Guid tenantId,DateTime eventTime, [FromBody] SecurityAudit updatedSecurityAudit)
//        {


//            if (securityAuditId != updatedSecurityAudit.SecurityAuditId || tenantId != updatedSecurityAudit.TenantId || eventTime != updatedSecurityAudit.EventTime)
//            {
//                return BadRequest();
//            }

//            _context.Entry(updatedSecurityAudit).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!Exists(securityAuditId, tenantId, eventTime))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return Updated(updatedSecurityAudit);
//        }

//        public async Task<IActionResult> Patch([FromBody] long securityAuditId, [FromBody] Guid tenantId, [FromBody] DateTime eventTime, [FromBody] Delta<SecurityAudit> patch)
//        {


//            var securityAudit = await _context.Set<SecurityAudit>().FindAsync(securityAuditId, tenantId, eventTime);
//            if (securityAudit == null)
//            {
//                return NotFound();
//            }

//            patch.Patch(securityAudit);

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!Exists(securityAuditId, tenantId, eventTime))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return Updated(securityAudit);
//        }

//        public async Task<IActionResult> Delete([FromBody] long securityAuditId, [FromBody] Guid tenantId, [FromBody] DateTime eventTime)
//        {
//            var securityAudit = await _context.Set<SecurityAudit>().FindAsync(securityAuditId, tenantId, eventTime);
//            if (securityAudit == null)
//            {
//                return NotFound();
//            }

//            _context.Set<SecurityAudit>().Remove(securityAudit);
//            await _context.SaveChangesAsync();

//            return StatusCode(204);
//        }

//        private bool Exists(long securityAuditId, Guid tenantId, DateTime eventTime)
//        {
//            return _context.Set<SecurityAudit>().Any(e => e.SecurityAuditId == securityAuditId && e.TenantId == tenantId && e.EventTime == eventTime);
//        }
//    }
//}

using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Controllers
{
    public class SecurityAuditController : ODataController
    {
        private readonly CmmsContext _context;

        public SecurityAuditController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<SecurityAudit> Get()
        {
            return _context.Set<SecurityAudit>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(long key)
        {
            var securityAudit = await _context.Set<SecurityAudit>().FindAsync(key);

            if (securityAudit == null)
            {
                return NotFound();
            }

            return Ok(securityAudit);
        }

        public async Task<IActionResult> Post([FromBody] SecurityAudit securityAudit)
        {
            //securityAudit.SecurityAuditId = Guid.NewGuid();
            _context.Set<SecurityAudit>().Add(securityAudit);
            await _context.SaveChangesAsync();

            return Created(securityAudit);
        }

        public async Task<IActionResult> Put(int key, [FromBody] SecurityAudit securityAudit)
        {
            if (key != securityAudit.SecurityAuditId)
            {
                return BadRequest();
            }

            _context.Entry(securityAudit).State = EntityState.Modified;

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

                throw;
            }

            return Updated(securityAudit);
        }

        public async Task<IActionResult> Patch(long key, [FromBody] Delta<SecurityAudit> securityAudit)
        {
            var entity = await _context.Set<SecurityAudit>().FindAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            securityAudit.Patch(entity);
            await _context.SaveChangesAsync();

            return Updated(entity);
        }

        public async Task<IActionResult> Delete(long key)
        {
            var securityAudit = await _context.Set<SecurityAudit>().FindAsync(key);

            if (securityAudit == null)
            {
                return NotFound();
            }

            _context.Set<SecurityAudit>().Remove(securityAudit);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(int key)
        {
            return _context.Set<SecurityAudit>()
                .Any(e => e.SecurityAuditId == key);
        }
    }
}