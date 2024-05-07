using Condo.Context;
using Condo.Context.Interfaces;
using Condo.Repository;
using Condo.Repository.Interfaces;
using Condo.UseCases;
using Condo.UseCases.Interfaces;
using Condo.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<ICondominiumRepository, CondominiumRepository>();
builder.Services.AddScoped<ICondominiumUseCase, CondominiumUseCase>();
builder.Services.AddScoped<IUnityRepository, UnityRepository>();
builder.Services.AddScoped<IUnityUseCase, UnityUseCase>();
builder.Services.AddAutoMapper(typeof(MapperProfile));

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
