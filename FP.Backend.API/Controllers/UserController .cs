using FP.Backend.Domain.Entities;
using FP.Domain.DTOs;
using FP.Services.Interfaces;

namespace FP.Backend.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : MongoBaseController<User, User>
    {
        private readonly IUserService _service;

        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDTO request)
        {
            var response = await CreateAsync(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UpdateUserDTO request)
        {
            var response = await UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveUser(Guid id)
        {
            var response = await RemoveAsync(id);

            return Ok(response);
        }

        [HttpPost("import")]
        public async Task<ActionResult> Import([FromBody] CreateUserDTO[] requests)
        {
            var response = await ImportAsync(requests);

            return Ok(response);
        }

        [HttpGet("super-admins")]
        public async Task<ActionResult> GetSuperAdmins()
        {
            var response = await _service.GetUserByRoleAsync("super-admin");

            return Ok(response);
        }

        [HttpGet("admins")]
        public async Task<ActionResult> GetAdmins()
        {
            var response = await _service.GetUserByRoleAsync("admin");

            return Ok(response);
        }

        [HttpGet("board-members")]
        public async Task<ActionResult> GetBoardMembers()
        {
            var response = await _service.GetUserByRoleAsync("board-members");

            return Ok(response);
        }

        [HttpGet("reviewers")]
        public async Task<ActionResult> GetReviewers()
        {
            var response = await _service.GetUserByRoleAsync("reviewer");

            return Ok(response);
        }

        [HttpGet("students")]
        public async Task<ActionResult> Getstudents()
        {
            var response = await _service.GetUserByRoleAsync("student");

            return Ok(response);
        }
    }
}
