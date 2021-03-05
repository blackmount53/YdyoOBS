using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YdyoOBS.Application.Common.Interfaces;

namespace YdyoOBS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<YdyoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("YdyoDatabase")));

            services.AddScoped<IYdyoDbContext>(prvider => prvider.GetService<YdyoDbContext>());

            return services;
        }
    }
}
