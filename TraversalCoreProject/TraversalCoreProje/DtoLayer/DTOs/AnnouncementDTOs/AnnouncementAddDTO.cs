using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementAddDTO
    {
        //Entitiy layerimdaki duyurular tablomdaki validasyona sokmak istediğim
        //sütunları alıp buraya yapıştırıyorum busines tarafında doğrulama
        //yapacağım
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
