using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayerApi.Repository.Context;
using NLayerApi.Repository.UnitOfWorks;
using NLayerApi.Service.Mapping;
using NLayerApi.Service.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});




builder.Services.Scan(scan => scan
    .FromAssemblyOf<UnitOfWork>()
    .AddClasses()
    .AsImplementedInterfaces()
    .AsSelf()
    .WithTransientLifetime());

builder.Services.Scan(scan => scan
    .FromAssembliesOf(typeof(Service<>)) 
    .AddClasses()
    .AsImplementedInterfaces()
    .AsSelf()
    .WithTransientLifetime());



builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddMvcCore();

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
