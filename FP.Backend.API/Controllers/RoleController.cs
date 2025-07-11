using FP.Backend.Domain.Entities;
using FP.Domain.DTOs;

namespace FP.Backend.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : MongoBaseController<Role, Role>
    {
        public RoleController(IMongoBaseService<Role> service) : base(service)
        {
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole([FromBody] CreateRoleDTO request)
        {
            var response = await CreateAsync(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRole(Guid id, [FromBody] UpdateRoleDTO request)
        {
            var response = await UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveRole(Guid id)
        {
            var response = await RemoveAsync(id);

            return Ok(response);
        }

        [HttpPost("import")]
        public async Task<ActionResult> Import([FromBody] CreateRoleDTO[] requests)
        {
            var response = await ImportAsync(requests);

            return Ok(response);
        }
    }
}
