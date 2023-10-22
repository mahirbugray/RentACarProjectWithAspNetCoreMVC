using BAU_Project_RentACarPortal.App.DataAccess.Identity.Model;
using BAU_Project_RentACarPortal.App.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.DataAccess.Contexts
{
    public class RentalDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public RentalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Araba> Arabalar { get; set; }
        public DbSet<ArabaDetay> ArabaDetaylar { get; set; }
        public DbSet<ArabaKategori> ArabaKategorileri { get; set; }
        public DbSet<Degerlendirme> Degerlendirmeler { get; set; }
        public DbSet<Devir> Devirler { get; set; }
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Kiralama> Kiralamalar { get; set; }
        public DbSet<KiralamaDetay> KiralamaDetaylar { get; set; }
        public DbSet<Sigorta> Sigortalar { get; set; }
        public DbSet<Teslim> Teslimler { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Araba>()
        //        .HasOne(a => a.ArabaDetay)
        //        .WithOne(ad => ad.Araba)
        //        .HasForeignKey(a => a.ArabaDetayId)

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Araba>()
                .HasOne(a => a.ArabaDetay)
                .WithOne(ad => ad.Araba)
                .HasForeignKey<ArabaDetay>(ad => ad.ArabaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
