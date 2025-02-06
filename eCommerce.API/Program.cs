using eCommerce.Core;
using eCommerce.Infrastructure;
using eCommerce.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure services
builder.Services.AddInfrastructure();

// Add Core services
builder.Services.AddCore();

// Add controllers to the service collection
builder.Services.AddControllers();

// Build web app
var app = builder.Build();

// Use eCommerce.API.Middleware
app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controller routes
app.MapControllers();

app.Run();