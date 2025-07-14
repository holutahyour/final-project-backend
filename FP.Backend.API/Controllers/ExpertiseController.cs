using FP.Backend.Domain.Entities;
using FP.Domain.DTOs;

namespace FP.Backend.API.Controllers
{
    [Route("api/expertises")]
    [ApiController]
    public class ExpertiseController : MongoBaseController<Expertise, ExpertiseDTO>
    {
        public ExpertiseController(IMongoBaseService<Expertise> service) : base(service)
        {
        }

        [HttpPost]
        public async Task<ActionResult> CreateExpertise([FromBody] CreateExpertiseDTO request)
        {
            var response = await CreateAsync(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateExpertise(Guid id, [FromBody] UpdateExpertiseDTO request)
        {
            var response = await UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveExpertise(Guid id)
        {
            var response = await RemoveAsync(id);

            return Ok(response);
        }

        [HttpPost("import")]
        public async Task<ActionResult> Import([FromBody] CreateExpertiseDTO[] requests)
        {
            var response = await ImportAsync(requests);

            return Ok(response);
        }
    }
}
