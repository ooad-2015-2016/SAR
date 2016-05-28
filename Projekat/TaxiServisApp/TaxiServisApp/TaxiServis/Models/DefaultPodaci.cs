using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis;

namespace TaxiServisApp.TaxiServis.Models
{
    class DefaultPodaci
    {
        public static void Initialize(TaxiServisDbContext context)
        {
            if (!context.TaxiVozila.Any())
            {
                context.TaxiVozila.AddRange(new TaxiVozilo()
                {
                    boja = "Crvena", proizvodjac = "Yugo", godiste = Convert.ToDateTime("1.1.1985"), opis = "Ocuvan"
                }
                );
                context.SaveChanges();
                context.TaxiVozila.AddRange(new TaxiVozilo()
                {
                    boja = "Plava", proizvodjac = "Porche", godiste = Convert.ToDateTime("1.1.2002"), opis = "Malo ostecen"
                }
);
                // context.TaxiVozila.AddRange( new TaxiVozilo(1, "Plava", "Porche", Convert.ToDateTime("1.1.2002"), "Malo ostecen"));
                context.SaveChanges();
            }
            if (!context.Vozači.Any())
            {
                context.Uposlenici.AddRange(new Vozac() { ime = "Mr.", prezime = "Smith", datumRodjenja = Convert.ToDateTime("1/1/1911"), korisnickoIme = "vozac", sifra = "vozac" });
                context.SaveChanges();

                context.Uposlenici.AddRange(new Vozac() { ime = "A", prezime = "B", datumRodjenja = Convert.ToDateTime("1/1/1941"), korisnickoIme = "vozac2", sifra = "vozac2" });
                context.SaveChanges();
                context.Uposlenici.AddRange(new Vozac() { ime = "Mrs.", prezime = "Smitth", datumRodjenja = Convert.ToDateTime("1/1/1941"), korisnickoIme = "Vozac3", sifra = "Vozac3" });
                context.SaveChanges();
            }
            if (!context.Dispeceri.Any())
            {
                context.Uposlenici.AddRange(new Dispecer() { ime = "Dispecer", prezime = "Dispecer", datumRodjenja = Convert.ToDateTime("1/1/1941"), korisnickoIme = "Dispecer", sifra = "Dispecer" });
                context.SaveChanges();
            }
            if (!context.Supervizori.Any())
            {
                context.Uposlenici.AddRange(new Supervizor() { ime = "supervizor", prezime = "Supervizor", datumRodjenja = Convert.ToDateTime("1/1/1941"), korisnickoIme = "supervizor", sifra = "supervizor" });
                context.SaveChanges();
            }
            if (!context.Lokacije.Any())
            {
                context.Lokacije.AddRange(new Lokacija() { duzina = "0", sirina = "0" });
                context.Lokacije.AddRange(new Lokacija() { duzina = "1", sirina = "1" });
                context.Lokacije.AddRange(new Lokacija() { duzina = "2", sirina = "2" });

                context.SaveChanges();
            }
            if (!context.NeregistrovaniKlijenti.Any())
            {
                context.Klijenti.AddRange(new NeregistrovaniKlijent() { });
                context.SaveChanges();
            }
            if (!context.RegistrovaniKlijenti.Any())
            {
                context.Klijenti.AddRange(new RegistrovaniKlijent() { ime = "Klijent", prezime = "Klijent", mail = "mail@mail.mail", korisnickoIme = "klijent", sifra = "klijent", datumRodjenja = Convert.ToDateTime("5.5.1955"), datumRegistracije = Convert.ToDateTime("1.1.2015"), spol = Spol.Muski, brojVoznji = 3, kilometriVoznje = 123 });
                context.Klijenti.AddRange(new RegistrovaniKlijent(1, "Klijent2", "Klijent2", "mail2", "Klijent2", "Klijent2", Convert.ToDateTime("5.5.1955"), Convert.ToDateTime("1.1.2015"), Spol.Zenski, 2, 345));
                context.SaveChanges();
            }
            

        }

    }
}
