using FP.Backend.Base.Domain.Common;
using FP.Backend.Base.Domain.Entities;
using FP.Backend.Base.Repositories.Interfaces;
using FP.Backend.Base.Services.Implementation;
using FP.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FP.Backend.Services.Services.Implementations;

public class UserService : MongoBaseService<User>, IUserService
{
    private readonly IMongoRepository<User> _userRepository;
    private readonly IMongoRepository<Faculty> _facultyRepository;
    private readonly IMongoRepository<Department> _departmentRepository;
    private readonly IMongoRepository<Level> _levelRepository;
    private readonly IMongoRepository<Expertise> _expertiseRepository;
    private readonly IMapper _mapper;

    public UserService(
        IMongoRepository<User> repository,
        IMongoRepository<Faculty> facultyRepository,
        IMongoRepository<Department> departmentRepository,
        IMongoRepository<Level> levelRepository,
        IMongoRepository<Expertise> expertiseRepository,
        IMongoRepository<AuditLog> auditLogRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper
        ) : base(repository, auditLogRepository, mapper, httpContextAccessor)
    {
        _userRepository = repository;
        _facultyRepository = facultyRepository;
        _departmentRepository = departmentRepository;
        _levelRepository = levelRepository;
        _expertiseRepository = expertiseRepository;
        _mapper = mapper;
    }

    public override async Task<Result<dynamic>> GetAllAsync<TResponse>(
        string search = null,
        string filter = null,
        int page = 1,
        int pageSize = 10,
        string select = null)
    {
        Result<dynamic> result = new(false);

        try
        {

            var response = await _userRepository.GetAllAsync(search, filter, page, pageSize);
            var responseDTO = await GetAllUsersAsync(response);

            // Selecting specific properties
            if (!string.IsNullOrEmpty(select))
            {
                var selectedProperties = select.Split(',', StringSplitOptions.TrimEntries);
                var selectedData = responseDTO.Select(s => BaseServiceHelper.SelectProperties(s, selectedProperties)).ToList();


                result.SetSuccess(selectedData, "Retrieved Successfully.");

                return result;
            }

            result.SetSuccess(responseDTO, "Retrieved Successfully.");
        }
        catch (Exception ex)
        {
            result.SetError(ex.Message, $"Error while retrieving {typeof(User).Name}");

            return result;
        }
        return result;
    }

    public virtual async Task<Result<IList<UserDTO>>> GetUserByRoleAsync(string role)
    {
        var result = new Result<IList<UserDTO>>(false);

        try
        {
            var users = await _userRepository.GetAllAsync();

            var response = users.Where(u => u.Roles.Contains(role)).ToList();

            result.SetSuccess((await GetAllUsersAsync(response)), "Retrieved successfully.");
        }
        catch (Exception ex)
        {
            result.SetError(ex.ToString(), "Error while retrieving records.");
        }

        return result;
    }

    public async Task<IList<UserDTO>> GetAllUsersAsync(IList<User> users)
    {
        var faculties = await _facultyRepository.GetAllAsync();
        var departments = await _departmentRepository.GetAllAsync();
        var levels = await _levelRepository.GetAllAsync();
        var expertises = await _expertiseRepository.GetAllAsync();

        var userDTOs = _mapper.Map<IList<UserDTO>>(users);

        foreach (var user in userDTOs)
        {
            user.Faculty = (faculties?.FirstOrDefault(x => x.Id == user.FacultyId))?.Name;
            user.Department = (departments?.FirstOrDefault(x => x.Id == user.DepartmentId))?.Name;
            user.Level = (levels?.FirstOrDefault(x => x.Id == user.LevelId))?.Name;
            user.Expertise = (expertises?.FirstOrDefault(x => x.Id == user.ExpertiseId))?.Name;
        }

        return userDTOs;
    }
}
