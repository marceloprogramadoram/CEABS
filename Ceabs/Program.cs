using CEABS.Domain.Repository;
using CEABS.Infrastructure.Contexts;
using CEABS.Infrastructure.UnitOfWork;
using CEABS.Service;
using CEABS.Service.Interface;
using CEABS.Service.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionsString = builder.Configuration.GetConnectionString("CeabsConnections");
// Add services to the container.

builder.Services.AddDbContext<CeabsContext>(option => option.UseNpgsql(connectionsString));

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(opt => opt.AllowAnyHeader().AllowAnyOrigin().WithMethods("GET", "POST", "DELETE", "UPDATE"));
});

builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddScoped<IModelCarService, ModelCarService>();

builder.Services.AddScoped<IProducerService, ProducerService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

#region Profile
var profile = new MappingProfile();

builder.Services.AddAutoMapper(s => s.AddProfile(profile));

#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Configure the HTTP request pipeline.
if (true/*app.Environment.IsDevelopment()*/)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
