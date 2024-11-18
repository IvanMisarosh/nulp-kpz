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
builder.Services.AddScoped<IRepository<IVisitStatus>, VisitStatusRepository>();
builder.Services.AddScoped<IRepository<IPaymentStatus>, PaymentStatusRepository>();
builder.Services.AddScoped<IRepository<IEmployee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<ICarModel>, CarModelRepository>();
builder.Services.AddScoped<IRepository<IColor>, ColorRepository>();

builder.Services.AddScoped<IService<CustomerDTO>, CustomerService>();
builder.Services.AddScoped<IService<CarDTO>, CarService>();
builder.Services.AddScoped<IService<VisitDTO>, BLL.Services.VisitService>();
builder.Services.AddScoped<IService<VisitStatusDTO>, BLL.Services.VisitStatusService>();
builder.Services.AddScoped<IService<PaymentStatusDTO>, BLL.Services.PaymentStatusService>();
builder.Services.AddScoped<IService<EmployeeDTO>, BLL.Services.EmployeeService>();
builder.Services.AddScoped<IService<CarModelDTO>, BLL.Services.CarModelService>();
builder.Services.AddScoped<IService<ColorDTO>, BLL.Services.ColorService>();

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
