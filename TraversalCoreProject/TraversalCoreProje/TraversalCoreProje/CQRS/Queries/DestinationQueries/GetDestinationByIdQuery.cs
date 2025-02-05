namespace TraversalCoreProje.CQRS.Queries.DestinationQueries
{
    public class GetDestinationByIdQuery
    {   //controller tarafında propuma ulaşabilmem constructor tanımladım
        public GetDestinationByIdQuery(int id)
        {
            this.id = id;
        }

        //bizim Id'ye göre listeleme işlemimizi yapmak için Id parametremize 
        //ihtiyacımız olcak oyuzden Queries sınıfında parametrelerimiz tutuluyordu
        //parametlerimizi burda tutuyoruz
        public int id { get; set; }
    }
}
