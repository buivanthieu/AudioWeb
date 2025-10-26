
using AudioWeb.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Audio.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<AudioDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Add MediatR
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
            });

            // Add AutoMapper
            //services.AddAutoMapper(typeof(AudioMapppingProfile));

            // Add Repositories
            //services.AddScoped<IMessageRepository, MessageRepository>();
            //services.AddScoped<IConversationRepository, ConversationRepository>();
            //services.AddScoped<IUserConversationRepository, UserConversationRepository>();


            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = configuration["Jwt:Issuer"],
            //        ValidAudience = configuration["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(
            //            Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)
            //        )
            //    };
            //});


            // Add Controllers
            services.AddControllers();

            return services;
        }
    }
}
