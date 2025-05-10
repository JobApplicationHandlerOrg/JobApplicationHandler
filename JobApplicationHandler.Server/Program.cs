using System.Text.Json.Serialization;
using JobApplicationHandler.Server.Configurations.Extensions.Configuration;
using JobApplicationHandler.Server.Configurations.Extensions.DbContexts;
using JobApplicationHandler.Server.Configurations.Extensions.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

//Configurations
builder.Configuration.AddDConfigurationSettings(builder.Environment);
//Services
builder.Services.AddServiceRegistration(builder.Configuration);
//DB Contexts
builder.Services.AddDbContextRegistration(builder.Configuration);

builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
//Extensions
app.UseExceptionHandler();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();