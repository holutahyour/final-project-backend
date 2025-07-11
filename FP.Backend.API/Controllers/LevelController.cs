using FP.Backend.Domain.Entities;
using FP.Domain.DTOs;

namespace FP.Backend.API.Controllers
{
    [Route("api/levels")]
    [ApiController]
    public class LevelController : MongoBaseController<Level, Level>
    {
        public LevelController(IMongoBaseService<Level> service) : base(service)
        {
        }

        [HttpPost]
        public async Task<ActionResult> CreateLevel([FromBody] CreateLevelDTO request)
        {
            var response = await CreateAsync(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLevel(Guid id, [FromBody] UpdateLevelDTO request)
        {
            var response = await UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveLevel(Guid id)
        {
            var response = await RemoveAsync(id);

            return Ok(response);
        }

        [HttpPost("import")]
        public async Task<ActionResult> Import([FromBody] CreateLevelDTO[] requests)
        {
            var response = await ImportAsync(requests);

            return Ok(response);
        }
    }
}
