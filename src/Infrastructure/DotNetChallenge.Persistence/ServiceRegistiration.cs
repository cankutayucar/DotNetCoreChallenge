using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Application.Interfaces.Repository;
using DotNetChallenge.Persistence.Context;
using DotNetChallenge.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetChallenge.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceRegistiration(this IServiceCollection services,string conStr)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(conStr);
            });


            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

        }
    }
}
