using CollaboratorTest.Infrastructure.Crosscuting.DependencyInjection;
using CollaboratorTest.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCollaboratorDependencies();

builder.Services.AddCollaboratorDependencies()
                .AddDatabase(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();