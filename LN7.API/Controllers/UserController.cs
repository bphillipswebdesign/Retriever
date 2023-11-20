using LN7.BL;
using LN7.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace LN7.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // GET: User/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                return Ok(await UserManager.Load());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: User/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            try
            {
                return Ok(await UserManager.LoadById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: User/false
        [HttpPost("{rollback}")]
        public async Task<ActionResult> Post([FromBody] User user, bool rollback)
        {
            try
            {
                await UserManager.Insert(user, rollback);
                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: User/
        [HttpPost("")]
        public async Task<ActionResult<User>> Login([FromBody] User user)
        {
            try
            {
                if (UserManager.Login(user))
                {
                    User player = await UserManager.LoadById(user.Id);
                    return Ok(player);
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: User/guid/false
        [HttpPut("{id}/{rollback}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] User user, bool rollback)
        {
            try
            {
                return Ok(await UserManager.Update(user, rollback));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: User/Guid
        [HttpDelete("{id}/{rollback}")]
        public async Task<IActionResult> Delete(Guid id, bool rollback)
        {
            try
            {
                return Ok(await UserManager.Delete(id, rollback));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}