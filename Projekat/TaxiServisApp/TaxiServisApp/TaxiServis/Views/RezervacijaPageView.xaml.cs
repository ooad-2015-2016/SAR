using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.ViewModels;
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
    public sealed partial class RezervacijaPageView : Page
    {
        Lokacija pocetna;
        Lokacija krajnja;
        bool samoPolazna;
        bool birajPolaznu;
        bool birajKrajnju;
        BasicGeoposition b;
        //Lokacija l;
        Geopoint geoPoint;
        Geolocator geolocator;
        // Task lociranje;
        Geoposition geoposition;
        MapIcon mojaLokacijaMapIcon;
        MapIcon pocetnaLokacijaMapIcon;
        MapIcon krajnjaLokacijaMapIcon;
        RegistrovaniKlijent klijent;
        Cijenovnik cijenovnik;
        RezervacijaViewModel rP;
        public RezervacijaPageView()
        {
              this.InitializeComponent();
              samoPolazna = false;
              mojaLokacijaMapIcon = new MapIcon();
              mojaLokacijaMapIcon.Title = "Trenutna lokacija";
              mojaLokacijaMapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/klijentTrenutni.png"));
              pocetnaLokacijaMapIcon = new MapIcon();

            locirajMe();

              pocetnaLokacijaMapIcon.Title = "Početna lokacija";
              mojaLokacijaMapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/klijentRezervacija.png"));
              krajnjaLokacijaMapIcon = new MapIcon();
              krajnjaLokacijaMapIcon.Title = "Krajnja lokacija";
              mojaLokacijaMapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/klijentNeregistrovaniZahtjev.png"));
            mojaLokacijaMapIcon.NormalizedAnchorPoint = new Point(0, 1);
            pocetnaLokacijaMapIcon.NormalizedAnchorPoint = new Point(0, 1);
            krajnjaLokacijaMapIcon.NormalizedAnchorPoint = new Point(0, 1);
            registracija_MapControl.MapElements.Add(mojaLokacijaMapIcon);
            registracija_MapControl.MapElements.Add(pocetnaLokacijaMapIcon);
            registracija_MapControl.MapElements.Add(krajnjaLokacijaMapIcon);
            checkBox.IsChecked = false;
            polazna_radioButton.IsChecked = true;
            krajnja_radioButton.IsChecked = false;
            polazna_radioButton.Visibility = Visibility.Visible;
            krajnja_radioButton.Visibility = Visibility.Visible;
            krajnjaLokacijaMapIcon.Visible = true;
            pocetnaLokacijaMapIcon.Visible = true;

            rastojanje_textBlock.Visibility = Visibility.Collapsed;
            cijena_textBlock.Visibility = Visibility.Collapsed;

            cijenovnik = new Cijenovnik();

            prikaziRutu();
          


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             rP = new RezervacijaViewModel((MainPageView)e.Parameter);
            DataContext = rP;
            using (var db = new TaxiServisDbContext())
            {
                klijent = new RegistrovaniKlijent();
                foreach (var k in db.RegistrovaniKlijenti)
                {
                    if (k.korisnickoIme == rP.klijenKorisnickoIme)
                    {
                        klijent = k;
                        break;
                    }
                }

            }
        }
        public async void locirajMe()
        {
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;
            try
            {
                {
                    geoposition = await geolocator.GetGeopositionAsync(
                       maximumAge: TimeSpan.FromMinutes(5),
                       timeout: TimeSpan.FromSeconds(10));
                    await registracija_MapControl.TrySetViewAsync(geoposition.Coordinate.Point);

                    mojaLokacijaMapIcon.Location = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = geoposition.Coordinate.Point.Position.Latitude,
                        Longitude = geoposition.Coordinate.Point.Position.Longitude
                    });
                    pocetnaLokacijaMapIcon.Location = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = geoposition.Coordinate.Point.Position.Latitude,
                        Longitude = geoposition.Coordinate.Point.Position.Longitude
                    });
                    krajnjaLokacijaMapIcon.Location = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = geoposition.Coordinate.Point.Position.Latitude,
                        Longitude = geoposition.Coordinate.Point.Position.Longitude
                    });
                    mojaLokacijaMapIcon.NormalizedAnchorPoint = new Point(0, 1);
                   // registracija_MapControl.ZoomLevel = mySlider.Value;
                    
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
        }
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            registracija_MapControl.Routes.Clear();
            samoPolazna = true;
            polazna_radioButton.IsChecked = true;
            polazna_radioButton.Visibility = Visibility.Visible;
            krajnja_radioButton.Visibility = Visibility.Collapsed;
            krajnjaLokacijaMapIcon.Visible = false;
            rastojanje_textBlock.Visibility = Visibility.Collapsed;
            cijena_textBlock.Visibility = Visibility.Collapsed;

        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            registracija_MapControl.Routes.Clear();
            samoPolazna = false;
            polazna_radioButton.Visibility = Visibility.Visible;
            krajnja_radioButton.Visibility = Visibility.Visible;
            krajnjaLokacijaMapIcon.Visible = true;
            rastojanje_textBlock.Visibility = Visibility.Visible;
            cijena_textBlock.Visibility = Visibility.Visible;

        }

        private async void MessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => await dialog.ShowAsync());
        }

        private void registracija_MapControl_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, MapInputEventArgs args)
        {
            registracija_MapControl.Routes.Clear();


            if (samoPolazna)
            {
                registracija_MapControl.Routes.Clear();
                BasicGeoposition pocetnaPozicija = new BasicGeoposition();
                pocetnaPozicija.Latitude = args.Location.Position.Latitude;
                pocetnaPozicija.Longitude = args.Location.Position.Longitude;
                pocetnaLokacijaMapIcon.Location= new Geopoint(pocetnaPozicija);
            }
            else
            {
                registracija_MapControl.Routes.Clear();

                if (polazna_radioButton.IsChecked == true)
                {
                    prikaziRutu();
                    BasicGeoposition pocetnaPozicija = new BasicGeoposition();
                    pocetnaPozicija.Latitude = args.Location.Position.Latitude;
                    pocetnaPozicija.Longitude = args.Location.Position.Longitude;
                    pocetnaLokacijaMapIcon.Location = new Geopoint(pocetnaPozicija);
                }
                else if (krajnja_radioButton.IsChecked == true)
                {
                    prikaziRutu();
                    BasicGeoposition krajnjaPozicija = new BasicGeoposition();
                    krajnjaPozicija.Latitude = args.Location.Position.Latitude;
                    krajnjaPozicija.Longitude = args.Location.Position.Longitude;
                    krajnjaLokacijaMapIcon.Location = new Geopoint(krajnjaPozicija);
                }
                if(pocetnaLokacijaMapIcon.Visible == true && krajnjaLokacijaMapIcon.Visible == true && samoPolazna == false )
                {
                    prikaziRutu();
                }
            }
        }
        public async void prikaziRutu()
        {
            registracija_MapControl.Routes.Clear();

            if (pocetnaLokacijaMapIcon.Visible == true && krajnjaLokacijaMapIcon.Visible == true && samoPolazna == false)
            {
                registracija_MapControl.Routes.Clear();

                BasicGeoposition bPolazna = new BasicGeoposition();
                BasicGeoposition bKrajnja = new BasicGeoposition();
                if (pocetnaLokacijaMapIcon.Location != null && krajnjaLokacijaMapIcon.Location != null)
                {
                    bPolazna.Latitude = pocetnaLokacijaMapIcon.Location.Position.Latitude;
                    bPolazna.Longitude = pocetnaLokacijaMapIcon.Location.Position.Longitude;
                
                    bKrajnja.Latitude = krajnjaLokacijaMapIcon.Location.Position.Latitude;
                    bKrajnja.Longitude = krajnjaLokacijaMapIcon.Location.Position.Longitude;
                
                Geopoint pocetnaTackaRute = new Geopoint(b);
                MapRouteFinderResult routeResult =
                                         await MapRouteFinder.GetDrivingRouteAsync(
                                         new Geopoint(bPolazna),
                                         new Geopoint(bKrajnja),
                                         MapRouteOptimization.Time,
                                         MapRouteRestrictions.None);

                if (routeResult.Status == MapRouteFinderStatus.Success)
                {
                    MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                    viewOfRoute.RouteColor = Colors.Yellow;
                    viewOfRoute.OutlineColor = Colors.DarkMagenta;
                    registracija_MapControl.Routes.Clear();
                    if(registracija_MapControl.Routes.Count()>0)
                        registracija_MapControl.Routes.RemoveAt(0);
                    registracija_MapControl.Routes.Add(viewOfRoute);
                    prikaziRastojanje(viewOfRoute.Route.LengthInMeters);
                    prikaziCijenu(viewOfRoute.Route.LengthInMeters);
                }
                }
            }
        }
        public void prikaziRastojanje(double r)
        {
            if (r != null)
                rastojanje_textBlock.Text = "Rastojanje: " + (r/1000).ToString("G2") + "km";
        }
        public void prikaziCijenu(double r)
        {
            if (r != null)
                cijena_textBlock.Text = "Cijena: " + cijenovnik.izracunajCijenuPoKilometru(r/1000).ToString("G2") + "KM";
        }
        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            datumRez_DatePicker.Date.Add(vrijemeRez_TimePicker.Time);// = datumRez_DatePicker.Date + vrijemeRez_TimePicker.Time;
            bool ispravnaNarudjba = true;
            string ispisGreske = "";
          //  ispisPoruka(datumRez_DatePicker.Date.ToString(), DateTime.Now.ToString());
            if(!samoPolazna && krajnjaLokacijaMapIcon.Visible == false)
            {
                ispravnaNarudjba = false;
                ispisGreske += "- Morate postaviti i krajnju lokaciju.\n";

            }
            if(datumRez_DatePicker.Date < DateTime.UtcNow ||(datumRez_DatePicker.Date == DateTime.UtcNow.Date && datumRez_DatePicker.Date.TimeOfDay < DateTime.UtcNow.TimeOfDay))
            {
                ispravnaNarudjba = false;
                ispisGreske += "- Vrijeme narudzbe nije ispravno. Rezervaciju mozete izvrsiti dan ranije. \n";
            }
            if (ispravnaNarudjba == false) ispisPoruka(ispisGreske, "Neispravna rezervacija");
            else
            {
                using (var db = new TaxiServisDbContext())
                {
                    Rezervacija rezervacija = new Rezervacija();
                    rezervacija.dodatniZahtjevi = zahtjevi_textbox.Text;
                    rezervacija.klijentId = klijent.id;
                    rezervacija.RegistrovaniKlijent = klijent;

                    //polazna lokacija
                    Lokacija pocetnaL = new Lokacija();
                    pocetnaL.duzina = pocetnaLokacijaMapIcon.Location.Position.Longitude;
                    pocetnaL.sirina = pocetnaLokacijaMapIcon.Location.Position.Latitude;
                    pocetnaL.nazivLokacije =  pocetnaL.postaviNazivLokacije();
                    db.Lokacije.Add(pocetnaL);
                    db.SaveChanges();
                    pocetnaL = db.Lokacije.Last();
                    rezervacija.polaznaLokacijaId = pocetnaL.id;
                    rezervacija.LokacijaPocetna = pocetnaL;
                    //krajnja lokacija
                    Lokacija krajnjaL = new Lokacija();
                    try {
                        krajnjaL.duzina = krajnjaLokacijaMapIcon.Location.Position.Longitude;
                        krajnjaL.sirina = krajnjaLokacijaMapIcon.Location.Position.Latitude;
                        krajnjaL.nazivLokacije = krajnja.postaviNazivLokacije();
                    }
                    catch (Exception)
                    {
                        krajnjaL = new Lokacija();
                        krajnjaL.sirina = pocetnaL.sirina;
                        krajnjaL.duzina = pocetnaL.duzina;
                        krajnjaL.nazivLokacije = pocetnaL.nazivLokacije;
                    }
                    db.Lokacije.Add(krajnjaL);
                    db.SaveChanges();
                    krajnjaL = db.Lokacije.Last();
                    rezervacija.krajnjaLokacijaId = krajnjaL.id;
                    rezervacija.LokacijaKrajnja = krajnjaL;

                    rezervacija.statusNarudzbe = StatusNarudzbe.Kreirana;
                    DateTime vrijemeRez = datumRez_DatePicker.Date.Add(vrijemeRez_TimePicker.Time).DateTime;
                    rezervacija.vrijemeRezervacije = vrijemeRez;
                    rezervacija.vrijemeNarudzbe = DateTime.Now;

                    //spasavanje u bazu
                    db.Rezervacije.Add(rezervacija);
                    db.SaveChanges();
                }
                ispisPoruka("Uspjesno ste kreirali rezervaciju. ", "Uspjesna rezervacija");
            }
        }
        public async void ispisPoruka(string greske, string naslov)
        {

            var dialog = new MessageDialog(greske, naslov);

            await dialog.ShowAsync();
        }
    }
}
