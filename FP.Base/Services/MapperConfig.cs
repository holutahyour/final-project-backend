using AutoMapper;

namespace FP.Backend.Base.Services
{
    public class MapperConfig : Profile
    {
        private List<Type> mappings = new();

        public virtual void ConfigureStandardMappings()
        {

            foreach (var type in mappings)
            {
                CreateMap(type, GetDtoType(type)).ReverseMap();

                var createDtoType = GetCreateDtoType(type);
                if (createDtoType != null)
                    CreateMap(type, createDtoType)?.ReverseMap();

                var updateDtoType = GetUpdateDtoType(type);
                if (updateDtoType != null)
                    CreateMap(type, updateDtoType)?.ReverseMap();
            }
        }

        public virtual void AddMappingType(Type type)
        {
            mappings.Add(type);
        }

        public virtual void ConfigureCustomMappings()
        {
            // Custom mappings with member configurations           
        }

        private Type GetDtoType(Type entityType)
        {
            return Type.GetType($"{entityType.Namespace}.{entityType.Name}DTO");
        }

        private Type GetCreateDtoType(Type entityType)
        {
            return Type.GetType($"{entityType.Namespace}.Create{entityType.Name}DTO");
        }

        private Type GetUpdateDtoType(Type entityType)
        {
            return Type.GetType($"{entityType.Namespace}.Update{entityType.Name}DTO");
        }
    }
}
