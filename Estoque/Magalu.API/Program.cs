using Magalu.Estoque.API.Module;
using Magalu.Estoque.API.Settings;
using Magalu.Estoque.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.Configure<RabbitMQSetting>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddDbContext<EstoqueContext>(
    db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEstoqueModule();


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
