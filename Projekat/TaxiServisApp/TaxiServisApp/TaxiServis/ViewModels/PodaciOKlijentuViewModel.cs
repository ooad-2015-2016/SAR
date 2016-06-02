using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.Views;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class PodaciOKlijentuViewModel
    {
        public MainPageView parent;
        public Korisnik korisnik;
        public RegistrovaniKlijent klijent { get; set; }
        public List<NarudzbaOdmah> listaNarudzbiOdmah { get; set; }
        public List<Rezervacija> listaRezervacija { get; set; }


        public PodaciOKlijentuViewModel(MainPageView parameter)
        {
            parent = parameter;
            korisnik = parent._korisnik;

            using (var db = new TaxiServisDbContext())
            {
                //trazimo klijenta
                try {
                    klijent = (from r in db.RegistrovaniKlijenti where r.korisnickoIme == korisnik.KorisnickoIme select r).First();
                    //trazimo njegove narudzbe odmah
                    try {
                        listaNarudzbiOdmah = (from n in db.NarudzbeOdmah where n.klijentId == klijent.id select n).ToList();
                    }
                    catch(System.Exception)
                    { }
                    //trazimo njegove rezervacije
                    try
                    {
                     listaRezervacija = (from n in db.Rezervacije where n.klijentId == klijent.id select n).ToList();
                    }
                    catch (System.Exception)
                    { }
                }
                catch (Exception)
                {

                }

            }
        }
    }
}









               
