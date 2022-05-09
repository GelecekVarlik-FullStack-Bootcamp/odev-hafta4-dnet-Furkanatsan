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
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());//resultStatusu js tarafýnda da kullanmak için 
            
            });//sen bir Mvc sin KENDÝNE GEL!!!
            services.AddAuthentication  (  x => {
                //kimlik doðrulamayý JWT ÝLE SAÐLA.
                
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer ( opt => {
                opt.RequireHttpsMetadata = false;//https için gerekli ayarlarý saðlar
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
                         context.Token = context.Request.Cookies["EmployeeToken"];//token cookie ye ,EmployeeToken adýnda kaydedilir. 
                         return System.Threading.Tasks.Task.CompletedTask;
                     }
                };


                });
            services.AddAutoMapper(typeof(TaskProfile),typeof(EmployeeProfile));//typeof(TaskProfile)==derlenme esnasýnda automapperin burdaki sýnýflarý taranmasýný saðlar.
            services.LoadMyServices();//servisler bunun içinde.

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();//sitemizde olmayan bir view a gittiðimizde 404 hatasý vericek.
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//wwwroot içerisi
           
            app.UseRouting();
            app.UseAuthentication();//kimliði doðrula.
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
