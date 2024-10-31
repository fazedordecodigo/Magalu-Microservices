using Magalu.Carrinho.API.Module;
using Magalu.Carrinho.Application.Settings;
using Magalu.Infraestructure.Publishers;
using Magalu.Carrinho.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.Configure<RabbitMQSetting>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddScoped(typeof(IPublisher<>), typeof(RabbitMqPublisher<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarrinhoModule();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
