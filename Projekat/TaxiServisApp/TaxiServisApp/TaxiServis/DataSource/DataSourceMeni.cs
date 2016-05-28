using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp;
using TaxiServisApp.TaxiServis.Views;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.ViewModels;
using TaxiServisApp.TaxiServis.Views;

namespace TaxiServisApp.TaxiServis.DataSource
{
    public class DataSourceMeni
    {
        #region Korisnik - kreiranje testnih korisnika
        private static List<Korisnik> _korisnici = new List<Korisnik>();
        /*  {//testni korisnici
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
           ,
           new Korisnik() {
          KorisnikId=5,
          KorisnickoIme="admin",
          Sifra="admin"
          }
          };*/

        public void unesiKlijenteUKorisnike()
        {
            List<RegistrovaniKlijent> listaRegKlijenata;
            using (var db = new TaxiServisDbContext())
            {
                listaRegKlijenata = db.RegistrovaniKlijenti.ToList();
            }
            foreach (RegistrovaniKlijent lK in listaRegKlijenata)
                _korisnici.Add(new Korisnik() { KorisnikId = lK.id, KorisnickoIme = lK.korisnickoIme, Sifra = lK.sifra, Aktivan = true });
            // _korisnici = listaKlijenata;
        }


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
   Naziv="Klijent"
    },
    new Uloga()
    {
    UlogaId=2,
    Naziv="Vozac"
    },
     new Uloga()
    {
    UlogaId=3,
   Naziv="Dispecer"
    }, new Uloga()
    {
    UlogaId=4,
   Naziv="Supervizor"
    }
    , new Uloga()
    {
    UlogaId=5,
   Naziv="Admin"
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
   Podstranica = typeof(PocetnaKorisnikView),
   PodstranicaViewModel = typeof(PocetnaKorisnikViewModel)
    },
    new MeniStavka()
    {
    MeniStavkaId=2,
   Naziv="Napravi Rezervaciju",
    Kod="K2",
    Podstranica = typeof(RezervacijaPageView),
    PodstranicaViewModel = typeof(RezervacijaViewModel)
    },
    new MeniStavka()
    {
    MeniStavkaId=3,
   Naziv="Podaci o racunu",
   Kod="K3",
    Podstranica = typeof(PodaciOKlijentuView),
    PodstranicaViewModel = typeof(PodaciOKlijentuViewModel)
    },
    new MeniStavka()
    {
    MeniStavkaId=4,
   Naziv="Pocetna Vozac",
   Kod="V1",
   Podstranica = typeof(PocetnaVozacView),
   PodstranicaViewModel = typeof(PocetnaVozacViewModel)
    },
       new MeniStavka()
    {
    MeniStavkaId=5,
   Naziv="Podaci o Vozacu",
   Kod="V2",
   Podstranica = typeof(PodaciOVozacuView),
           PodstranicaViewModel = typeof(PodaciOVozacuViewModel)
    },
     new MeniStavka()
    {
    MeniStavkaId=6,
   Naziv="Pocetna Dispecer",
   Kod="D1",
   Podstranica = typeof(PocetnaDispecerView),
   PodstranicaViewModel = typeof(PocetnaDispecerViewModel)
    },

       new MeniStavka()
    {
    MeniStavkaId=7,
   Naziv="Pocetna Supervizor",
   Kod="S1",
   Podstranica = typeof(PocetnaSupervizorView),
   PodstranicaViewModel = typeof(PocetnaSupervizorViewModel)
    },
           new MeniStavka()
    {
    MeniStavkaId=8,
   Naziv="Registracija uposlenika",
   Kod="S2",
   Podstranica = typeof(RegistracijaUposlenikaView),
   PodstranicaViewModel = typeof(RegistracijaUposlenikaViewModel)
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
            unesiKlijenteUKorisnike();
            //Korisnik k1 = DajKorisnikaPoId(1);
            // Korisnik k2 = DajKorisnikaPoId(2);
            //Korisnik k3 = DajKorisnikaPoId(3);
            //Korisnik k4 = DajKorisnikaPoId(4);
            // Korisnik k5 = DajKorisnikaPoId(5);
            Uloga u1 = DajUloguPoId(1);
            Uloga u2 = DajUloguPoId(2);
            Uloga u3 = DajUloguPoId(3);
            Uloga u4 = DajUloguPoId(4);
            Uloga u5 = DajUloguPoId(5);
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
            //k1.DodajUloguKorisnika(u1);
            //Dodavanje stavki ulozi i uloge vozacu 
            u2.DodajMeniStavkuUlozi(ms4);
            u2.DodajMeniStavkuUlozi(ms5);
            u2.DodajMeniStavkuUlozi(ms10);

            // k2.DodajUloguKorisnika(u2);
            //dispecer isto
            u3.DodajMeniStavkuUlozi(ms6);
            u3.DodajMeniStavkuUlozi(ms2);
            u3.DodajMeniStavkuUlozi(ms10);

            // k3.DodajUloguKorisnika(u3);
            //supervizor
            u4.DodajMeniStavkuUlozi(ms7);
            u4.DodajMeniStavkuUlozi(ms8);
            u4.DodajMeniStavkuUlozi(ms10);

            //k4.DodajUloguKorisnika(u4);

            //admin (tester)
            u5.DodajMeniStavkuUlozi(ms10);
            // k5.DodajUloguKorisnika(u5);
            List<RegistrovaniKlijent> listaRegKlijenata;
            List<Vozac> listaVozaca;
            List<Dispecer> listaDispecera;
            List<Supervizor> listaSupervizora;
            using (var db = new TaxiServisDbContext())
            {
                listaRegKlijenata = db.RegistrovaniKlijenti.ToList();
                listaVozaca = db.Vozači.ToList();
                listaDispecera = db.Dispeceri.ToList();
                listaSupervizora = db.Supervizori.ToList();
            }
            //Dodati: Ovdje dodati, kao i u bazi, datume registracija, kao i aktivnost drugih ppraviti
            //dodavanje korisnika (klijenata) iz baze
            foreach (RegistrovaniKlijent lK in listaRegKlijenata)
            {
                Korisnik korisnikZaListu = new Korisnik() { KorisnikId = lK.id, KorisnickoIme = lK.korisnickoIme, Sifra = lK.sifra };
                korisnikZaListu.DodajUloguKorisnika(u1);
                _korisnici.Add(korisnikZaListu);
            }
            //Dodavanje Vozaca iz baze u listu korisnika
            foreach (Vozac lK in listaVozaca)
            {
                Korisnik korisnikZaListu = new Korisnik() { KorisnikId = lK.id, KorisnickoIme = lK.korisnickoIme, Sifra = lK.sifra };
                korisnikZaListu.DodajUloguKorisnika(u2);
                _korisnici.Add(korisnikZaListu);
            }
            //Dodavanje Dispecera iz baze 
            foreach (Dispecer lK in listaDispecera)
            {
                Korisnik korisnikZaListu = new Korisnik() { KorisnikId = lK.id, KorisnickoIme = lK.korisnickoIme, Sifra = lK.sifra };
                korisnikZaListu.DodajUloguKorisnika(u3);
                _korisnici.Add(korisnikZaListu);

            }

            //dodavanje supervizora
            foreach (Supervizor lK in listaSupervizora)
            {
                Korisnik korisnikZaListu = new Korisnik() { KorisnikId = lK.id, KorisnickoIme = lK.korisnickoIme, Sifra = lK.sifra };
                korisnikZaListu.DodajUloguKorisnika(u2);
                _korisnici.Add(korisnikZaListu);
            }
            #endregion
        }

    }
}
