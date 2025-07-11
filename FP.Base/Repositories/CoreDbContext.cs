using Microsoft.EntityFrameworkCore;

namespace FP.Backend.Base.Repositories
{
    public class CoreDbContext : ApplicationDbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }
    }
}
