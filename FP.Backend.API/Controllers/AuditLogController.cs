namespace FP.Backend.API.Controllers
{
    [Route("api/audit-logs")]
    [ApiController]
    public class AuditLogController : MongoBaseController<AuditLog, AuditLog>
    {
        public AuditLogController(IMongoBaseService<AuditLog> service) : base(service)
        {
        }
    }
}
