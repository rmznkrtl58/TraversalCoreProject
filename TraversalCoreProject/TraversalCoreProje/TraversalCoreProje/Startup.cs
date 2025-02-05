using BusinessLogicLayer.Container;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.Models;

namespace TraversalCoreProje
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
        {   //------------------------------------------------------
            //CQRS ÝÇÝN kullandýðým handler constructorumu burada çaðýrdým
            //aksi taktirde controller tarafýnda çalýþtaramazsýn
            services.AddScoped<GetAllDestinationQueryHandler>();
            services.AddScoped<GetDestinationByIdQueryHandler>();
            services.AddScoped<CreateDestinationCommandHandler>();
            services.AddScoped<DeleteDestinationCommandHandler>();
            services.AddScoped<UpdateDestinationCommandHandler>();
            //------------------------------------------------------
            //------------------------------------------------------
              //MediadR kullanýmý
              //artýk yukardaki gibi addscoped diyerek çokca þey tanýmlamamýza gerek yok
            services.AddMediatR(typeof(Startup));
            //------------------------------------------------------
            //LOGLAMA ÝÞLEMÝ
            //UI->Manage nuget packages serilog.extensions.logging.file
            services.AddLogging(x =>
                {
                    x.ClearProviders();
                    x.SetMinimumLevel(LogLevel.Debug);//log iþleminin nereden baþlayacaðýný gösterir
                    x.AddDebug();
                });
            //------------------------------------------------------
            //------------------------------------------------------
            //Identity iþlemleri için
            //þifre yenileme unuttum iþlemleri
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>()//Þifreleme þartlarýný türkçelendirdiðimiz yer
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider)//þifre yenileme,unuttum
                .AddEntityFrameworkStores<Context>();
            //------------------------------------------------------
              //APÝlerde isteklere karþýlýk verme diyelim
              services.AddHttpClient();
            //------------------------------------------------------    
            //newlemelerden kurtarmam için servicelere baðlý constroctor metod oluþturduydum onu
            //kullanamabilmem için yapacaðým yapýlandýrmalar
            services.ContainerDependencies();
            //static ve parametremde this kullanmamdan kaynaklý direk services parametreme
            //baðlý olarak metodumu çaðýrabildim.
            //------------------------------------------------------

            //------------------------------------------------------
            //AUTOMAPPER KULLANIMI
            services.AddAutoMapper(typeof(Startup));
            //addtransienti business katmanýndaki contanier içerisindeki 
            //extension içerisine tanýmladým
            services.CustomerValidator();
            //validationlarýn çalýþmasý için gerekli üstünü çizdiðine bakma
            services.AddControllersWithViews().AddFluentValidation();
            //------------------------------------------------------ 

            //services.AddControllersWithViews().AddFluentValidation();
            services.AddControllersWithViews();


            //------------------------------------------------------
            //PROJE SEVÝYESÝNDE AUTHORÝZE
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            //------------------------------------------------------
              //Toplu dil desteði için yapmýþ olduðum yapýlandýrmalar
            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
                //lokazisyon iþlemim için Resources klasöründeki dil dosyalarýný
                //kontrol edecek
            });
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
               //daha sonra aþaðýdaki configure metodunda yapýlandýrman gerekiyor
            //------------------------------------------------------
            //MvcKontrollerini kullanmam için         
            services.AddMvc();
            //------------------------------------------------------
               //Authentice olmayan kullanýcýyý yönlendireceði yerdir.
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SignIn/";
            });
            //-------------------------------------------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //loglama için ILoggerFactory
        //interfacime baðlý parametre
        //kullandým
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            //----------------------------------------------
            //Loglama dosya ile 
            var path = Directory.GetCurrentDirectory();//aktif yolu al
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");
            //----------------------------------------------



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //-----------------------------------
            //hata sayfalarýmda gösterilecek olan sayfanýn yapýlandýrmasýný yapýyorum
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/", "?code={0}");
            //-----------------------------------

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //--------------------------------
            //Authentice iþlemlerini kullanmam için gerekli
            //app.UseAuthorization()->bunun üstünde olmalý aþaðýsýna yazma
            app.UseAuthentication();
            //--------------------------------

            app.UseRouting();

            app.UseAuthorization();

            //------------------------------------
              //toplu dil desteði için yapýlandýrma
            var supportedLanguages = new[] {"tr","en","fr","de"};    //uygulama ayaða kaltýðýnda default olarak tr gelsin
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedLanguages[0]).AddSupportedCultures(supportedLanguages).AddSupportedUICultures(supportedLanguages);
            app.UseRequestLocalization(localizationOptions);
            //------------------------------------
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });

            //---------------------------------------
            //Arealarý kullanmam için gerekli 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            //---------------------------------------
        }
    }
}
