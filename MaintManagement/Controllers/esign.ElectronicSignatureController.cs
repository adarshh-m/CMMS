//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.OData.Routing.Controllers;
//using Microsoft.AspNetCore.OData.Query;
//using Microsoft.AspNetCore.OData.Deltas;
//using Microsoft.AspNetCore.Mvc;
//using MaintManagement.Models;

//namespace YourNamespace.Controllers
//{
//    public class ElectronicSignatureController : ODataController
//    {
//        private readonly CmmsContext _context;

//        public ElectronicSignatureController(CmmsContext context)
//        {
//            _context = context;
//        }

//        [EnableQuery]
//        public IQueryable<ElectronicSignature> Get()
//        {
//            return _context.Set<ElectronicSignature>();
//        }

//        [EnableQuery]
//        public async Task<IActionResult> Get([FromBody] Guid key)
//        {
//            var entity = await _context.Set<ElectronicSignature>().FindAsync(key);
//            if (entity == null)
//            {
//                return NotFound();
//            }
//            return Ok(entity);
//        }

//        public async Task<IActionResult> Post(ElectronicSignature electronicSignature)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Set<ElectronicSignature>().Add(electronicSignature);
//            await _context.SaveChangesAsync();

//            return Created(electronicSignature);
//        }

//        public async Task<IActionResult> Put([FromBody] Guid key, ElectronicSignature electronicSignature)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (key != electronicSignature.ElectronicSignatureId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(electronicSignature).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!Exists(key))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return Updated(electronicSignature);
//        }

//        public async Task<IActionResult> Patch([FromBody] Guid key, Delta<ElectronicSignature> patch)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var entity = await _context.Set<ElectronicSignature>().FindAsync(key);
//            if (entity == null)
//            {
//                return NotFound();
//            }

//            patch.Patch(entity);

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!Exists(key))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return Updated(entity);
//        }

//        public async Task<IActionResult> Delete([FromBody] Guid key)
//        {
//            var electronicSignature = await _context.Set<ElectronicSignature>().FindAsync(key);
//            if (electronicSignature == null)
//            {
//                return NotFound();
//            }

//            _context.Set<ElectronicSignature>().Remove(electronicSignature);
//            await _context.SaveChangesAsync();

//            return StatusCode(204);
//        }

//        private bool Exists(Guid key)
//        {
//            return _context.Set<ElectronicSignature>().Any(e => e.ElectronicSignatureId == key);
//        }
//    }


//}