using Application.Behaviours;
using Application.Features.Products.Commands.CreateProduct;
using Application.Mappings;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            // Add AutoMapper,FluentValidation and MediatR to  the service collection
         
            services.AddAutoMapper(typeof(GeneralProfile));

            services.AddScoped<IValidator, CreateProductCommandValidator>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // add MediatR
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Add the ValidationBehavior to service collection
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
