using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomar.Data;
using Pomar.Interfaces.Repositories;
using Pomar.Interfaces.Services;
using Pomar.Repository;
using Pomar.Service;

namespace Pomar
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                builder =>
                                {
                                    builder.WithOrigins("https://localhost:5001",
                                                        "http://localhost:3001",
                                                        "http://localhost:3000")
                                            .AllowAnyHeader();
                                });
            });

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //services.AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<DataContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DataContext, DataContext>();

            services.AddScoped<IEspecieService, EspecieService>();
            services.AddScoped<IArvoreService, ArvoreService>();
            services.AddScoped<IGrupoArvoreService, GrupoArvoreService>();
            services.AddScoped<IColheitaService, ColheitaService>();
            services.AddScoped<IColheitaArvoreService, ColheitaArvoreService>();

            services.AddScoped<IEspecieRepository, EspecieRepository>();
            services.AddScoped<IArvoreRepository, ArvoreRepository>();
            services.AddScoped<IGrupoArvoreRepository, GrupoArvoreRepository>();
            services.AddScoped<IColheitaRepository, ColheitaRepository>();
            services.AddScoped<IColheitaArvoreRepository, ColheitaArvoreRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
