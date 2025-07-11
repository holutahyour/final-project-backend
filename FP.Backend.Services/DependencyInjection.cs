using FP.Backend.Base.Services;
using FP.Backend.Services.Services.Implementations;
using FP.Services.Interfaces;
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
            .AddMongoService<Level>("levels")
            .AddMongoService<Faculty>("faculties")
            .AddMongoService<Department>("departments")
            .AddMongoService<Expertise>("expertises")
            //.AddMongoService<UserRole>("user-roles")
            .AddMongoService<Submission>("submissions")
            .AddMongoService<Revision>("revisions")
            .AddMongoService<Feedback>("feedbacks")
            .AddScoped<IUserService, UserService>();

        return services;
    }
}
