namespace CleanArchtecture.API.Extensions;

public static class CorsPolicyExtensions
{
    public static void ConfigureCorsPolicy(this IServiceCollection services){
        services.AddCors(opt=> {
            opt.AddDefaultPolicy(builder => builder
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader());

        });
    }
}
