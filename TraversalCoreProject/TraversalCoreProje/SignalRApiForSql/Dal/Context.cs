using Microsoft.EntityFrameworkCore;

namespace SignalRApiForSql.Dal
{
    public class Context:DbContext
    {
        //appsettings.json içerisinde tanımlamış olduğum postgreSql veri tabanı
        //bağlantı adresimi buradada tanımlamış oldum diğer adımda startup içerisinde
        //yapılandır
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Visitor> visitors { get; set; }
    }
}
