using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementListDTO
    {
        //listeleyeceğim verilerden istediğim alanların proplerini tanımladım.
        //MUTLAKA VERİ TABANINDAKİ SÜTUN İSMİYLE AYNI OLMALI (PROPLAR)
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
