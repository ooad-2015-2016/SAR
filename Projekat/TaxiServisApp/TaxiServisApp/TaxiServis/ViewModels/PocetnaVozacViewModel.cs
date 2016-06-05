using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using System.ServiceModel.Dispatcher;
using TaxiServisApp.TaxiServis.Views;
using Windows.UI.Popups;
using TaxiServisApp.TaxiServis.Models;
using Windows.Services.Maps;
using Windows.Services.Maps;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Storage.Streams;
using MapControl;
using Windows.Foundation;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class PocetnaVozacViewModel
    {
        private MainPageView parameter;
        public List<ZahtjevZaPrevozZaListe> listaZahtjeva { get; set; }
        public bool raditiUpdateZahtjeva { get; set; }
        Geolocator geolocator;
        // Task lociranje;
        Geoposition geoposition;
        MapIcon mapIcon;
        bool ponavljanjePetljeLociranja;
        Korisnik korisnik;
        Vozac vozac { get; set; }
        public List<ZahtjevZaPrevozSaPushPinom> listaZahtjevaSaPushpinom { get; set; }
        public bool raditiUpdateZahtjevaLista { get; set; }
        //public List<Pushpin> pushPin { get; set; }
        BasicGeoposition b;
        //Lokacija l;
        Geopoint geoPoint;
        MapIcon pin;
        public string vozacKorisnickoIme { get; set; }
   //     BingMaps mapa = new Map();
        public PocetnaVozacViewModel(MainPageView parameter)
        {
            {
               // var dialog = new MessageDialog("pokrenuto sa MainPageView ");
              //   dialog.ShowAsync();
            }
            this.parameter = parameter;

            korisnik = parameter._korisnik;
            using (var db = new TaxiServisDbContext())
            {
                if(db.Vozači!= null)
                {
                    vozac = (from v in db.Vozači where v.id == korisnik.KorisnikId select v).First();
                }
            }
            vozacKorisnickoIme = vozac.korisnickoIme;
            mapIcon = new MapIcon();
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/taxiSlobodan.png"));
            mapIcon.Title = "Vaša lokacija";
            mapIcon.NormalizedAnchorPoint = new Point(0, 0.5);
       //     vozacMapa_MapControl.MapElements.Add(mapIcon);
            listaZahtjevaSaPushpinom = new List<ZahtjevZaPrevozSaPushPinom>();
            listaZahtjeva = new List<ZahtjevZaPrevozZaListe>();
            ponavljanjePetljeLociranja = true;
            raditiUpdateZahtjeva = true;

        //    updateMape();
            raditiUpdateZahtjevaLista = true;
            updateZahtjevaLista();
            if (listaZahtjeva == null || listaZahtjeva.Count() == 0)
            {
               // var dialog = new MessageDialog("lista je prazna");
              //  dialog.ShowAsync();
            }
            else
            {
              ///  var dialog = new MessageDialog("lista nije prazna");
              //  dialog.ShowAsync();
            }
            updateZahtjevaListaNeprestano();

        }

        public async void updateZahtjevaLista()
        {

            using (var db = new TaxiServisDbContext())
            {

                  listaZahtjeva.Clear();

                ZahtjevZaPrevozZaListe zahtjevZaListe = new ZahtjevZaPrevozZaListe();
                foreach (var zahtjevOdmah in db.NarudzbeOdmah.ToList())
                {
                    // var dialog = new MessageDialog("radiUnos");
                    //dialog.ShowAsync();
                    DateTime trenutnoVrijeme = DateTime.Now;
                        zahtjevZaListe.vrijemeCekanja = trenutnoVrijeme -  zahtjevOdmah.vrijemeNarudzbe;
                    zahtjevZaListe.vrijemeCekanjaString = zahtjevZaListe.vrijemeCekanja.ToString(@"hh\:mm\:ss");
                    //zahtjevZaListe.vrijemeCekanja.
                    zahtjevZaListe.id = zahtjevOdmah.id;
                    zahtjevZaListe.tipZahtjeva = TipZahtjevaZaPrevoz.NarudzbaRegistrovaniKlijent;
                    zahtjevZaListe.klijent = (from k in db.RegistrovaniKlijenti where k.id == zahtjevOdmah.klijentId select k.korisnickoIme).First().ToString();
                    zahtjevZaListe.lokacija = (from l in db.Lokacije where l.id == zahtjevOdmah.lokacijaKorisikaId select l.nazivLokacije).First().ToString();
                    listaZahtjeva.Add(zahtjevZaListe);
                }
            }

        }

        public async void updateZahtjevaListaNeprestano()
        {
            while (raditiUpdateZahtjevaLista)
            {
                updateZahtjevaLista();
                await Task.Delay(5000);
                /*if (listaZahtjeva == null || listaZahtjeva.Count() == 0)
                {
                    var dialog = new MessageDialog("lista je prazna");
                    await dialog.ShowAsync();
                }
                else
                {
                    var dialog = new MessageDialog("lista nije prazna, clanova:",Convert.ToString(listaZahtjeva.Count()));
                    await dialog.ShowAsync();
                }*/
            };


        }

        public async void ispisPoruke(string poruka, string naslov)
        {
            {
                var dialog = new MessageDialog(poruka, naslov);
                await dialog.ShowAsync();
            }
        }
        public async void pomocnaNotifikacija()
        {
            var poruka = new MessageDialog("DataContext je ok");
            await poruka.ShowAsync();
        }
      /*  private async void PocetnaKorisnikView_Loaded(object sender, RoutedEventArgs e)
        {
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10));
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox("Lokacija na uređaju je isključena!");
            }
        }

        private void ZoomValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (vozacMapa_MapControl != null)
                vozacMapa_MapControl.ZoomLevel = e.NewValue;
        }

        private void KorisnickaMapa_MapControl_ZoomLevelChanged(Windows.UI.Xaml.Controls.Maps.MapControl sender, object args)
        {
            if (vozacMapa_MapControl != null)
                mySlider.Value = sender.ZoomLevel;
        }

        private async void LocateMe_Click(object sender, RoutedEventArgs e)
        {
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10));
                await vozacMapa_MapControl.TrySetViewAsync(geoposition.Coordinate.Point, 18D);
                mySlider.Value = vozacMapa_MapControl.ZoomLevel;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox("Lokacija na uređaju je isključena!");
            }
        }

        public async void updateMape()
        {
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;
            try
            {
                while (ponavljanjePetljeLociranja)
                {
                    updateZahtjeva();
                    geoposition = await geolocator.GetGeopositionAsync(
                       maximumAge: TimeSpan.FromMinutes(5),
                       timeout: TimeSpan.FromSeconds(10));
                    await vozacMapa_MapControl.TrySetViewAsync(geoposition.Coordinate.Point);

                    mapIcon.Location = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = geoposition.Coordinate.Point.Position.Latitude,
                        Longitude = geoposition.Coordinate.Point.Position.Longitude
                    });
                    mapIcon.NormalizedAnchorPoint = new Point(0, 0.5);
                    //vozacMapa_MapControl.ZoomLevel = mySlider.Value;
                    mySlider.Value = vozacMapa_MapControl.ZoomLevel;
                    geoDuzina_TextBlock.Text = Convert.ToString(vozacMapa_MapControl.Center.Position.Longitude);
                    geoSirina_TextBlock.Text = Convert.ToString(vozacMapa_MapControl.Center.Position.Latitude);
                    //updateZahtjeva();
                    await Task.Delay(1000);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox("Lokacija na uređaju je isključena!");
            }
            // catch (System.Exception)
            {
                //   MessageBox("Vaš uređaj trenutno ne podržava uslugu lociranja. Uključite lokaciju i proverite Internet konekciju!");
            }
            //await Task.Delay(5000);
        }

        private async void MessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => await dialog.ShowAsync());
        }

        public void updateZahtjeva()
        {
            using (var db = new TaxiServisDbContext())
            {
                //listaZahtjevaPushpin.Clear();
                vozacMapa_MapControl.MapElements.Clear();
                ZahtjevZaPrevozSaPushPinom zahtjevZaSaPushpinom = new ZahtjevZaPrevozSaPushPinom();
                zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe = new ZahtjevZaPrevozZaListe();
                if (db.NarudzbeOdmah != null)
                    foreach (var zahtjevOdmah in db.NarudzbeOdmah)
                    {
                        zahtjevZaSaPushpinom.idZahtjeva = zahtjevOdmah.id;
                        zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.vrijemeCekanja = DateTime.Now - zahtjevOdmah.vrijemeNarudzbe;
                        zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.tipZahtjeva = TipZahtjevaZaPrevoz.NarudzbaRegistrovaniKlijent;
                        zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.klijent = (from k in db.RegistrovaniKlijenti where k.id == zahtjevOdmah.klijentId select k.korisnickoIme).First().ToString();
                        zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.lokacija = (from l in db.Lokacije where l.id == zahtjevOdmah.lokacijaKorisikaId select l.nazivLokacije).First().ToString();
                        zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.id = zahtjevOdmah.id;
                        //listaZahtjevaPushpin.Add(zahtjevZaListe);
                        b = new BasicGeoposition();
                        double d = (from l in db.Lokacije where l.id == zahtjevOdmah.lokacijaKorisikaId select l.duzina).First();
                        double s = (from l in db.Lokacije where l.id == zahtjevOdmah.lokacijaKorisikaId select l.sirina).First();
                        b.Latitude = s;
                        b.Longitude = d;
                        geoPoint = new Geopoint(b);
                        pin = new MapIcon();
                        pin.Location = geoPoint;
                        pin.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/klijentNarudzbaOdmah.png"));

                        pin.NormalizedAnchorPoint = new Point(0, 0.5);
                        pin.Title = zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.klijent;

                        vozacMapa_MapControl.MapElements.Add(mapIcon);
                        vozacMapa_MapControl.MapElements.Add(pin);
                        listaZahtjevaSaPushpinom.Add(zahtjevZaSaPushpinom);
                        // var dialog = new MessageDialog("dodanPushpin", vozacMapa_MapControl.MapElements.Count().ToString());
                        //  dialog.ShowAsync();
                    }
               
            }
        }

        public async void updateZahtjevaNeprestano()
        {
            while (raditiUpdateZahtjeva)
            {
                updateZahtjeva();
                await Task.Delay(5000);
            };


        }

        private async void vozacMapa_MapControl_MapElementClick(Windows.UI.Xaml.Controls.Maps.MapControl sender, MapElementClickEventArgs args)
        {
            MapIcon ikonica = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;
            if (ikonica.Title == "Vaša Lokacija")
            {

            }
            else
            {
                foreach (var zahtjevSaPushpinom in listaZahtjevaSaPushpinom)
                {
                    if (ikonica.Title == zahtjevSaPushpinom.zahtjevaZaPrevozZaListe.klijent)
                    {
                        if (zahtjevSaPushpinom.tipZahtjevaZaPrevoz == TipZahtjevaZaPrevoz.NarudzbaRegistrovaniKlijent)
                        {
                            string ispisNarudzbe = "Želite li da prihvatite narudžbu?\nKlijent: " + zahtjevSaPushpinom.zahtjevaZaPrevozZaListe.klijent + "\nLokacija: " + zahtjevSaPushpinom.zahtjevaZaPrevozZaListe.lokacija + "\nVrijeme čekanja: " + zahtjevSaPushpinom.zahtjevaZaPrevozZaListe.vrijemeCekanja;
                            var dialog = new MessageDialog(ispisNarudzbe);
                            dialog.Title = "Preuzimanje narudžbe";
                            dialog.Commands.Add(new UICommand { Label = "Da", Id = 0 });
                            dialog.Commands.Add(new UICommand { Label = "Ne", Id = 1 });
                            // dialog.Commands.Add(new UICommand { Label = "Ignoriši", Id = 2 });

                            var res = await dialog.ShowAsync();

                            if ((int)res.Id == 0)
                            {
                                using (var db = new TaxiServisDbContext())
                                {

                                }
                            }
                        }

                    }
                    break;
                }

            }
        }
        */
    }
}
