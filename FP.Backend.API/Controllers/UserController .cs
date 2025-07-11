using FP.Backend.Domain.Entities;
using FP.Domain.DTOs;

namespace FP.Backend.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : MongoBaseController<User, User>
    {
        public UserController(IMongoBaseService<User> service) : base(service)
        {

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
    }
}
