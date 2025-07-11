using FP.Backend.Domain.Entities;

namespace FP.Backend.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : MongoBaseController<Role, Role>
    {
        public RoleController(IMongoBaseService<Role> service) : base(service)
        {
        }
    }
}
