using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection {

    /// <summary>
    /// Extension method to add Core services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //TODO: Add services to the IoC Container
        // Core services 
        services.AddSingleton<IUserService, UserService>();
        return services;
    }

}