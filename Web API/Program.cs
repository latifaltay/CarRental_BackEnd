using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CarRentalContex>(cfg =>
{
    cfg.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:devDb").Value);
});

//builder.Services.Configure<CarRentalContex>(
//    builder.Configuration.GetSection("ConnectionStrings:devDb"));


//builder.Services.AddDbContext<CarRentalContex>(cfg => {
//    cfg.UseSqlServer(builder.Configuration.GetConnectionString("devDb"));
//});


//builder.Services.AddSingleton<IBrandService, BrandManager>();
//builder.Services.AddSingleton<IBrandDal, EfBrandDal>();

//builder.Services.AddSingleton<ICarService, CarManager>();
//builder.Services.AddSingleton<ICarDal, EfCarDal>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Autofac implementasyonu
//builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory()).
//    ConfigureContainer<ContainerBuilder>(builder =>
//    { builder.RegisterModule(new AutofacBusinessModule()); });

builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory()).
    ConfigureContainer<ContainerBuilder>(builder =>
    { builder.RegisterModule(new AutofacBusinessModule()); });


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
