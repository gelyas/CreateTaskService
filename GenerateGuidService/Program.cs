//using GenerateGuidService.Data;
using GenerateGuidService.Models;
using GenerateGuidService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<GenerateGuidService.Models.PlanningContext>(options => options.UseSqlServer("Data Source=DESKTOP-C1MT787;Initial Catalog=Planning;Persist Security Info=True;User ID=sa;Password=sql;Encrypt=False"));
builder.Services.AddDbContext<PlanningContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<ITaskService, TaskService>();

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
