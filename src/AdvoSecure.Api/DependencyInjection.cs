using AdvoSecure.Common;
using System.Reflection;

namespace AdvoSecure.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceInstallers1 = AppDomain.CurrentDomain.GetAssemblies();

            var serviceInstallers = AppDomain.CurrentDomain.GetAssemblies()
                                            .SelectMany(s => s.GetTypes())
                                            .Where(p => typeof(IServiceInstaller).IsAssignableFrom(p) && p.IsClass);

            foreach (var serviceInstaller in serviceInstallers)
            {
                var serviceInstallerInstance = Activator.CreateInstance(serviceInstaller) as IServiceInstaller;

                serviceInstallerInstance?.Install(services, configuration);
            }

            return services;
        }
    }
}
