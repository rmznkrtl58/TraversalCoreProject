using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Abstract.AbstractUnitOfWork;
using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.Concrete.ConcreteUnitOfWork;
using BusinessLogicLayer.ValidationRules;
using BusinessLogicLayer.ValidationRules.AnnouncementValidationRules;
using BusinessLogicLayer.ValidationRules.Contact;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Container
{   //controllerda newleme işlemlerini engellemek için servicelerde constructor metod oluşturup
    //startupda services.addscoped<>diyip ilgili entitiylerimin interfacelerimi ve sınıflarımı çağırıyordum
    //startupta bu işlem tekrara bineceğinden dolayı bu işlemleri bu sınıfımda yapma gereği duydum
    public static class Extensions//extensions olması sıkıntılı bir durum başka bir isim daha iyi olur
    {                                 //startuptaki configureservices
                                      //metodundaki parametrelerimi aynen buraya
                                      //yazdım
        //static kullanma sebebim startup tarafında direk metoda erişebilmem için
                                              //this kullanma sebebimde bu sınıftaki
                                              //değeri kullanmam
        public static void ContainerDependencies(this IServiceCollection services)
        {
            //newlemelerden kurtarmam için servicelere bağlı constroctor metod oluşturduydum onu
            //kullanamabilmem için yapacağım yapılandırmalar
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IDestinationDal, EfDestinationDal>();
            services.AddScoped<IDestinationService, DestinationManager>();

            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IReservationDal,EfReservationDal>();
            services.AddScoped<IReservationService,ReservationManager>();

            services.AddScoped<IGuideDal,EfGuideDal>();
            services.AddScoped<IGuideService,GuideManager>();

            services.AddScoped<IExcelService,ExcelManager>();

            services.AddScoped<IPdfService,PdfManager>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();

            services.AddScoped<IAccountDal, EfAccountDal>();
            services.AddScoped<IAccountService, AccountManager>();

            services.AddScoped<IUowDal, UowDal>();
        }
        public static void CustomerValidator(this IServiceCollection services)
        {   //AUTO MAPPER KULLANIMI STARTUPTAN BURAYA TAŞIDIK
            //bu olmassa validasyon yapmaz
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementAddValidator>();
            services.AddTransient<IValidator<AnnouncementUpdateDTO>, AnnouncementUpdateValidator>();
            services.AddTransient<IValidator<SendMessageDTO>, SendContactUsValidator>();
        }
    }
}
