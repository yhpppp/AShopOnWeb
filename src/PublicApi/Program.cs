using ApplicationCore.Interfaces;
using Infrastructure.Data;
using MinimalApi.Endpoint.Extensions;
using PublicApi;

var builder = WebApplication.CreateBuilder(args);

Infrastructure.Dependencies.ConfigureService(builder.Services, builder.Configuration);

// Add services to the container.
builder.Services.AddEndpoints();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

var app = builder.Build();

app.Logger.LogInformation("PublicApi App Created");
app.Logger.LogInformation("Seeding Database");

using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    try
    {
        var context = provider.GetRequiredService<CatalogContext>();
        await CatalogContextSeed.SeedAsync(context, app.Logger);

    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding in DB");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}

app.UseAuthorization();

app.MapControllers();

app.MapEndpoints();

app.Run();
