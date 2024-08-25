using CartService.Endpoints;
using CartService.Extensions.PipelineExtensions;
using CartService.Extensions.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGeneralConfigurations(builder.Configuration);
builder.Services.AddInjectedServices(builder.Configuration);
builder.Services.AddDbContextConfigurations(builder.Configuration);

var app = builder.Build();

app.UseGeneralConfigurations(app.Environment);
app.MapAppEndpoints();
app.UseMigrationDatabase();

app.Run();
