using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using orakle_api.Data;
using orakle_api.Entities;
using orakle_api.Interfaces;
using orakle_api.services;
using System.Text;

namespace orakle_api.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDataBaseConection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(config =>
            {
                config.UseSqlite("Data Source=Data\\orackle.db");
            });

            services.AddIdentity<Owner, IdentityRole<Guid>>()
                   .AddEntityFrameworkStores<DataContext>()
                   .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var jwtIssuer = configuration["JwtSettings:Issuer"];
                var jwtAudience = configuration["JwtSettings:Audience"];
                var jwtKey = configuration["JwtSettings:Key"] ?? Environment.GetEnvironmentVariable("JWT_SECRET");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

            services.AddScoped<AuthService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
