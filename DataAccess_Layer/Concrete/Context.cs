using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess_Layer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>

    {
        //Bağlantı adresimizi (Conection St.) burada tanımlıyoruz
        //protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder) //
        //{
        //    optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS; database=BlogDb;Trusted_Connection=True;TrustServerCertificate=True");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //
        {
            optionsBuilder.UseSqlServer("Server = tcp:kodmatik.database.windows.net,1433; Initial Catalog = BlogDb; Persist Security Info = False; User ID =kodmatiksqladmin; Password =Kodmatik123; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            //optionsBuilder.UseSqlServer("server=kodmatik.database.windows.net; database=BlogDb;password:Kodmatik123; Trusted_Connection=True;TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("Server = tcp:kodmatik.database.windows.net,1433; Initial Catalog = BlogDb; Persist Security Info = False; UserID =kodmatiksqladmin; Password =Kodmatik123; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);

        }
        //Veritabanına yansıtma işlemlerimiz
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Admin> Admins { get; set; }


    }
}
