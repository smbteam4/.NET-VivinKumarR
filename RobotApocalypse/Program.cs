using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RobotApocalypse_BAL.Interface;
using RobotApocalypse_BAL.Service;
using RobotApocalypse_DAL;
using RobotApocalypse_DAL.Interface;
using RobotApocalypse_DAL.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Robot Apocalypse",
        Version = "v1"
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddTransient<ISurvivorRepository, SurvivorRepository>();
builder.Services.AddTransient<IRobotRepository, RobotRepository>();
builder.Services.AddTransient<ISurvivorService, SurvivorService>();
builder.Services.AddTransient<IRobotService, RobotService>();

//builder.Services.AddAutomapper(Assembly.GetExecutingAssembly());
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
