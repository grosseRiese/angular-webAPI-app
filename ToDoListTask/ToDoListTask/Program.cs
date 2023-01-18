using Microsoft.EntityFrameworkCore;
using ToDoListTask.Models;
using ToDoListTask.Data;
using ToDoListTask.Interfaces;
using ToDoListTask.Repositories;
using ToDoListTask.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ToDoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
//Add Repository
builder.Services.AddScoped<IToDoRepository<ToDo>,ToDoRepository>();

////Add Cors
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowOrigin", builder =>
//    {
//        builder.WithOrigins("http://localhost:4200/")
//               .AllowAnyHeader()
//               .AllowAnyMethod()
//               .AllowCredentials();
//    });
//});
builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


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
//app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().WithOrigins());
app.UseCors("default");
app.UseAuthorization();

app.MapControllers();


app.Run();
