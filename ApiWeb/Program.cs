using WebApi.Extensions;
using Application;
using Infrastructure.Persistence;
using Infrastructure.Shared;

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

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

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
