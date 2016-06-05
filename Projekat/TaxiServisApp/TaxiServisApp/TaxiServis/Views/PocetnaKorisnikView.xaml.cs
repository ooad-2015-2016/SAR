using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.ViewModels;
using TaxiServisApp.TaxiServis.Views;

using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TaxiServisApp.TaxiServis.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PocetnaKorisnikView : Page
    {
        Geolocator geolocator;
        Geoposition geoposition;
        MapIcon mapIcon;
        bool ponavljanjePetljeLociranja;
        Korisnik _korisnik { get; set; }
        NavigationEventArgs _e;
        BasicGeoposition b;
        //Lokacija l;
        Geopoint geoPoint;
        MapIcon pin;
        VozacSaPushPinom vozacPushPin;
        RegistrovaniKlijent klijent;
        bool raditiUpdateMape;

        public PocetnaKorisnikView()
        {
            this.InitializeComponent();
            this.Loaded += PocetnaKorisnikView_Loaded;
            mapIcon = new MapIcon();
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/klijentTrenutni.png"));
            mapIcon.Title = "Vaša lokacija";
            mapIcon.NormalizedAnchorPoint = new Point(0, 1);
            _korisnik = new Korisnik();
            klijent = new RegistrovaniKlijent();
            string vozacUsername = textBlock_korisnik.Text;

            using (var db = new TaxiServisDbContext())
            {
                foreach (var k in db.RegistrovaniKlijenti)
                {
                    if (k.korisnickoIme == vozacUsername)
                        this.klijent = k;

                    break;
                }
            }
            raditiUpdateMape = true;

                korisnickaMapa_MapControl.MapElements.Add(mapIcon);
            ponavljanjePetljeLociranja = true;
            locirajMe();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _e = e;
            DataContext = new PocetnaKorisnikViewModel((MainPageView)_e.Parameter);
           
        }
        private async void PocetnaKorisnikView_Loaded(object sender, RoutedEventArgs e)
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
            catch (System.Exception)
            {
                // MessageBox("Vaš uređaj trenutno ne podržava uslugu lociranja. Uključite lokaciju i proverite Internet konekciju!");

                var dialog = new MessageDialog("Vaš uređaj trenutno ne podržava uslugu lociranja. Uključite lokaciju i proverite Internet konekciju! \nŽelite li zatvoriti aplikaciju  ili pokušati ponovo?");
                dialog.Title = "Isključena lokacija ";
                dialog.Commands.Add(new UICommand { Label = "Zatvori aplikaciju", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "Pokušaj ponovo", Id = 1 });
                // dialog.Commands.Add(new UICommand { Label = "Ignoriši", Id = 2 });

                var res = await dialog.ShowAsync();

                if ((int)res.Id == 0)
                {
                    Application.Current.Exit();
                        //Frame.Navigate(typeof(LogInPage));

                        //e.Handled = true;
                    
                }
                else { }

            }
            await Task.Delay(1000);
        }
        private void ZoomValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (korisnickaMapa_MapControl != null)
                korisnickaMapa_MapControl.ZoomLevel = e.NewValue;
        }
        private void KorisnickaMapa_MapControl_ZoomLevelChanged(Windows.UI.Xaml.Controls.Maps.MapControl sender, object args)
        {
            if (korisnickaMapa_MapControl != null)
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
                await korisnickaMapa_MapControl.TrySetViewAsync(geoposition.Coordinate.Point, 18D);
                mySlider.Value = korisnickaMapa_MapControl.ZoomLevel;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox("Lokacija na uređaju je isključena!");
            }
        }
        public async void locirajMe()
        {
                geolocator = new Geolocator();
                geolocator.DesiredAccuracyInMeters = 50;
                try
                {
                while (ponavljanjePetljeLociranja)
            {
                    geoposition = await geolocator.GetGeopositionAsync(
                       maximumAge: TimeSpan.FromMinutes(5),
                       timeout: TimeSpan.FromSeconds(10));
                    await korisnickaMapa_MapControl.TrySetViewAsync(geoposition.Coordinate.Point);

                    mapIcon.Location = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = geoposition.Coordinate.Point.Position.Latitude,
                        Longitude = geoposition.Coordinate.Point.Position.Longitude
                    });
                    mapIcon.NormalizedAnchorPoint = new Point(0, 0.5);
                    korisnickaMapa_MapControl.ZoomLevel = mySlider.Value;
                    geoDuzina_TextBlock.Text = Convert.ToString(korisnickaMapa_MapControl.Center.Position.Longitude);
                    geoSirina_TextBlock.Text = Convert.ToString(korisnickaMapa_MapControl.Center.Position.Latitude);
                }  
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox("Lokacija na uređaju je isključena!");
                }
            catch (System.Exception)
            {
                MessageBox("Vaš uređaj trenutno ne podržava uslugu lociranja. Uključite lokaciju i proverite Internet konekciju!");
            }
                await Task.Delay(500);
        }
        private async void MessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => await dialog.ShowAsync());
        }

        public async void updateTaxiVozila()
        {
            bool imaZahtjevPrihvacen = false;
            using (var db = new TaxiServisDbContext())
            {
                //listaZahtjevaPushpin.Clear();
                korisnickaMapa_MapControl.MapElements.Clear();
                korisnickaMapa_MapControl.Children.Clear();
                korisnickaMapa_MapControl.Routes.Clear();
                vozacPushPin = new VozacSaPushPinom();
                NarudzbaOdmah narudzba = new NarudzbaOdmah();
                if (db.Vozači != null)
                    korisnickaMapa_MapControl.MapElements.Add(mapIcon);
                try
                {
                    foreach(var z in db.NarudzbeOdmah)
                    {
                        if (z.klijentId == klijent.id && z.statusNarudzbe == StatusNarudzbe.Prihvacena)
                        {
                            imaZahtjevPrihvacen = true;
                            narudzba = z;
                        }
                    }

                    foreach (var vozac in db.Vozači)
                    {
                        if ((vozac.aktivan == true && vozac.slobodan == true) && imaZahtjevPrihvacen == false)
                        {
                            vozacPushPin.vozac = vozac;
                            b = new BasicGeoposition();
                            double d = (from l in db.Lokacije where l.id == vozac.trenutnaLokacijaId select l.duzina).First();
                            double s = (from l in db.Lokacije where l.id == vozac.trenutnaLokacijaId select l.sirina).First();
                            b.Latitude = s;
                            b.Longitude = d;
                            geoPoint = new Geopoint(b);
                            pin = new MapIcon();
                            pin.Location = geoPoint;
                                pin.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/taxiSlobodan.png"));
                            pin.NormalizedAnchorPoint = new Point(0, 1);
                            pin.Title = vozacPushPin.vozac.korisnickoIme;
                            //prikaz rute/puta do klijenta
                           
                            korisnickaMapa_MapControl.MapElements.Add(pin);
                            //listaZahtjevaSaPushpinom.Add(zahtjevZaSaPushpinom);
                            // var dialog = new MessageDialog("dodanPushpin", vozacMapa_MapControl.MapElements.Count().ToString());
                            //  dialog.ShowAsync();
                        }
                        else if ((vozac.aktivan == true && vozac.slobodan == false) && imaZahtjevPrihvacen == true)
                        {
                            vozacPushPin.vozac = vozac;
                            b = new BasicGeoposition();
                            double d = (from l in db.Lokacije where l.id == vozac.trenutnaLokacijaId select l.duzina).First();
                            double s = (from l in db.Lokacije where l.id == vozac.trenutnaLokacijaId select l.sirina).First();
                            b.Latitude = s;
                            b.Longitude = d;
                            geoPoint = new Geopoint(b);
                            pin = new MapIcon();
                            pin.Location = geoPoint;
                            pin.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/taxiOstaliTaxi.png"));
                            pin.NormalizedAnchorPoint = new Point(0, 1);
                            pin.Title = vozacPushPin.vozac.korisnickoIme;
                            //prikaz rute/puta do klijenta

                            korisnickaMapa_MapControl.MapElements.Add(pin);
                            //lokacija klijenta
                            BasicGeoposition startLocation = new BasicGeoposition() { Latitude = mapIcon.Location.Position.Latitude, Longitude = mapIcon.Location.Position.Longitude };
                            //lokacija taxija
                            BasicGeoposition endLocation = new BasicGeoposition() { Latitude = pin.Location.Position.Latitude, Longitude = pin.Location.Position.Longitude };


                            // Get the route between the points.
                            MapRouteFinderResult routeResult =
                                  await MapRouteFinder.GetDrivingRouteAsync(
                                  new Geopoint(startLocation),
                                  new Geopoint(endLocation),
                                  MapRouteOptimization.Time,
                                  MapRouteRestrictions.None);

                            if (routeResult.Status == MapRouteFinderStatus.Success)
                            {
                                // Use the route to initialize a MapRouteView.
                                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                                viewOfRoute.RouteColor = Colors.LightGreen;
                                viewOfRoute.OutlineColor = Colors.DarkGray;

                                // Add the new MapRouteView to the Routes collection
                                // of the MapControl.
                                korisnickaMapa_MapControl.Routes.Add(viewOfRoute);

                                // Fit the MapControl to the route.
                                /*     await vozacMapa_MapControl.TrySetViewBoundsAsync(
                                           routeResult.Route.BoundingBox,
                                           null,
                                           Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);*/
                            }
                        }
                    }
                }
                catch (System.Exception)
                { }
               
            }
        }

        public async void updateMapeStalno()
        {
            while (raditiUpdateMape)
            {
                updateTaxiVozila();
                await Task.Delay(5000);
            };


        }
    }
}
