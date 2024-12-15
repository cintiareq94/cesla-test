using CollaboratorTest._2._Application.Handlers.CollaboratorCompanyLinkHandlers;
using CollaboratorTest._2._Application.Handlers.CollaboratorHandlers;
using CollaboratorTest._2._Application.Handlers.CompanyHandlers;
using CollaboratorTest._2._Application.Interfaces;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorCompanyLinkHandler;
using CollaboratorTest._2._Application.Interfaces.Handlers.CollaboratorHandlers;
using CollaboratorTest._2._Application.Interfaces.Handlers.CompanyHandlers;
using CollaboratorTest._2._Application.Services;
using CollaboratorTest._3._Domain.Interfaces.CollaboratorCompanyLinkInterfaces;
using CollaboratorTest._4._Infrastructure.Repositories.CollaboratorCompanyLinkRepositories;
using CollaboratorTest.Application.Interfaces;
using CollaboratorTest.Application.Services;
using CollaboratorTest.Domain.Interfaces.CollaboratorInterfaces;
using CollaboratorTest.Domain.Interfaces.CompanyInterfaces;
using CollaboratorTest.Infrastructure.Data;
using CollaboratorTest.Infrastructure.Repositories.CollaboratorRepositories;
using CollaboratorTest.Infrastructure.Repositories.CompanyRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CollaboratorTest.Infrastructure.Crosscuting.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCollaboratorDependencies(this IServiceCollection services)
        {
            // Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICollaboratorService, CollaboratorService>();
            services.AddScoped<ICollaboratorCompanyService, CollaboratorCompanyService>();

            // Repositories
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

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
                    mysqlOptions => mysqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    )
                )
            );

            return services;
        }
    }
}

