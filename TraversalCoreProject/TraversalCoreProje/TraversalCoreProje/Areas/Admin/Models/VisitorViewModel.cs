using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Areas.Admin.Models
{
    public class VisitorViewModel
    {   //Apide oluşturulan Visitor sınıfımdaki
        //proplarının aynısı olması lazım
        public int VisitorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mail { get; set; }
    }
}
