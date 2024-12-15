using CollaboratorTest._2._Application.Handlers.CollaboratorCompanyLinkHandlers;
using CollaboratorTest._2._Application.Handlers.CollaboratorHandlers;
using CollaboratorTest._2._Application.Handlers.CompanyHandlers;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorCompanyLinkHandler;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorHandlers;
using CollaboratorTest._2._Application.Interfaces.Handlers.CompanyHandlers;
using CollaboratorTest._3._Domain.Interfaces.CollaboratorCompanyLinkInterfaces;
using CollaboratorTest._4._Infrastructure.Repositories.CollaboratorCompanyLinkRepositories;
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
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICollaboratorService, CollaboratorService>();

            // Repositórios
            services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
            services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();

            services.AddScoped<ICollaboratorCommandRepository, CollaboratorCommandRepository>();
            services.AddScoped<ICollaboratorQueryRepository, CollaboratorQueryRepository>();

            services.AddScoped<ICollaboratorCompanyLinkCommandRepository, CollaboratorCompanyLinkCommandRepository>();
            services.AddScoped<ICollaboratorCompanyLinkQueryRepository, CollaboratorCompanyLinkQueryRepository>();
            
            // Handlers
            services.AddTransient<IWriterCompanyHandler, WriterCompanyHandler>();
            services.AddTransient<IReaderCompanyHandler, ReaderCompanyHandler>();

            services.AddTransient<IWriterCollaboratorHandler, WriterCollaboratorHandler>();
            services.AddTransient<IReaderCollaboratorHandler, ReaderCollaboratorHandler>();
            
            services.AddTransient<IWriterCollaboratorCompanyLinkHandler, WriterCollaboratorCompanyLinkHandler>();
            services.AddTransient<IReaderCollaboratorCompanyLinkHandler, ReaderCollaboratorCompanyLinkHandler>();

            return services;

        }
    }
}

