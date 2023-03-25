using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDemo.Application.Interfaces;
using UniversityDemo.Application.Services;
using UniversityDemo.Domain.CommandHandlers;
using UniversityDemo.Domain.Commands;
using UniversityDemo.Domain.Core.Bus;
using UniversityDemo.Domain.Interfaces;
using UniversityDemo.Infra.Bus;
using UniversityDemo.Infra.Data.Context;
using UniversityDemo.Infra.Data.Repository;

namespace UniversityDemo.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain InMemoryBus MediatR
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain Handlers
            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();

            // Application layer
            services.AddScoped<ICourseService, CourseService>();

            // Infra.Data layer
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<UniversityDBContext>();
        }
    }
}
