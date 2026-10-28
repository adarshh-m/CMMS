//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.OData.Routing.Controllers;
//using Microsoft.AspNetCore.OData.Query;
//using Microsoft.AspNetCore.OData.Deltas;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Results;
//using MaintManagement.Models;
//using System;


//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;



//namespace YourNamespace.Controllers
//{
//    public class UsersController : ODataController
//    {
//        private readonly CmmsContext _context;

//        public UsersController(CmmsContext context)
//        {
//            _context = context;
//        }

//        [EnableQuery]
//        public IQueryable<User> Get()
//        {
//            return _context.Set<User>();
//        }

//        [EnableQuery]
//        public async Task<IActionResult> Get([FromBody] Guid key)
//        {
//            var user = await _context.Set<User>().FindAsync(key);
//            if (user == null)
//            {
//                return NotFound();
//            }
//            return Ok(user);
//        }

//        public async Task<IActionResult> Post([FromBody] User user)
//        {
//            ModelState.Remove("Tenant");

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Set<User>().Add(user);
//            await _context.SaveChangesAsync();

//            return Created(user);
//        }

//        public async Task<IActionResult> Put( Guid key, [FromBody] User updateUser)
//        {
//            ModelState.Remove("Tenant");

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (key != updateUser.UserId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(updateUser).State = EntityState.Modified;

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

//            return Updated(updateUser);
//        }

//        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<User> patch)
//        {
//            ModelState.Remove("Tenant");

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var user = await _context.Set<User>().FindAsync(key);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            patch.Patch(user);

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

//            return Updated(user);
//        }

//        public async Task<IActionResult> Delete([FromBody] Guid key)
//        {
//            var user = await _context.Set<User>().FindAsync(key);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            _context.Set<User>().Remove(user);
//            await _context.SaveChangesAsync();

//            return StatusCode(204);
//        }

//        private bool Exists(Guid key)
//        {
//            return _context.Set<User>().Count(e => e.UserId == key) > 0;
//        }
//    }

//    public class User
//    {
//        public Guid UserId { get; set; }
//        public Guid TenantId { get; set; }
//        public string UserName { get; set; }
//        public string EmployeeNo { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string Email { get; set; }
//        public string MobileNo { get; set; }
//        public bool IsActive { get; set; }
//        public DateTime? LastLoginOn { get; set; }
//        public DateTime CreatedOn { get; set; }
//        public string PreferredLanguageCode { get; set; }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;
using MaintManagement.Models;
using Microsoft.AspNetCore.OData.Results;

namespace YourNamespace.Controllers
{
    public class UsersController : ODataController
    {
        private readonly MaintManagement.Models.CmmsContext _context;

        public UsersController(MaintManagement.Models.CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<MaintManagement.Models.User> Get()
        {
            return _context.Set<MaintManagement.Models.User>();
        }

        [EnableQuery]
        public SingleResult<MaintManagement.Models.User> Get(
            Guid key)
        {
            var result = _context.Set<MaintManagement.Models.User>()
                .Where(user => user.UserId == key);

            return SingleResult.Create(result);
        }

        public async Task<IActionResult> Post(
            [FromBody] MaintManagement.Models.User user)
        {
            
            user.UserId = Guid.NewGuid();
            _context.Set<MaintManagement.Models.User>().Add(user);

            await _context.SaveChangesAsync();

            return Created(user);
        }

        public async Task<IActionResult> Put(
            [FromRoute] Guid key,
            [FromBody] MaintManagement.Models.User user)
        {
            ModelState.Remove("Tenant");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(key))
                {
                    return NotFound();
                }

                throw;
            }

            return Updated(user);
        }

        public async Task<IActionResult> Patch(
            [FromRoute] Guid key,
            [FromBody] Delta<MaintManagement.Models.User> userDelta)
        {
            var entity = await _context.Set<MaintManagement.Models.User>()
                .FindAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            userDelta.Patch(entity);

            ModelState.Remove("Tenant");

            if (!TryValidateModel(entity))
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(key))
                {
                    return NotFound();
                }

                throw;
            }

            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromRoute] Guid key)
        {
            var user = await _context.Set<MaintManagement.Models.User>()
                .FindAsync(key);

            if (user == null)
            {
                return NotFound();
            }

            _context.Set<MaintManagement.Models.User>().Remove(user);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> UserExists(Guid key)
        {
            return await _context.Set<MaintManagement.Models.User>()
                .AnyAsync(user => user.UserId == key);
        }
    }
}
