using System.Reflection;
using CustomerManagement.API.GraphQL;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Infrastructure.Data;
using CustomerManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FluentValidation;
using CustomerManagement.API.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CustomerDbContext>(options =>
    options.UseInMemoryDatabase("CustomerDb"));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer Management API", Version = "v1" });
});

var app = builder.Build();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DbInitializer.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Management API v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();

app.Run();