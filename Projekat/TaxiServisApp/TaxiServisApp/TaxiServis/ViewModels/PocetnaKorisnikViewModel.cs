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
        public Korisnik korisnik;
        public string geoDuzina { get; set; }
        public string geoSirina { get; set; }
        public ICommand naruciTaxiOdmah { get; set; }
        
        Lokacija lokacija { get; set; }
        MainPageView parent;

       /*   public PocetnaKorisnikViewModel()
      {
            ispisPoruke("Konstruktor bez parametara", "PocetnaKorisnikViewModel");
            naruciTaxiOdmah = new RelayCommand<object>(naruciTaxiOdmahCommand, okNarudzba);

        }*/
        public bool okNarudzba(object obj)
        {
           // ispisPoruke("ok", "ok");
            return true;
        }
        //Dodati: Zbog MVVM potrebno je da prima MainPageViewModel parametar, ali zbog nemogucnosti samo view
        public PocetnaKorisnikViewModel(MainPageView parent)
        {
            ispisPoruke("Konstruktor sa MainPageViewModel parametrom"," PocetnaKorisnikView");
            this.parent = parent;
            korisnik = parent._korisnik;
            naruciTaxiOdmah = new RelayCommand<object>(naruciTaxiOdmahCommand, okNarudzba);
        }

        public void naruciTaxiOdmahCommand(object obj)
        {
            ispisPoruke("Pocetak kreiranja zahtjeva", "Kreiranje zapocelo");

            string registrovaniKlijent;
           /* if(geoSirina == null ||geoDuzina == null)
            {
                ispisPoruke("geoDuzina i geoSirina su null", "null vrijednosti za lokaciju");
            }*/
            lokacija = new Lokacija();
            lokacija.duzina = geoDuzina;
            lokacija.sirina = geoSirina;
            
            using (var db = new TaxiServisDbContext())
            {
                foreach(var regKlijent in db.RegistrovaniKlijenti)
                {
                    if(regKlijent.korisnickoIme==korisnik.KorisnickoIme && regKlijent.sifra == korisnik.Sifra)
                    {
                    db.Lokacije.Add(lokacija);
                        RegistrovaniKlijent k = regKlijent;
                       // k = regKlijent;
                var narudzbaOdmah = new NarudzbaOdmah
                { 
                    
                    vrijemeNarudzbe = DateTime.Now,
                    klijent = regKlijent,
                    idVozačPrihvatio = null,
                    lokacijaKorisika = lokacija,
                    statusNarudzbe = StatusNarudzbe.Kreirana,
                };
                db.ZahtjeviZaPrijevoz.Add(narudzbaOdmah);
                db.SaveChanges();
                        registrovaniKlijent = regKlijent.id + " " + regKlijent.ime + " " + regKlijent.korisnickoIme + " " + regKlijent.sifra + "  ";
                        ispisPoruke("pronadjen klijent", registrovaniKlijent);
                        break;
                    }
                }

               // ispisPoruke("Uspjesno kreiran zahtjev za voznju. ", "Kreiran zahtjev");
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
