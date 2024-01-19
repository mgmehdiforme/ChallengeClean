namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddControllers();        

        services.AddOpenApiDocument((configure, sp) =>
        {
            configure.Title = "ChallengeClean API";

        });        

        return services;
    }
}
