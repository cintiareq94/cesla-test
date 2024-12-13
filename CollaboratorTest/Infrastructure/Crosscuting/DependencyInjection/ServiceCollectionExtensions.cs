using CollaboratorTest.Application.Handlers.Commands;
using CollaboratorTest.Application.Handlers.Queries;
using CollaboratorTest.Application.Interfaces;
using CollaboratorTest.Application.Services;
using CollaboratorTest.Domain.Interfaces;
using CollaboratorTest.Infrastructure.Repositories;

namespace CollaboratorTest.Infrastructure.Crosscuting.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCollaboratorDependencies(this IServiceCollection services)
        {
            // Serviços
            services.AddScoped<ICollaboratorService, CollaboratorService>();
            services.AddScoped<ICompanyService, CompanyService>();

            // Repositórios
            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICollaboratorCommandRepository, CollaboratorCommandRepository>();
            services.AddTransient<ICollaboratorQueryRepository, CollaboratorQueryRepository>();

            // Handlers
            services.AddTransient<AddCollaboratorHandler>();
            services.AddTransient<UpdateCollaboratorHandler>();
            services.AddTransient<DeleteCollaboratorHandler>();
            services.AddTransient<GetCollaboratorsHandler>();
            services.AddTransient<GetCollaboratorByIdHandler>();
            services.AddTransient<GetEnabledCollaboratorsHandler>();

            return services;

        }
    }
}

