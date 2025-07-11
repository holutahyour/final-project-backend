using FP.Backend.Domain.Entities;
using FP.Domain.DTOs;

namespace FP.Backend.API.Controllers
{
    [Route("api/faculties")]
    [ApiController]
    public class FacultyController : MongoBaseController<Faculty, Faculty>
    {
        public FacultyController(IMongoBaseService<Faculty> service) : base(service)
        {
        }

        [HttpPost]
        public async Task<ActionResult> CreateFaculty([FromBody] CreateFacultyDTO request)
        {
            var response = await CreateAsync(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateFaculty(Guid id, [FromBody] UpdateFacultyDTO request)
        {
            var response = await UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveFaculty(Guid id)
        {
            var response = await RemoveAsync(id);

            return Ok(response);
        }

        [HttpPost("import")]
        public async Task<ActionResult> Import([FromBody] CreateFacultyDTO[] requests)
        {
            var response = await ImportAsync(requests);

            return Ok(response);
        }
    }
}
