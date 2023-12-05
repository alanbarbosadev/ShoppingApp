using Microsoft.EntityFrameworkCore;
using ShoppingApp.Api.Extensions;
using ShoppingApp.Infra.DataContext;
using ShoppingApp.Infra.DataContext.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
ApplicationServiceExtension.AddApplicationServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

//app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

//Apply pending migrations before running the app
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ShoppingAppContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await ShoppingAppContextSeed.SeedAsync(context);
}
catch(Exception ex)
{
    logger.LogError(ex, "An error occurred during migration or data seed!");
}

app.Run();
