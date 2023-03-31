using CateringSystem.Data;
using CateringSystem.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using CateringSystem.ServicesInterfaces;
using Microsoft.AspNetCore.Identity;
using CateringSystem.Data.Entities;
using FluentValidation;
using CateringSystem.Data.Models;
using CateringSystem.Data.Models.Validators;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CateringSystem.Middleware;
using Newtonsoft.Json.Serialization;

namespace CateringSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors(c =>
            {
               c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllersWithViews().AddNewtonsoftJson(options => 
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
             
            //pobranie informacji z appsetting.json
            var authenticationSettings = new AuthenticationSettings();
            Configuration.GetSection("Authentication").Bind(authenticationSettings); //po³¹czenie jednego z drugiego,
                                                                                     //aby móc pobieraæ dane z pliku
                                                                                     //json za pomoc¹ propertiesów z klasy
            services.AddSingleton(authenticationSettings);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters //sprawdzenie czy token jest zgodny z tym co wie server
                {
                    ValidIssuer = authenticationSettings.JwtIssuer, //wydawca danego tokenu
                    ValidAudience = authenticationSettings.JwtIssuer, //kto mo¿e u¿ywaæ tokenu
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)), //klucz prywatny wygenerowany na podstawie jwtKey z appsetting json
                };
            });

            var deepLAuth = new DeepLAuthorizationModel();
            Configuration.GetSection("DeepLSettings").Bind(deepLAuth);
            services.AddSingleton(deepLAuth);

            services.AddControllers().AddFluentValidation();
            services.AddScoped<CateringSeeder>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<ITranslationService, TranslationService>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            services.AddDbContext<CateringDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("myConn"));
            });
            services.AddHttpContextAccessor();
         
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CateringSystem", Version = "v1" });
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CateringSeeder seeder)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            seeder.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CateringSystem v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
