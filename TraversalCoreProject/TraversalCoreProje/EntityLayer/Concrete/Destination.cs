using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }//Tur Aktif mi pasif mi?
        public string CoverImage { get; set; }//Kapak Foto
        public string Details1 { get; set; }//Kapak Foto
        public string Details2 { get; set; }//Kapak Foto
        public string Image1 { get; set; }//Kapak Foto
        public string Image2 { get; set; }//Kapak Foto
        //bir rotanın bloğuna bir den fazla yorum yapılabilir
        public List<Comment> Comments { get; set; }
        //Bir rotaya birden fazla rezervasyon yapılabilir
        public List<TblReservation> TblReservations { get; set; }
        //bir rotanın bloğunu sadece onun rehberi yazabilir
        public int? GuideId { get; set; }//? işareti boş geçilebir demek
        public Guide Guide { get; set; }

    }
}
