using IoCTask.Clients;
using IoCTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ClientsService>();
builder.Services.AddScoped<IClient, ClientFirst>();
builder.Services.AddScoped<IClient, ClientSecond>();
builder.Services.AddScoped<IClient, ClientThird>();


builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}   

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
