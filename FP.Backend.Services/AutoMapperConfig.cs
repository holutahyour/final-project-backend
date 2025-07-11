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

