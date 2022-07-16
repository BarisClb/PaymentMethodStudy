using FluentValidation.AspNetCore;
using MediatR;
using PaymentMethodStudy.Application;
using PaymentMethodStudy.Infrastructure;
using PaymentMethodStudy.Persistence;
using PaymentMethodStudy.WebAPI.Filters;
using PaymentMethodStudy.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Adding Service Registrations
builder.Services.ImplementApplicationServices();
builder.Services.ImplementInfrastructureServices();
builder.Services.ImplementPersistenceServices(builder.Configuration.GetConnectionString("MsSQL"));

// Adding Logging
//builder.Services.AddLogging();
//builder.Host.ConfigureDefaults(args).ConfigureLogging((context, logging) =>
//{
//    logging.ClearProviders();
//    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
//    logging.AddDebug();
//    logging.AddConsole();
//});

// Adding Mediatr
//builder.Services.AddMediatR(typeof(Program).Assembly);

// Adding CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PaymentMethodStudy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000",
                                       "http://localhost:3001")
                                       .AllowAnyHeader()
                                       .AllowAnyMethod()
                                       .AllowCredentials();
        });
});

// Adding Filters and Validation (FluentValidation)
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining(typeof(PaymentMethodStudy.Infrastructure.FluentValidation.Account.CreateAccountCommandValidator)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Using Cors
app.UseCors("PaymentMethodStudy");

// Using Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
