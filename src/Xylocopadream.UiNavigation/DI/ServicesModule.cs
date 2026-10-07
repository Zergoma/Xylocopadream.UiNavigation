using Microsoft.Extensions.DependencyInjection;

namespace Xylocopadream.UiNavigation.DI;

public static class ServicesModule
{
    /// <summary>
    /// Registers <see cref="INavigatorService"/> with the pages it can navigate to.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="entries">One entry per page identifier (duplicates are rejected)</param>
    /// <returns></returns>
    public static IServiceCollection AddUiNavigationServices(this IServiceCollection services, params PageRegistryEntry[] entries)
    {
        services.AddSingleton(new PageRegistry(entries));

        services.AddTransient<INavigatorService, NavigatorService>();   // IServiceProvider, PageRegistry

        return services;
    }
}
