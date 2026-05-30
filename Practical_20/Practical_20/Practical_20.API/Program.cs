using Microsoft.EntityFrameworkCore;
using Practical_20.API.Middleware;
using Practical_20.Application.Interfaces;
using Practical_20.Application.Services;
using Practical_20.Infrastructure.Data;
using Practical_20.Infrastructure.Repositories;
using Practical_20.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
