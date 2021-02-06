using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
                                    builder.AllowAnyOrigin()
                                           .AllowAnyMethod()
                                           .AllowAnyHeader();
                                });
            });



            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //services.AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<DataContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DataContext, DataContext>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEspecieService, EspecieService>();
            services.AddScoped<IArvoreService, ArvoreService>();
            services.AddScoped<IGrupoArvoreService, GrupoArvoreService>();
            services.AddScoped<IColheitaService, ColheitaService>();
            services.AddScoped<IColheitaArvoreService, ColheitaArvoreService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEspecieRepository, EspecieRepository>();
            services.AddScoped<IArvoreRepository, ArvoreRepository>();
            services.AddScoped<IGrupoArvoreRepository, GrupoArvoreRepository>();
            services.AddScoped<IColheitaRepository, ColheitaRepository>();
            services.AddScoped<IColheitaArvoreRepository, ColheitaArvoreRepository>();

            var key = System.Text.Encoding.ASCII.GetBytes(Settings.Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
