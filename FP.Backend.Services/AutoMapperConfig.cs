namespace FP.Backend.Services;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        //AddMappingType(typeof(User), typeof(UserDTO));
        //AddMappingType(typeof(User), typeof(CreateUserDTO));
        //AddMappingType(typeof(User), typeof(UpdateUserDTO));
        //AddMappingType(typeof(User), typeof(PublicUserDTO));
        //AddMappingType(typeof(User), typeof(RelationshipUserDTO));

        AddMappingType(typeof(User), typeof(UserDTO));
        AddMappingType(typeof(User), typeof(CreateUserDTO));
        AddMappingType(typeof(User), typeof(UpdateUserDTO));

        AddMappingType(typeof(Role), typeof(RoleDTO));
        AddMappingType(typeof(Role), typeof(CreateRoleDTO));
        AddMappingType(typeof(Role), typeof(UpdateRoleDTO));

        AddMappingType(typeof(Level), typeof(LevelDTO));
        AddMappingType(typeof(Level), typeof(CreateLevelDTO));
        AddMappingType(typeof(Level), typeof(UpdateLevelDTO));

        AddMappingType(typeof(Faculty), typeof(FacultyDTO));
        AddMappingType(typeof(Faculty), typeof(CreateFacultyDTO));
        AddMappingType(typeof(Faculty), typeof(UpdateFacultyDTO));

        AddMappingType(typeof(Department), typeof(DepartmentDTO));
        AddMappingType(typeof(Department), typeof(CreateDepartmentDTO));
        AddMappingType(typeof(Department), typeof(UpdateDepartmentDTO));

        AddMappingType(typeof(Expertise), typeof(ExpertiseDTO));
        AddMappingType(typeof(Expertise), typeof(CreateExpertiseDTO));
        AddMappingType(typeof(Expertise), typeof(UpdateExpertiseDTO));


        ConfigureStandardMappings();
        ConfigureCustomMappings();
    }

    private List<KeyValuePair<Type, Type>> mappings = new();

    public virtual void ConfigureStandardMappings()
    {
        foreach (var mapping in mappings)
        {
            CreateMap(mapping.Key, mapping.Value).ReverseMap();
        }
    }

    public virtual void AddMappingType(Type entityType, Type dtoType)
    {
        mappings.Add(new KeyValuePair<Type, Type>(entityType, dtoType));
    }

    public virtual void ConfigureCustomMappings()
    {
    }
}

