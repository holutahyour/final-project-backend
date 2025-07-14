using FP.Backend.Domain.Entities;
using FP.Domain.DTOs;

namespace FP.Backend.API.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : MongoBaseController<Department, DepartmentDTO>
    {
        public DepartmentController(IMongoBaseService<Department> service) : base(service)
        {
        }

        [HttpPost]
        public async Task<ActionResult> CreateDepartment([FromBody] CreateDepartmentDTO request)
        {
            var response = await CreateAsync(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDepartment(Guid id, [FromBody] UpdateDepartmentDTO request)
        {
            var response = await UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveDepartment(Guid id)
        {
            var response = await RemoveAsync(id);

            return Ok(response);
        }

        [HttpPost("import")]
        public async Task<ActionResult> Import([FromBody] CreateDepartmentDTO[] requests)
        {
            var response = await ImportAsync(requests);

            return Ok(response);
        }
    }
}
