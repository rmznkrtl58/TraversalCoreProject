namespace TraversalCoreProje.Areas.Admin.Models
{
    public class BookingExchangeViewModel
    {  //bazı apilerin verileri alt alta sınıflandırılmış çekilir 
        //oyuzden direk olarak propların aynısını alıp burada tanımlamak
        //sorun yaşatabilir example response tarafında aşağıda verilerin
        //listesi kodlar halinde verilir copy seçeneğine tıklayıp
        //vs'code tarafında view classıma edit-paste special-json as class
        //tıklayıp şuanki üzerinde çalıştığım view'ime yapıştırıyorum
        
        public string base_currency_date { get; set; }
        public Exchange_Rates[] exchange_rates { get; set; }
        public string base_currency { get; set; }

        public class Exchange_Rates //Array formatında çekiyor
        {
            public string currency { get; set; }
            public string exchange_rate_buy { get; set; }
        }

    }
}
