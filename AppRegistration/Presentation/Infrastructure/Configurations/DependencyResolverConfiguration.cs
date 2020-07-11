using DAL.Repositories;
using DAL.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Infrastructure.Configurations
{
    public static class DependencyResolverConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
