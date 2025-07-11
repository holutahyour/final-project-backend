using FP.Backend.Base.Services;
using Google.Apis.Auth.OAuth2;

namespace FP.Backend.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile("fp-firebase.json"),
        });

        // Create an instance of AutoMapperConfig
        var mapperConfig = new AutoMapperConfig();
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(mapperConfig);
        });

        IMapper mapper = mapperConfiguration.CreateMapper();

        services
            .AddSingleton(mapper)
            .AddMongoService<User>("users")
            .AddMongoService<Role>("roles")
            //.AddMongoService<UserRole>("user-roles")
            .AddMongoService<Submission>("submissions")
            .AddMongoService<Revision>("revisions")
            .AddMongoService<Feedback>("feedbacks");

        return services;
    }
}
