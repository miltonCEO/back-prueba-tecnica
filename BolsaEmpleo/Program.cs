using BolsaEmpleo.DTOs;
using BolsaEmpleo.Models;
using BolsaEmpleo.Repository;
using BolsaEmpleo.Services;
using BolsaEmpleo.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyedScoped<ICommonServices<UsersDto, UserInsertDto, UserUpdateDto>, UserServices>("userService");
builder.Services.AddKeyedScoped<IVacancieServices<VacanciesDto>, VacancieServices>("vacancieService");
builder.Services.AddKeyedScoped<IVacantApplicationServices<VacantApplicationDto, VacantApplicationInsertDto>, VacantApplicationService>("vacantApplicationService");

//Repository
builder.Services.AddScoped<IRepository<User>, UserRepository > ();
builder.Services.AddScoped<IVacancieRepository<Vacancies>, VacancieRepository>();
builder.Services.AddScoped<IVacantApplicationRepository<VacantApplication>, VacantApplicationRepository>();


// Connection
builder.Services.AddDbContext<BolsaEmpleoDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("BolsaEmpleoDBConection"));
});

//Validator
builder.Services.AddScoped<IValidator<UserInsertDto>, UserInsertValidator>();

var MyAllowCors = "_myAllow";
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: MyAllowCors, policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

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

app.UseCors(MyAllowCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
