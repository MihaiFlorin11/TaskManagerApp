using TaskManager.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString =
    builder.Configuration.GetConnectionString("Database")
    ?? throw new InvalidOperationException(
        "Connection string 'Database' was not found.");

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
