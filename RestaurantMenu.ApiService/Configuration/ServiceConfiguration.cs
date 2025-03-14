using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;

namespace RestaurantMenu.ApiService.Configuration;

public static class ServiceConfiguration
{
    public static WebApplicationBuilder Build(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options => {
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
        });

        return builder;
    }
}
