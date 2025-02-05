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
            //CQRS ���N kulland���m handler constructorumu burada �a��rd�m
            //aksi taktirde controller taraf�nda �al��taramazs�n
            services.AddScoped<GetAllDestinationQueryHandler>();
            services.AddScoped<GetDestinationByIdQueryHandler>();
            services.AddScoped<CreateDestinationCommandHandler>();
            services.AddScoped<DeleteDestinationCommandHandler>();
            services.AddScoped<UpdateDestinationCommandHandler>();
            //------------------------------------------------------
            //------------------------------------------------------
              //MediadR kullan�m�
              //art�k yukardaki gibi addscoped diyerek �okca �ey tan�mlamam�za gerek yok
            services.AddMediatR(typeof(Startup));
            //------------------------------------------------------
            //LOGLAMA ��LEM�
            //UI->Manage nuget packages serilog.extensions.logging.file
            services.AddLogging(x =>
                {
                    x.ClearProviders();
                    x.SetMinimumLevel(LogLevel.Debug);//log i�leminin nereden ba�layaca��n� g�sterir
                    x.AddDebug();
                });
            //------------------------------------------------------
            //------------------------------------------------------
            //Identity i�lemleri i�in
            //�ifre yenileme unuttum i�lemleri
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>()//�ifreleme �artlar�n� t�rk�elendirdi�imiz yer
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider)//�ifre yenileme,unuttum
                .AddEntityFrameworkStores<Context>();
            //------------------------------------------------------
              //AP�lerde isteklere kar��l�k verme diyelim
              services.AddHttpClient();
            //------------------------------------------------------    
            //newlemelerden kurtarmam i�in servicelere ba�l� constroctor metod olu�turduydum onu
            //kullanamabilmem i�in yapaca��m yap�land�rmalar
            services.ContainerDependencies();
            //static ve parametremde this kullanmamdan kaynakl� direk services parametreme
            //ba�l� olarak metodumu �a��rabildim.
            //------------------------------------------------------

            //------------------------------------------------------
            //AUTOMAPPER KULLANIMI
            services.AddAutoMapper(typeof(Startup));
            //addtransienti business katman�ndaki contanier i�erisindeki 
            //extension i�erisine tan�mlad�m
            services.CustomerValidator();
            //validationlar�n �al��mas� i�in gerekli �st�n� �izdi�ine bakma
            services.AddControllersWithViews().AddFluentValidation();
            //------------------------------------------------------ 

            //services.AddControllersWithViews().AddFluentValidation();
            services.AddControllersWithViews();


            //------------------------------------------------------
            //PROJE SEV�YES�NDE AUTHOR�ZE
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            //------------------------------------------------------
              //Toplu dil deste�i i�in yapm�� oldu�um yap�land�rmalar
            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
                //lokazisyon i�lemim i�in Resources klas�r�ndeki dil dosyalar�n�
                //kontrol edecek
            });
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
               //daha sonra a�a��daki configure metodunda yap�land�rman gerekiyor
            //------------------------------------------------------
            //MvcKontrollerini kullanmam i�in         
            services.AddMvc();
            //------------------------------------------------------
               //Authentice olmayan kullan�c�y� y�nlendirece�i yerdir.
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SignIn/";
            });
            //-------------------------------------------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //loglama i�in ILoggerFactory
        //interfacime ba�l� parametre
        //kulland�m
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
            //hata sayfalar�mda g�sterilecek olan sayfan�n yap�land�rmas�n� yap�yorum
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/", "?code={0}");
            //-----------------------------------

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //--------------------------------
            //Authentice i�lemlerini kullanmam i�in gerekli
            //app.UseAuthorization()->bunun �st�nde olmal� a�a��s�na yazma
            app.UseAuthentication();
            //--------------------------------

            app.UseRouting();

            app.UseAuthorization();

            //------------------------------------
              //toplu dil deste�i i�in yap�land�rma
            var supportedLanguages = new[] {"tr","en","fr","de"};    //uygulama aya�a kalt���nda default olarak tr gelsin
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
            //Arealar� kullanmam i�in gerekli 
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
