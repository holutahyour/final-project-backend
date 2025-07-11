using FP.Backend.Domain.Entities;

namespace FP.Backend.API.Controllers
{
    [Route("api/submissions")]
    [ApiController]
    public class SubmissionController : MongoBaseController<Submission, Submission>
    {
        public SubmissionController(IMongoBaseService<Submission> service) : base(service)
        {
        }
    }
}
