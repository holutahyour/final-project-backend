using Microsoft.EntityFrameworkCore;

namespace FP.Backend.Base.Repositories
{
    public interface IApplicationDbContext
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}