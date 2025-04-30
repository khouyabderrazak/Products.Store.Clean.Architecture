using WebApi.Extensions;
using Application;
using Infrastructure.Persistence;
using Infrastructure.Shared;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//what 's  AddOnpenApi :
// AddOpenApi is a method that adds OpenAPI (Swagger) support to the ASP.NET Core application.
builder.Services.AddOpenApi();

builder.Services.AddApplicationLayer();

builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


var app = builder.Build();


var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
var Log = loggerFactory.CreateLogger("seedData");

try
{
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
    await Infrastructure.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
    await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);
    Log.LogInformation("Finished Seeding Default Data");
    Log.LogInformation("Application Starting");
}
catch (Exception ex)
{
    Log.LogError (ex, "An error occurred seeding the DB");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
     //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
