﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Sociussion.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }
}