using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SignalRApiForSql.Dal;
using SignalRApiForSql.Hubs;
using SignalRApiForSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApiForSql
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
            //----------------------------------------------------------------------------------
            //Apilerimi tüketecek consume edecek olan katman için (proje için) yapýlandýrma
            //yazýyorum
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials();
            }));
            //----------------------------------------------------------------------------------
            //Visitor Servici çalýþtýrmam için gerekli olan yapýlandýrma
            services.AddScoped<VisitorService>();
            services.AddSignalR();
            //----------------------------------------------------------------------------------
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SignalRApiForSql", Version = "v1" });
            });

            //----------------------------------------------------------------
                //appsettings.json içerisine sql baðlantý adresimi tanýmladýktan sonra
                //burada yapýlandýrma yapýyorum
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration["DefaultConnection"]);
            });
            //----------------------------------------------------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SignalRApiForSql v1"));
            }

            app.UseRouting();
            //----------------------------------------------------------------
            //yukarda configure services içerisinde tanýmladýðým cors'u burada
            //kullanmak için çaðýrýyorum
            app.UseCors("CorsPolicy");
            //----------------------------------------------------------------
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //SignalR'ýn consume edeceði sýnýfý burada MapHub þeklinde tanýmladým.
                endpoints.MapHub<VisitorHub>("/VisitorHub");
            });
        }
    }
}
