using Microsoft.Extensions.DependencyInjection;
using FP.Backend.Base.Repositories.Implementations;
using FP.Backend.Base.Services.Implementation;
using FP.Backend.Base.Services.Interface;

namespace FP.Backend.Base.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddBaseServices(this IServiceCollection services)
    {
        services.AddMongo()
            .AddMongoService<AuditLog>("AuditLog");
        //.AddMongoService<Course>("Items");

       //services.AddScoped<IMongoBaseService, MongoBaseService>();

        return services;
    }
}
