global using Microsoft.EntityFrameworkCore;
global using PlatformService.Data;
using PlatformService.SynceDataService.Htpp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    if (env.IsProduction())
    {
        Console.WriteLine("---> Using SqlServer Db");
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));
    }
    else
    {
        Console.WriteLine("---> Using InMem Db");
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
    }

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    services.AddCors();
    services.AddControllers();

    // configure DI for application services
    services.AddScoped<IPlatformRepo, PlatformRepo>();

    services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

    Console.WriteLine($"---> CommandService Endpoint {builder.Configuration["CommandService"]}");

}


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


PrepDb.PrepPopilation(app, builder.Environment.IsProduction());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

