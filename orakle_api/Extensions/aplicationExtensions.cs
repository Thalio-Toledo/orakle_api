using Microsoft.AspNetCore.Identity;
using orakle_api.Data;
using orakle_api.Entities;
using orakle_api.services;

namespace orakle_api.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<OwnerService>();
            services.AddTransient<ArtefactService>();

            //Automaper
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            return services;
        }
    }
}
