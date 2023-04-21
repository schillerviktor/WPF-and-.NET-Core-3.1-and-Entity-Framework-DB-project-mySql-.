using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Tanulok;

namespace Tanulok
{
    public class ApplicationDBContext : DbContext // Az alkalmazás adatbázis kontextus osztálya, amely örököl az Entity Framework DbContext osztályából.
    {
        // Az alkalmazásban használt entitások / egyedek adatbázis tábláihoz tartozó DbSet objektumok.
        public DbSet<SzervezetiEgyseg> SzervezetiEgysegek { get; set; }
        public DbSet<Tanulo> Tanulok { get; set; }

        public DbSet<Tagozat> Tagozatok { get; set; }

        // Az adatbázis kapcsolathoz szükséges konfiguráció, amelyet a OnConfiguring metódusban állítunk be.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost; Database=tanulok; Uid=root; Pwd=;"); // MySQL adatbázis kapcsolat beállítása. Kapcsolati 'string'.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Az adatbázis entitások modellezéséhez szükséges konfiguráció, amelyet az OnModelCreating metódusban állítunk be.
        {
            modelBuilder.Entity<SzervezetiEgyseg>().HasIndex(x => x.SZeNev).IsUnique(); // Az adatbázisban egyedinek kell lennie a SzervezetiEgyseg nevének.
            modelBuilder.Entity<Tanulo>().HasIndex(z => z.NEPTUNKod).IsUnique(); // Az adatbázisban egyedinek kell lennie a Tanulo NEPTUN-kódjának.
            modelBuilder.Entity<Tagozat>().HasIndex(n => n.TagozatNev).IsUnique(); // Az adatbázisban egyedinek kell lennie a Tagozat nevének.

            modelBuilder.Entity<SzervezetiEgyseg>().HasData(
                new SzervezetiEgyseg() { Id = 1, SZeNev = "Műszaki és Informatikai Kar" },
                new SzervezetiEgyseg() { Id = 2, SZeNev = "Gazdaságtudományi Kar" },
                new SzervezetiEgyseg() { Id = 3, SZeNev = "Kertészeti és Vidékfejlesztési Kar" }
            ); // Az adatbázisba kezdő / statikus adatok betöltése. Módosítható & bővíthető.
            modelBuilder.Entity<Tagozat>().HasData(
                new Tagozat() { Id = 1, TagozatNev = "Nappali" },
                new Tagozat() { Id = 2, TagozatNev = "Levelező" }
                
            );
        }
    }
}
