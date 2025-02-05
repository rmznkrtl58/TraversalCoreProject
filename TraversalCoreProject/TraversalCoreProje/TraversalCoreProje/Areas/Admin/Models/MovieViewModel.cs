namespace TraversalCoreProje.Areas.Admin.Models
{
    public class MovieViewModel
    {
        //rapid api sitesindeki top 100 imdb filimini 
        //çekecez fakat ordaki proplarla aynı olmalı
        //ordaki proplara example response tarafından 
        //ulaşabilirsin.
        public int rank { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public int year { get; set; }
    }
}
