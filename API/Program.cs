using DbFirst.Models;
//using CodeFirst1.Models;
using Abstraction.ModelInterfaces;
using Abstraction;
using Microsoft.EntityFrameworkCore;
using DbFirst.Repositories;
//using CodeFirst1.Repositories;
using Abstraction.DTOs;
using BLL.Services;
using BLL.Mappers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.TokenProviders;
using Abstraction.ServiceInterfaces;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.AllowAnyOrigin()  // Allows all origins
            .AllowAnyMethod()      // Allows all HTTP methods (GET, POST, PUT, DELETE, etc.)
            .AllowAnyHeader();     // Allows all headers
    });
});



builder.Services.AddAuthorization();
//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer("Bearer", options =>
//    {
//        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = jwtSettings["Issuer"],
//            ValidAudience = jwtSettings["Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
//        };
//    });


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
builder.Services.AddScoped<IRepository<IUser>, UserRepository>();

builder.Services.AddSingleton<TokenProvider>();

builder.Services.AddScoped<IService<CustomerDTO>, CustomerService>();
builder.Services.AddScoped<IService<CarDTO>, CarService>();
builder.Services.AddScoped<IService<VisitDTO>, BLL.Services.VisitService>();
builder.Services.AddScoped<IService<VisitStatusDTO>, BLL.Services.VisitStatusService>();
builder.Services.AddScoped<IService<PaymentStatusDTO>, BLL.Services.PaymentStatusService>();
builder.Services.AddScoped<IService<EmployeeDTO>, BLL.Services.EmployeeService>();
builder.Services.AddScoped<IService<CarModelDTO>, BLL.Services.CarModelService>();
builder.Services.AddScoped<IService<ColorDTO>, BLL.Services.ColorService>();
builder.Services.AddScoped<IUserService, BLL.Services.LoginService>();

builder.Services.AddAutoMapper(typeof(MapperProfile));
//builder.Services.AddAutoMapper(typeof(MapperProfileCodeFirst));


builder.Services.AddSwaggerGen(c =>
{
    // Add security definition for Bearer token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below."
    });

    // Add security requirement
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});



builder.Services.AddDbContext<CarServiceKpzContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// In the Configure method
app.UseCors("AllowAnyOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication(); // Add before UseAuthorization
//app.UseAuthorization();

app.MapControllers();

app.Run();
