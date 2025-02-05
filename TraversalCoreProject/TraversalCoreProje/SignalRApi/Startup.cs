using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SignalRApi.Dal;
using SignalRApi.Hubs;
using SignalRApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi
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
        {   //----------------------------------------------------------------------------------
            //Apilerimi t�ketecek consume edecek olan katman i�in (proje i�in) yap�land�rma
            //yaz�yorum
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials();
            }));
            //----------------------------------------------------------------------------------
               //Visitor Servici �al��t�rmam i�in gerekli olan yap�land�rma
            services.AddScoped<VisitorService>();
            services.AddSignalR();
            //----------------------------------------------------------------------------------
               //PostSql Yap�land�rmas�
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<Context>(opt => 
                opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            //----------------------------------------------------------------------------------
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SignalRApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SignalRApi v1"));
            }

            app.UseRouting();
            //----------------------------------------------------------------
               //yukarda configure services i�erisinde tan�mlad���m cors'u burada
               //kullanmak i�in �a��r�yorum
            app.UseCors("CorsPolicy");
            //----------------------------------------------------------------

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //SignalR'�n consume edece�i s�n�f� burada MapHub �eklinde tan�mlad�m.
                endpoints.MapHub<VisitorHub>("/VisitorHub");
            });
        }
    }
}
