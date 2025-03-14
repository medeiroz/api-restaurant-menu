using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using RestaurantMenu.ApiService.Infrastructure;

namespace RestaurantMenu.ApiService.Configuration;

public static class ServiceConfiguration
{
    public static WebApplicationBuilder Build(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options => {
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
        });

        var host = builder.Configuration.GetValue<string>("POSTGRESQL:HOST") ?? "";
        var port = builder.Configuration.GetValue<string>("POSTGRESQL:PORT") ?? "";
        var user = builder.Configuration.GetValue<string>("POSTGRESQL:USERNAME") ?? "";
        var password = builder.Configuration.GetValue<string>("POSTGRESQL:PASSWORD") ?? "";
        var database = builder.Configuration.GetValue<string>("POSTGRESQL:DATABASE") ?? "";
        var dbConnection = $"Host={host};Port={port};Username={user};Password={password};Database={database}";

        builder.Services.AddDbContext<PostgreSQLContext>(options => options.UseNpgsql(dbConnection));

        return builder;
    }
}
