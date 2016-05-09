using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.ViewModels;
using TaxiServisApp.TaxiServis.Views;

namespace TaxiServisApp.TaxiServis.DataSource
{
    public class DataSourceMeni
    {
        #region Korisnik - kreiranje testnih korisnika
        private static List<Korisnik> _korisnici = new List<Korisnik>()
 {
 new Korisnik()
 {
 KorisnikId=1,
 KorisnickoIme="klijent",
 Sifra="klijent",
 },
 new Korisnik()
 {
 KorisnikId=2,
 KorisnickoIme="vozac",
 Sifra="vozac"
 },
  new Korisnik()
 {
 KorisnikId=3,
 KorisnickoIme="supervizor",
 Sifra="supervizor"
 },
  new Korisnik() {
 KorisnikId=4,
 KorisnickoIme="dispecer",
 Sifra="dispecer"
 }

 };
        public static IList<Korisnik> DajSveKorisnike()
        {
            return _korisnici;
        }
        public static Korisnik DajKorisnikaPoId(int korisnikId)
        {
            return _korisnici.Where(k => k.KorisnikId.Equals(korisnikId)).FirstOrDefault();
        }
        public static Korisnik ProvjeraKorisnika(string korisnickoIme, string sifra)
        {
            Korisnik rezultat = new Korisnik();
            foreach (var k in DajSveKorisnike())
            {
                if (k.KorisnickoIme == korisnickoIme && k.Sifra == sifra) rezultat = k;
            }
            return rezultat;
        }
        #endregion
        #region Uloga - kreiranje testnih uloga
        private static List<Uloga> _uloge = new List<Uloga>()
 {
 new Uloga()
 {
 UlogaId=1,
Naziv="Klijent",
 },
 new Uloga()
 {
 UlogaId=2,
 Naziv="Vozac",
 },
  new Uloga()
 {
 UlogaId=3,
Naziv="Dispecer",
 }, new Uloga()
 {
 UlogaId=4,
Naziv="Supervizor",
 }
 };
        public static IList<Uloga> DajSveUloge()
        {
            return _uloge;
        }
        public static Uloga DajUloguPoId(int ulogaId)
        {
            return _uloge.Where(k => k.UlogaId.Equals(ulogaId)).FirstOrDefault();
        }
        #endregion
        #region MeniStavka - kreiranje novih meni stavki
        private static List<MeniStavka> _meniStavke = new List<MeniStavka>()
 {
 new MeniStavka()
 {
 MeniStavkaId=1,
Naziv="Naruci Taxi! ",
Kod="K1",
Podstranica = typeof(PocetnaKorisnikView)
 },
 new MeniStavka()
 {
 MeniStavkaId=2,
Naziv="Napravi Rezervaciju",
 Kod="K2",
 Podstranica = typeof(Views.RezervacijaPageView)
 },
 new MeniStavka()
 {
 MeniStavkaId=3,
Naziv="Podaci o racunu",
Kod="K3",
 Podstranica = typeof(PodaciOKlijentuView)
 },
 new MeniStavka()
 {
 MeniStavkaId=4,
Naziv="Pocetna Vozac",
Kod="V1",
Podstranica = typeof(PocetnaVozacView)
 },
    new MeniStavka()
 {
 MeniStavkaId=5,
Naziv="Podaci o Vozacu",
Kod="V2",
Podstranica = typeof(PodaciOVozacuView)
 },
  new MeniStavka()
 {
 MeniStavkaId=6,
Naziv="Pocetna Dispecer",
Kod="D1",
Podstranica = typeof(PocetnaDispecerView)
 },

    new MeniStavka()
 {
 MeniStavkaId=7,
Naziv="Pocetna Supervizor",
Kod="S1",
Podstranica = typeof(PocetnaSupervizorView)
 },
        new MeniStavka()
 {
 MeniStavkaId=8,
Naziv="Registracija uposlenika",
Kod="S2",
Podstranica = typeof(PocetnaSupervizorView)
 },
 new MeniStavka()
 {
 MeniStavkaId=10,
Naziv="LogOut",
Kod="00"
 }
 };
        public static IList<MeniStavka> DajSveMeniStavke()
        {
            return _meniStavke;
        }
        public static MeniStavka DajMeniStavkuPoId(int meniStavkaId)
        {
            return _meniStavke.Where(k => k.MeniStavkaId.Equals(meniStavkaId)).FirstOrDefault();
        }
        #endregion
        #region Inicijalna postavka uloga i stavki
        public DataSourceMeni()
        {
            Korisnik k1 = DajKorisnikaPoId(1);
            Korisnik k2 = DajKorisnikaPoId(2);
            Korisnik k3 = DajKorisnikaPoId(3);
            Korisnik k4 = DajKorisnikaPoId(4);
            Uloga u1 = DajUloguPoId(1);
            Uloga u2 = DajUloguPoId(2);
            Uloga u3 = DajUloguPoId(3);
            Uloga u4 = DajUloguPoId(4);
            MeniStavka ms1 = DajMeniStavkuPoId(1);
            MeniStavka ms2 = DajMeniStavkuPoId(2);
            MeniStavka ms3 = DajMeniStavkuPoId(3);
            MeniStavka ms4 = DajMeniStavkuPoId(4);
            MeniStavka ms5 = DajMeniStavkuPoId(5);
            MeniStavka ms6 = DajMeniStavkuPoId(6);
            MeniStavka ms7 = DajMeniStavkuPoId(7);
            MeniStavka ms8 = DajMeniStavkuPoId(8);
        //    MeniStavka ms9 = DajMeniStavkuPoId(9);
            MeniStavka ms10 = DajMeniStavkuPoId(10);
            //Dodavanje stavki ulozi i uloge klijentu 
            u1.DodajMeniStavkuUlozi(ms1);
            u1.DodajMeniStavkuUlozi(ms2);
            u1.DodajMeniStavkuUlozi(ms3);
            u1.DodajMeniStavkuUlozi(ms10);
            k1.DodajUloguKorisnika(u1);
            //Dodavanje stavki ulozi i uloge vozacu 
            u2.DodajMeniStavkuUlozi(ms4);
            u2.DodajMeniStavkuUlozi(ms5);
            u2.DodajMeniStavkuUlozi(ms10);

            k2.DodajUloguKorisnika(u2);
            //dispecer isto
            u3.DodajMeniStavkuUlozi(ms6);
            u3.DodajMeniStavkuUlozi(ms2);
            u3.DodajMeniStavkuUlozi(ms10);

            k3.DodajUloguKorisnika(u3);
            //supervizor
            u4.DodajMeniStavkuUlozi(ms7);
            u4.DodajMeniStavkuUlozi(ms8);
            u4.DodajMeniStavkuUlozi(ms10);

            k4.DodajUloguKorisnika(u4);
        }
        #endregion
    }

}
