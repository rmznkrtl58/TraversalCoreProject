using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{                //Identity için kullandığım
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        //1)Override yazıp boşluk tuşuna basınca direk çıkıyor
        //2)Kod içinde bir değerin protected olarak tanımlanması; o değere, bulunduğu
        //class  ve ondan türetilen diğer sınıflar içinden erişilebilir olduğunu göstermektedir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VM4NR9R\\SQLEXPRESS;database=TraversalCoreProje;integrated security=true");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<About2> About2s { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Feature2> Feature2s { get; set; }
        public DbSet<Guide> Guides { get; set; }
        //Guid diye bir sınıf oluşturmadım çünkü bir komuttur dikkat et
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<TblReservation> TblReservations { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
