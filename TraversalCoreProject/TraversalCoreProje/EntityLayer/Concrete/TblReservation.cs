using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TblReservation
    {
        [Key]
        public int ReservationId { get; set; }
        public string PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public bool DeleteStatus { get; set; }
        //AppUser İLE İLİŞKİ kurucam çünkü rezervasyonu yapacak kişi admin olacak
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        ////Destination ile ilişki
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
