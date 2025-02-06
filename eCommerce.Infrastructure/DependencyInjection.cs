using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection {

    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //TODO: Add services to the IoC Container
        // Infrastructure services often include data access, caching and other low-level components.

        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }

}