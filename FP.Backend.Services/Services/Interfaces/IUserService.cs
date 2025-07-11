using FP.Backend.Base.Domain.Common;

namespace FP.Services.Interfaces;

public interface IUserService : IMongoBaseService<User>
{
    Task<Result<IList<UserDTO>>> GetUserByRoleAsync(string role);
}
