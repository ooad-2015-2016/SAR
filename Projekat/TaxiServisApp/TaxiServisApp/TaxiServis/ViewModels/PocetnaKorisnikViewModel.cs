using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.Views;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI.Popups;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class PocetnaKorisnikViewModel
    {
        public Korisnik korisnik;
        public double geoDuzina { get; set; }
        public double geoSirina { get; set; }
        public ICommand naruciTaxiOdmah { get; set; }
        
        Lokacija lokacija { get; set; }
        MainPageView parent;

        public bool okNarudzba(object obj)
        {
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

        public async void naruciTaxiOdmahCommand(object obj)
        {
            ispisPoruke("Pocetak kreiranja zahtjeva", "Kreiranje zapocelo");
            string registrovaniKlijent;
            using (var db = new TaxiServisDbContext())
            {
                lokacija = new Lokacija();
                lokacija.duzina = geoDuzina;
                lokacija.sirina = geoSirina;
                double lat = lokacija.sirina;
                double lon = lokacija.duzina;
                BasicGeoposition b = new BasicGeoposition();
                b.Latitude = lat;// zahtjevOdmah.lokacijaKorisika.duzina;
                b.Longitude = lon;
                Geopoint pointToReverseGeocode = new Geopoint(b);
                MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);
                string ispisLokacije;
                if (result.Status == MapLocationFinderStatus.Success)
                {
                    ispisLokacije = result.Locations[0].Address.Street + " " + result.Locations[0].Address.District.ToString() + " " + result.Locations[0].Address.Town.ToString() + ", " + result.Locations[0].Address.Country.ToString();
                }
                else ispisLokacije = lat.ToString() + ", " + lon.ToString();
                lokacija.nazivLokacije = ispisLokacije;
                foreach (var regKlijent in db.RegistrovaniKlijenti)
                    if (regKlijent.korisnickoIme == korisnik.KorisnickoIme && regKlijent.sifra == korisnik.Sifra)
                    {
                        db.Lokacije.Add(lokacija);
                        db.SaveChanges();
                        lokacija.id = db.Lokacije.Last().id;
               //         var dialog = new MessageDialog("lokacija id", lokacija.id.ToString());
                 //       dialog.ShowAsync();
                        RegistrovaniKlijent k = regKlijent;
                        // k = regKlijent;
                        DateTime vrijemeNarudzbeTemp = DateTime.Now;
                        var narudzbaOdmah = new NarudzbaOdmah
                        {
                            Lokacija = lokacija,
                            vrijemeNarudzbe = vrijemeNarudzbeTemp,
                            klijentId = regKlijent.id,
                            RegistrovaniKlijent = regKlijent,
                            //VozacPrihvatioId = null,
                            lokacijaKorisikaId = lokacija.id,
                            statusNarudzbe = StatusNarudzbe.Kreirana,
                        };
                        db.NarudzbeOdmah.Add(narudzbaOdmah);
                        db.SaveChanges();
                        registrovaniKlijent = regKlijent.id + " " + regKlijent.ime + " " + regKlijent.korisnickoIme + " " + regKlijent.sifra + "  ";
                        ispisPoruke("pronadjen klijent", registrovaniKlijent);
                        break;
                    }
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

