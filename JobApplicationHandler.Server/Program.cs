using JobApplicationHandler.Server.Configurations.DBContexts;
using JobApplicationHandler.Server.Configurations.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddServiceRegistration(builder.Configuration);
//DB Contexts
builder.Services.AddDbContextRegistration(builder.Configuration);

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();


