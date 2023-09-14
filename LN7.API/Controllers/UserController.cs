using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using LN7.BL;
using LN7.BL.Models;

namespace LN7.API.Controllers
{

    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // GET: User/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BL.Models.User>>> Get()
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
        public async Task<ActionResult<BL.Models.User>> Get(Guid id)
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
        public async Task<ActionResult> Post([FromBody] BL.Models.User user, bool rollback)
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

        // PUT: User/guid/false
        [HttpPut("{id}/{rollback}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] BL.Models.User user, bool rollback)
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

