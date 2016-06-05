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
        public RegistrovaniKlijent klijent { get; set; }
        string klijentKorisnickoIme;
        Lokacija lokacija { get; set; }
        MainPageView parent;

        public bool okNarudzba(object obj)
        {
            return true;
        }
        //Dodati: Zbog MVVM potrebno je da prima MainPageViewModel parametar, ali zbog nemogucnosti samo view
        public PocetnaKorisnikViewModel(MainPageView parent)
        {
         //   ispisPoruke("Konstruktor sa MainPageViewModel parametrom"," PocetnaKorisnikView");
            this.parent = parent;
            korisnik = parent._korisnik;
            using (var db = new TaxiServisDbContext())
            {
                foreach(var regKlijent in db.RegistrovaniKlijenti)
                {
                    if(regKlijent.korisnickoIme == korisnik.KorisnickoIme)
                    {
                        regKlijent.online = true;
                        db.SaveChanges();
                        klijent = regKlijent;
                        db.SaveChanges();
                        klijentKorisnickoIme = regKlijent.korisnickoIme;
                        break;
                    }
                }
            }
            naruciTaxiOdmah = new RelayCommand<object>(naruciTaxiOdmahCommand, okNarudzba);
        }

        public async void naruciTaxiOdmahCommand(object obj)
        {
           // ispisPoruke("Pocetak kreiranja zahtjeva", "Kreiranje zapocelo");
            string registrovaniKlijent;
            using (var db = new TaxiServisDbContext())
            {
                try
                {
                    foreach(var n in db.NarudzbeOdmah)
                    {
                        if (n.klijentId == klijent.id && (n.statusNarudzbe == StatusNarudzbe.Kreirana || n.statusNarudzbe == StatusNarudzbe.Prihvacena))
                            throw new System.ArgumentException();
                    }

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
                            var dialog = new MessageDialog("Molimo sačekajte da ga jedan od slobodnih vozača prihvati.  ");
                            dialog.Title = "Uspješno napravljen zahtjev! ";
                            dialog.Commands.Add(new UICommand { Label = "U redu", Id = 0 });
                            var res = await dialog.ShowAsync();
                            break;
                        }
                }
                catch(System.ArgumentException)
                {
                    ispisPorukeViseKreiranihNarudzbi();
                }
            }
        }
        public async void ispisPorukeViseKreiranihNarudzbi()
        {
            using (var db = new TaxiServisDbContext())
            {
                var dialog = new MessageDialog("Ne možete napraviti novu narudžbu jer se prethodna nije još izvršila ");
                dialog.Title = "Zahtjev već postoji. Saćekajte da se prethodna izvrši, ili poništite prethodnu i pokušajte ponovo. ";
                dialog.Commands.Add(new UICommand { Label = "Saćekaj prethodnu", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "Poništi prethodnu", Id = 1 });
                dialog.Commands.Add(new UICommand { Label = "Vrati me nazad", Id = 2 });

                var res = await dialog.ShowAsync();

                if ((int)res.Id == 0)
                {


                }
                else if ((int)res.Id == 1)
                {
                    try
                    {
                        foreach (var nar in db.NarudzbeOdmah)
                        {
                            if (klijent.id == nar.klijentId && (nar.statusNarudzbe == StatusNarudzbe.Kreirana || nar.statusNarudzbe == StatusNarudzbe.Prihvacena))
                            {
                                nar.statusNarudzbe = StatusNarudzbe.Poništena;
                                db.SaveChanges();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        var greskaDialog = new MessageDialog("Došlo je do greške. Pokušajte ponovo ");
                        await greskaDialog.ShowAsync();
                    }
                }
                else { }
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

