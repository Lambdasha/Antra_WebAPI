using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Interfaces;
using Order.ApplicationCore.Interfaces.Services;
using Order.Infrastructure.Data;
using Order.Infrastructure.Repositories;
using Order.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("OrderDbConnection")));

builder.Services.AddScoped<IOrderRepository,      OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository,OrderDetailRepository>();
builder.Services.AddScoped<IOrderService,         OrderService>();

builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler =
        ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();