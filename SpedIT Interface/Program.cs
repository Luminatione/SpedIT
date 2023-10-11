using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpedIT_Data.Repositories;
using SpedIT_Domain;
using SpedIT_Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql("Server=localhost;Username=postgres;Database=postgres"));
builder.Services.AddMvcCore().AddRazorViewEngine();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IComplainRepository, ComplainRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
