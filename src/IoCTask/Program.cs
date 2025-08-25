using IoCTask.Clients;
using IoCTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ClientsService>();
builder.Services.AddTransient<IClient, ClientFirst>();
builder.Services.AddTransient<IClient, ClientSecond>();
builder.Services.AddTransient<IClient, ClientThird>();


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
