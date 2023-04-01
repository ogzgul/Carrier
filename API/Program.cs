using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICarrierService, CarrierManager>();
builder.Services.AddSingleton<ICarrierDal, EfCarrierDal>();
builder.Services.AddSingleton<IOrderService, OrderManager>();
builder.Services.AddSingleton<IOrderDal, EfOrderDal>();
builder.Services.AddSingleton<ICarrierConfigurationService, CarrierConfigurationManager>();
builder.Services.AddSingleton<ICarrierConfigurationDal, EfCarrierConfigurationDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
