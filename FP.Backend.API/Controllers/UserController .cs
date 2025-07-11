using FP.Backend.Domain.Entities;

namespace FP.Backend.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : MongoBaseController<User, User>
    {
        public UserController(IMongoBaseService<User> service) : base(service)
        {
        }
    }
}
