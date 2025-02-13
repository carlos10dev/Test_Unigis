using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Test_Unigis.AutoMappers;
using Test_Unigis.DTOs;
using Test_Unigis.Models;
using Test_Unigis.Repository;
using Test_Unigis.Services;
using Test_Unigis.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyedScoped<ICommonService<ProductoDto, ProductoInsertDto, ProductoUpdateDto>, ProductoService>("productoService");

//Repository
builder.Services.AddScoped<IRepository<Producto>, ProductoRepository>();

//EntityFramework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UnigisConnection"));
});

//Validators
builder.Services.AddScoped<IValidator<ProductoInsertDto>, ProductoInsertValidator>();
builder.Services.AddScoped<IValidator<ProductoUpdateDto>, ProductoUpdateValidator>();

//Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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