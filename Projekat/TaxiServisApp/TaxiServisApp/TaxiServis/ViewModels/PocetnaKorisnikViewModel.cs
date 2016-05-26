using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.Views;
using Windows.UI.Popups;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class PocetnaKorisnikViewModel
    {
        Korisnik korisnik;
        public string geoDuzina { get; set; }
        public string geoSirina { get; set; }
        public ICommand naruciTaxiOdmah { get; set; }
        
        Lokacija lokacija { get; set; }
        MainPageViewModel parent;
        private PocetnaKorisnikView pocetnaKorisnikView;

        public PocetnaKorisnikViewModel()
        {
            ispisPoruke("Konstruktor bez parametara", "PocetnaKorisnikViewModel");
            naruciTaxiOdmah = new RelayCommand<object>(naruciTaxiOdmahCommand, okNarudzba);

        }
        public bool okNarudzba(object obj)
        {
           // ispisPoruke("ok", "ok");
            return true;
        }

        public PocetnaKorisnikViewModel(MainPageViewModel parent)

        {
            ispisPoruke("Konstruktor sa MainPageViewModel parametrom"," PocetnaKorisnikViewModel");
            this.parent = parent;
            korisnik = parent.korisnik;
            naruciTaxiOdmah = new RelayCommand<object>(naruciTaxiOdmahCommand, okNarudzba);
        }

        public PocetnaKorisnikViewModel(PocetnaKorisnikView pocetnaKorisnikView)
        {
            this.pocetnaKorisnikView = pocetnaKorisnikView;
        }

        public void naruciTaxiOdmahCommand(object obj)
        {
            ispisPoruke("Pocetak kreiranja zahtjeva", "Kreiranje zapocelo");

            RegistrovaniKlijent registrovaniKlijent = new RegistrovaniKlijent() ;
            lokacija.duzina = geoDuzina;
            lokacija.sirina = geoSirina;
            using (var db = new TaxiServisDbContext())
            {
                foreach(var regKlijent in db.RegistrovaniKlijenti)
                {
                    if(regKlijent.korisnickoIme==korisnik.KorisnickoIme && regKlijent.sifra == korisnik.Sifra)
                    {
                        registrovaniKlijent = regKlijent;
                       
                        break;
                    }
                }

                db.ZahtjeviZaPrijevoz.Add(new NarudzbaOdmah()
                {
                    vrijemeNarudzbe = DateTime.Now,
                    klijent = registrovaniKlijent,
                    idVozačPrihvatio = null,
                    lokacijaKorisika = lokacija,
                    statusNarudzbe = StatusNarudzbe.Kreirana,
                });
                db.SaveChanges();
                ispisPoruke("Uspjesno kreiran zahtjev za voznju. ", "Kreiran zahtjev");
            }
        }
        public async void ispisPoruke(string poruka, string naslov)
        {
            {
                var dialog = new MessageDialog(poruka, naslov);
                
                await dialog.ShowAsync();
            }
        }
    }
}
