using DbFirst.Models;
using Abstraction.ModelInterfaces;
using Abstraction;
using Microsoft.EntityFrameworkCore;
using DbFirst.Repositories;
using Abstraction.DTOs;
using BLL.Services;
using BLL.Mappers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<ICustomer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<ICar>, CarRepository>();
builder.Services.AddScoped<IRepository<IVisit>, VisitRepository>();

builder.Services.AddScoped<IService<CustomerDTO>, CustomerService>();
builder.Services.AddScoped<IService<CarDTO>, CarService>();
builder.Services.AddScoped<IService<VisitDTO>, BLL.Services.VisitService>();

builder.Services.AddAutoMapper(typeof(MapperProfile));
//builder.Services.AddAutoMapper(typeof(MapperProfile));


builder.Services.AddDbContext<CarServiceKpzContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
