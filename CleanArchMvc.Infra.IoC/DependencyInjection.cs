﻿using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, serverVersion));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile), typeof(DTOToCommandMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("CleanArchMvc.Application"));
            });


            return services;
        }
    }
}
