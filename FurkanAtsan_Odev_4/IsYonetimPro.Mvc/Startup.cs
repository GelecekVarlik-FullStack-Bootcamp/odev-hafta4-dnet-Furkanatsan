using IsYonetimPro.Services.AutoMapper.Profiles;
using IsYonetimPro.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IsYonetimPro.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IsYonetimPro.Mvc
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
            services.AddDbContext<IsYonetimSistemiDBContext>(ob => ob.UseSqlServer(Configuration.GetConnectionString("SqlServerr")));
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt=> 
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());//resultStatusu js taraf�nda da kullanmak i�in 
            
            });//sen bir Mvc sin KEND�NE GEL!!!
            services.AddAuthentication  (  x => {
                //kimlik do�rulamay� JWT �LE SA�LA.
                
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer ( opt => {
                opt.RequireHttpsMetadata = false;//https i�in gerekli ayarlar� sa�lar
                opt.SaveToken = true;//tokeni saklar kaydeder.
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("bu benim secret key alanim alanim alanim")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                opt.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                     {
                         context.Token = context.Request.Cookies["EmployeeToken"];//token cookie ye ,EmployeeToken ad�nda kaydedilir. 
                         return System.Threading.Tasks.Task.CompletedTask;
                     }
                };


                });
            services.AddAutoMapper(typeof(TaskProfile),typeof(EmployeeProfile));//typeof(TaskProfile)==derlenme esnas�nda automapperin burdaki s�n�flar� taranmas�n� sa�lar.
            services.LoadMyServices();//servisler bunun i�inde.

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();//sitemizde olmayan bir view a gitti�imizde 404 hatas� vericek.
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//wwwroot i�erisi
           
            app.UseRouting();
            app.UseAuthentication();//kimli�i do�rula.
            app.UseAuthorization();//yetkilendir.

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapAreaControllerRoute(
                //    name: "Admin",
                //    areaName: "Admin",
                //    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                //    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
