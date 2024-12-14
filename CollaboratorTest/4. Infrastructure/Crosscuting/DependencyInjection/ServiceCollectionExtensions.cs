using CollaboratorTest.Application.Handlers.Commands;
using CollaboratorTest.Application.Handlers.Commands.CollaboratorCommands;
using CollaboratorTest.Application.Handlers.Queries;
using CollaboratorTest.Application.Interfaces;
using CollaboratorTest.Application.Services;
using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;
using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;
using CollaboratorTest.Infrastructure.Repositories.CollaboratorRepositories;
using CollaboratorTest.Infrastructure.Repositories.CompanyRepositories;

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
            services.AddScoped<ICollaboratorCompanyLinkRepository, CollaboratorCompanyLinkRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICollaboratorCommandRepository, CollaboratorCommandRepository>();
            services.AddTransient<ICollaboratorQueryRepository, CollaboratorQueryRepository>();
            services.AddTransient<ICompanyCommandRepository, CompanyCommandRepository>();
            services.AddTransient<ICompanyQueryRepository, CompanyQueryRepository>();

            // Handlers
            services.AddTransient<AddCollaboratorHandler>();
            services.AddTransient<AddCollaboratorCompanyLinkHandler>();
            services.AddTransient<UpdateCollaboratorHandler>();
            services.AddTransient<DeleteCompanyHandler>();
            services.AddTransient<GetCollaboratorsHandler>();
            services.AddTransient<GetCollaboratorByIdHandler>();
            services.AddTransient<GetEnabledCollaboratorsHandler>();

            return services;

        }
    }
}

