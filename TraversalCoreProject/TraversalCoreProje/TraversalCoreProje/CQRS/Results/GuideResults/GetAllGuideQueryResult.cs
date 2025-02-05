namespace TraversalCoreProje.CQRS.Results.GuideResults
{
    public class GetAllGuideQueryResult
    {   //MediatR kullandığım alandır guide kısmı 
        //bu classımın olayı listeleme yapmak istediğim proplarımı tanımladım
        //Result->listeleme yapmak istediğim sınıftır.
        public int GuideId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
