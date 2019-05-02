using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop
{
    public static class Extensions
    {
        public static IServiceCollection AddTransientWithResolver<TInterface, TImplementation>(this IServiceCollection services)
            where TImplementation : class, TInterface
            where TInterface : class
        {
            services.AddTransient<TInterface, TImplementation>();
            services.AddTransient<TImplementation, TImplementation>();
            services.AddSingleton<Func<TInterface>, Func<TImplementation>>((ioc) => ioc.GetService<TImplementation>);
            return services;
        }

        public static IServiceCollection AddScopedWithResolver<TInterface, TImplementation>(this IServiceCollection services)
            where TImplementation : class, TInterface
            where TInterface : class
        {
            services.AddScoped<TInterface, TImplementation>();
            services.AddScoped<TImplementation, TImplementation>();
            services.AddSingleton<Func<TInterface>, Func<TImplementation>>((ioc) => ioc.GetService<TImplementation>);
            return services;
        }

        public static IServiceCollection AddSingletonWithResolver<TInterface, TImplementation>(this IServiceCollection services)
            where TImplementation : class, TInterface
            where TInterface : class
        {
            services.AddSingleton<TInterface, TImplementation>();
            services.AddSingleton<TImplementation, TImplementation>();
            services.AddSingleton<Func<TInterface>, Func<TImplementation>>((ioc) => ioc.GetService<TImplementation>);
            return services;
        }
    }
}
