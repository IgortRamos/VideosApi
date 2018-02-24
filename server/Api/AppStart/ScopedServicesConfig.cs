using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Api.Services.Base;

namespace Api.AppStart
{
    public static class ScopedServicesConfig
    {
        public static void ConfigureScopedServices(this IServiceCollection services)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(p => typeof(IScopedServiceBase).IsAssignableFrom(p) && p.Name != nameof(IScopedServiceBase)).ToList();

            var addScopedMethod = typeof(ServiceCollectionServiceExtensions)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.Name == nameof(ServiceCollectionServiceExtensions.AddScoped))
                .Where(x => x.IsGenericMethodDefinition && x.ContainsGenericParameters)
                .Where(x => x.GetParameters().Length == 1 && x.GetParameters().FirstOrDefault()?.ParameterType == typeof(IServiceCollection))
                .FirstOrDefault(x => x.GetGenericArguments().Length == 1);

            foreach (var type in types) addScopedMethod?.MakeGenericMethod(type).Invoke(null, new object[] { services });
        }
    }
}