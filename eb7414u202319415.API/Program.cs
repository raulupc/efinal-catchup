using eb7414u202319415.API.Folder.Application.ACL;
using eb7414u202319415.API.Folder.Application.Internal.CommandServices;
using eb7414u202319415.API.Folder.Domain.Repositories;
using eb7414u202319415.API.Folder.Infrastructure.Persistence.EFC.Repositories;
using eb7414u202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb7414u202319415.API.Space.Domain.Repositories;
using eb7414u202319415.API.Space.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ClickUp Platform API",
        Version = "v1",
        Description = "ClickUp Platform RESTful API - u202319415"
    });
    c.EnableAnnotations();
});

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
});

// Dependency Injection
// Shared
builder.Services.AddScoped<ISpaceContextFacade, SpaceContextFacade>();

// Space Context
builder.Services.AddScoped<ISpaceRepository, SpaceRepository>();

// Folder Context
builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddScoped<FolderCommandService>();

// Routing to Lowercase
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Auto-Create Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Esto creará la BD y tablas automáticamente si no existen
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();