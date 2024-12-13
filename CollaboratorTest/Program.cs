using CollaboratorTest.Application.Handlers.Commands;
using CollaboratorTest.Application.Handlers.Queries;
using CollaboratorTest.Application.Interfaces;
using CollaboratorTest.Application.Services;
using CollaboratorTest.Domain.Interfaces;
using CollaboratorTest.Infrastructure.Crosscuting.DependencyInjection;
using CollaboratorTest.Infrastructure.Data;
using CollaboratorTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração de dependências usando a camada de Crosscutting
builder.Services.AddCollaboratorDependencies();

//// Serviços
//builder.Services.AddScoped<ICollaboratorService, CollaboratorService>();
//builder.Services.AddScoped<ICompanyService, CompanyService>();

//// Repositórios
//builder.Services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
//builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
//builder.Services.AddTransient<ICollaboratorCommandRepository, CollaboratorCommandRepository>();
//builder.Services.AddTransient<ICollaboratorQueryRepository, CollaboratorQueryRepository>();

//// Handlers
//builder.Services.AddTransient<AddCollaboratorHandler>();
//builder.Services.AddTransient<UpdateCollaboratorHandler>();
//builder.Services.AddTransient<DeleteCollaboratorHandler>();
//builder.Services.AddTransient<GetCollaboratorsHandler>();
//builder.Services.AddTransient<GetCollaboratorByIdHandler>();
//builder.Services.AddTransient<GetEnabledCollaboratorsHandler>();

// Configuração do DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 4, 3)),
        mysqlOptions => mysqlOptions.EnableRetryOnFailure(
            maxRetryCount: 2,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null
        )
    )
);

// Configuração dos controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();