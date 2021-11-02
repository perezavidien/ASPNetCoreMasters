using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using Repositories;
using ASPNetCoreMastersTodoList.Api.Helpers;
using ASPNetCoreMastersTodoList.Api.Filters;
using ASPNetCoreMastersTodoList.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ASPNetCoreMastersTodoList.Api.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace ASPNetCoreMastersTodoList.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the containermap.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DotNetCoreMastersDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DotNetCoreMastersDbContext>()
                .AddDefaultTokenProviders();

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["jwt:secret"]));
            services.Configure<JwtOptions>(options =>
            {
                options.SecurityKey = securityKey;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
                options.DefaultScheme = "Bearer";
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = securityKey
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanEditItems", policy => policy.Requirements.Add(new IsCreatorRequirement()));
            });

            services.AddScoped<IAuthorizationHandler, IsCreator>();

            services.AddControllers(options =>
            {
                options.Filters.Add(new PerformanceFilter());
            });
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddSingleton<DotNetCoreMastersDbContext>();
            services.Configure<Authentication>(Configuration.GetSection("Authentication"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
