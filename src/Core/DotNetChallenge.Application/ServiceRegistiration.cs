using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Application.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetChallenge.Application
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationRegistiration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
            services.AddCustomValidationResponse();
        }
    }
}
