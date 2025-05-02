using JobApplicationHandler.Server.Configurations.DBContexts;
using JobApplicationHandler.Server.Configurations.ServiceRegistration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

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

app.MapControllers();
app.UseHttpsRedirection();

app.Run();