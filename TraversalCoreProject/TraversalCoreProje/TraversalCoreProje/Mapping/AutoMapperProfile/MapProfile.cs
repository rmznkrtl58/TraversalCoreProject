using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile//using automapper
    {   //gerekli içerikleri yaptıktan sonra startupta yapılandır
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();
            //diğer 2'li kullanım
            //CreateMap<AnnouncementAddDTOs, Announcement>();
            //CreateMap<Announcement, AnnouncementAddDTOs > ();
            CreateMap<AppUserLoginDTOs, AppUser>().ReverseMap();

            CreateMap<AppUserRegisterDTOs, AppUser>().ReverseMap();
            
            CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();
            
            CreateMap<AnnouncementUpdateDTO, Announcement>().ReverseMap();
            
            CreateMap<SendMessageDTO, ContactUs>().ReverseMap();
        }
    }
}
