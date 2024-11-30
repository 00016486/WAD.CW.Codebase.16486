using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WAD.CW.Codebase._16486.Data;
using WAD.CW.Codebase._16486.Interfaces;
using WAD.CW.Codebase._16486.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReceptionSystemDatabase")));

builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<IReceptionistRepository, ReceptionistRepository>();



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
