using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Context:DbContext
    {
        public DbSet<Bilet> Bilets { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmTur> FilmTurs { get; set; }
        public DbSet<Koltuk> Koltuks { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Sinema> Sinemas { get; set; }
        //public DbSet<SalonKoltuk> SalonKoltuks { get; set; }
        public DbSet<Seans> Seans { get; set; }
        public DbSet<Sehir> Sehirs { get; set; }
        //public DbSet<SinemaSalon> SinemaSalons { get; set; }
        public DbSet<Haber> Habers { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Detay> Detays { get; set; }

        //public DbSet<FilmSinema> FilmSinemas { get; set; }

        public DbSet<FilmSalonSinema> FilmSalonSinemas { get; set; }


        /* One To Many Cascade Delete Action özelliğini kaldırmak için */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


    }
}