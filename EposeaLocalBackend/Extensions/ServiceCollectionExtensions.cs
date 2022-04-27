using Autofac;
using Autofac.Builder;
using EposeaLocalBackend.API.Helpers;
using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace EposeaLocalBackend.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ContainerBuilder RegisterAllServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.UseAllOfType<ISingletonService>(ServiceLifetime.Singleton);
            containerBuilder.UseAllOfType<IScopedService>(ServiceLifetime.Scoped);
            containerBuilder.UseAllOfType<ITransientService>(ServiceLifetime.Transient);

            return containerBuilder;
        }
        public static ContainerBuilder UseAllOfType<T>(this ContainerBuilder serviceCollection, ServiceLifetime lifetime)
        {
            return serviceCollection.UseAllOfType<T>(AssemblyHelper.GetSolutionAssemblies(), lifetime);
        }
        public static ContainerBuilder UseAllOfType<T>(this ContainerBuilder serviceCollection, Assembly[] assemblies, ServiceLifetime lifetime)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.IsClass && x.GetInterfaces().Contains(typeof(T))));

            foreach (var type in typesFromAssemblies)
            {
                var it = type.GetInterfaces();
                var ind = Array.IndexOf(it, typeof(T)) - 1;

                serviceCollection.RegisterType(type)
                   .As(type.GetInterfaces()[ind])
                   .UseLifetime(lifetime);
            }

            return serviceCollection;
        }
        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            UseLifetime(this IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> regBuilder, ServiceLifetime lifetime)
        {
            return lifetime switch
            {
                ServiceLifetime.Scoped => regBuilder.InstancePerLifetimeScope(),
                ServiceLifetime.Singleton => regBuilder.SingleInstance(),
                ServiceLifetime.Transient => regBuilder.InstancePerDependency(),
                _ => regBuilder.InstancePerDependency(),
            };
        }

        public static IServiceCollection DisableCachingForAllHttpCalls(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddMvc(options =>
                {
                    // Turns off Caching for the entire API
                    options.Filters.Add(new ResponseCacheAttribute { NoStore = true, Location = ResponseCacheLocation.None });
                });

            return serviceCollection;
        }

        public static TConfig ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration, Func<TConfig> pocoProvider) where TConfig : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (pocoProvider == null)
            {
                throw new ArgumentNullException(nameof(pocoProvider));
            }

            var config = pocoProvider();
            configuration.Bind(config);
            services.AddSingleton(config);

            return config;
        }

        public static TConfig ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration, TConfig config) where TConfig : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            configuration.Bind(config);
            services.AddSingleton(config);
            return config;
        }

        public static TConfig ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var config = new TConfig();
            configuration.Bind(config);
            services.AddSingleton(config);

            return config;
        }
    }
}
