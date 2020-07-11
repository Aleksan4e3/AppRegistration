using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Infrastructure.Configurations
{
    public static class ContextConfiguration
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDataContext, DataContext>();
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"])
                        .UseLazyLoadingProxies());
        }
    }
}
