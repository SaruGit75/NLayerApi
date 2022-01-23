using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayerApi.Core.Repositories;
using NLayerApi.Core.Services;
using NLayerApi.Core.UnitOfWorks;
using NLayerApi.Repository.Context;
using NLayerApi.Repository.Repositories;
using NLayerApi.Repository.UnitOfWorks;
using NLayerApi.Service.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
        options =>
        {
            options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);
        });
});

builder.Services.AddAutoMapper(typeof(MapProfile));



builder.Services.Scan(scan => scan
    .FromAssemblyOf<UnitOfWork>()
    .AddClasses()
    .AsImplementedInterfaces()
    .AsSelf()
    .WithTransientLifetime());


//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IService<>), typeof());




//builder.Services.Scan(scan => scan
//    .FromAssembliesOf()
//    .AddClasses()
//    .AsImplementedInterfaces()
//    .AsSelf()
//    .WithTransientLifetime());

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
