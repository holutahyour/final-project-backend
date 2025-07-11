using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Prepdom.Backend.API.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController : MongoBaseController<User, UserDTO>
    {
        private readonly IUserService _service;

        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{uid}")]
        public override async Task<ActionResult> GetByIdAsync(string uid)
        {
            var requestTime = DateTime.UtcNow;
            var response = await _service.GetByIdAsync(uid);
            var responseTime = DateTime.UtcNow;

            response.RequestTime = requestTime;
            response.ResponseTime = responseTime;

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("me")]
        public async Task<ActionResult> GetMeAsync()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(user))
                return BadRequest("User not found");

            var requestTime = DateTime.UtcNow;
            var response = await _service.GetByIdAsync(user);
            var responseTime = DateTime.UtcNow;

            response.RequestTime = requestTime;
            response.ResponseTime = responseTime;

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDTO user, string password)
        {
            var requestTime = DateTime.UtcNow;
            var response = await _service.CreateUser(user, user.Email, password);
            var responseTime = DateTime.UtcNow;
            response.RequestTime = requestTime;
            response.ResponseTime = responseTime;
            if (response != null)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveUser(Guid id)
        {
            return await RemoveAsync(id);
        }
    }
}
