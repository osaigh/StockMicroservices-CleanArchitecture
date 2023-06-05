using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using StockMicroservices.API.Errors;
using StockMicroservices.API.EventBusConsumer;
using StockMicroservices.Application;
using StockMicroservices.EventBus.Common;
using StockMicroservices.Infrastructure;
using StockMicroservices.Infrastructure.Persistence;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string identityServerUrl = builder.Configuration.GetValue(typeof(string), "IdentityServerUrl").ToString();
string apiScope = builder.Configuration.GetValue(typeof(string), "APIScope").ToString();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(options => options.DefaultScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer("Bearer",
                                  config =>
                                  {
                                      config.Authority = identityServerUrl;
                                      config.Audience = apiScope;
                                      config.RequireHttpsMetadata = false;
                                      config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                                      {
                                          ValidateAudience = false,
                                          ValidateIssuer = false
                                      };
                                  });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("StockAPIPolicy",
                      policy =>
                      {
                          policy.AuthenticationSchemes.Add("Bearer");
                          policy.AddRequirements(new StockMicroservices.API.Authorization.StockAPIRequirement(apiScope));
                      });

});

builder.Services.AddScoped<IAuthorizationHandler, StockMicroservices.API.Authorization.StockAPIRequirementHandler>();
builder.Services.AddCors(config =>
{
    config.AddPolicy("AllowAll",
                     p =>
                     {
                         p.AllowAnyOrigin();
                         p.AllowAnyHeader();
                         p.AllowAnyMethod();

                     });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "StockAPI", Version = "v1" });
});
builder.Services.AddApplicationServices();
builder.Services.AddMongodbContext(builder.Configuration);
builder.Services.AddRepositories();

//MassTransit-RabbitMq
string _hostname = builder.Configuration["RabbitMq:Hostname"];
string _username = builder.Configuration["RabbitMq:Username"];
string _password = builder.Configuration["RabbitMq:Password"];
string hostAddress = string.Format("amqp://{0}:{1}@{2}:5672", _username, _password, _hostname);
if (!builder.Environment.IsEnvironment("test"))
{
    builder.Services.AddMassTransit(config =>
    {
        config.AddConsumer<StockUpdateConsumer>();

        config.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(hostAddress);

            cfg.ReceiveEndpoint(EventBusConstants.STOCK_UPDATE_QUEUE, ep =>
            {
                ep.ConfigureConsumer<StockUpdateConsumer>(provider);
            });
        }));
    });
    builder.Services.AddMassTransitHostedService();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("local"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StockAPI v1");
    });

    Console.WriteLine("Seeding Data");
    SeedData.InitializeDatabase(((IApplicationBuilder)app).ApplicationServices);
}

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            var message = (contextFeature.Error != null) ? contextFeature.Error.Message : "Internal Server Error (500)";
            if (contextFeature.Endpoint != null)
            {
                message += String.Format(" {0}", contextFeature.Endpoint);
            }

            var errorMessage = new ErrorMessage
            {
                Message = message,
                StackTrace = (contextFeature.Error != null) ? contextFeature.Error.StackTrace : string.Empty
            };

            var jsonString = JsonConvert.SerializeObject(errorMessage);

            await context.Response.WriteAsync(jsonString);
        }
    });
});

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
