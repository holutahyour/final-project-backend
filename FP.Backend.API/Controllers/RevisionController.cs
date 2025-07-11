using FP.Backend.Domain.Entities;

namespace FP.Backend.API.Controllers
{
    [Route("api/revisions")]
    [ApiController]
    public class RevisionController : MongoBaseController<Revision, Revision>
    {
        public RevisionController(IMongoBaseService<Revision> service) : base(service)
        {
        }
    }
}
