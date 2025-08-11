using IoCTask.Clients;
using IoCTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ClientsService>();
builder.Services.AddScoped<IClient, ClientFirst>();
builder.Services.AddScoped<IClient, ClientSecond>();
builder.Services.AddScoped<IClient, ClientThird>();


builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
