﻿using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsManager.Aplication;
using ProductsManager.Entities;
using ProductsManager.Infra.Data;
using ProductsManager.Interfaces;
using ProductsManager.Validations;
using System;

namespace ProductsManager.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IProductsAplication, ProductsAplication>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }
    }
}
