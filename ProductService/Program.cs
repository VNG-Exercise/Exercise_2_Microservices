using ProductService.Endpoints;
using ProductService.Extensions.PipelineExtensions;
using ProductService.Extensions.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGeneralConfigurations();
builder.Services.AddDbContextConfigurations(builder.Configuration);

var app = builder.Build();

app.UseGeneralConfigurations(app.Environment);
app.MapAppEndpoints();
app.UseMigrationDatabase();

app.Run();
