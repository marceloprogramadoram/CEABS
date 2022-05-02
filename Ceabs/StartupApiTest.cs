using CEABS.Domain.Repository;
using CEABS.Infrastructure.Contexts;
using CEABS.Infrastructure.UnitOfWork;
using CEABS.Service;
using CEABS.Service.Interface;
using CEABS.Service.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ceabs
{
    public class StartupApiTest
    {
        public StartupApiTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfiurationService(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(opt => opt.AllowAnyHeader().AllowAnyOrigin().WithMethods("GET", "POST", "DELETE", "UPDATE"));
            });

            services.AddControllers();

            #region Profile
            var profile = new MappingProfile();

            services.AddAutoMapper(s => s.AddProfile(profile));

            #endregion

            services.AddDbContext<CeabsContext>(options => options.UseInMemoryDatabase("MemoryDB"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IModelCarService, ModelCarService>();
            services.AddTransient<IProducerService, ProducerService>();
            services.AddTransient<IVehicleService, VehicleService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
