using MapControl;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.ViewModels;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class PocetnaVozacView : Page
    {


        Geolocator geolocator;
        // Task lociranje;
        Geoposition geoposition;
        MapIcon mapIcon;
        bool ponavljanjePetljeLociranja;
        Vozac vozac { get; set; }
        public List<ZahtjevZaPrevozSaPushPinom> listaZahtjevaSaPushpinom { get; set; }
        public bool raditiUpdateZahtjeva { get; set; }
        //public List<Pushpin> pushPin { get; set; }
        BasicGeoposition b;
        //Lokacija l;
        Geopoint geoPoint;
        MapIcon pin;
        public PocetnaVozacView()
        {
            this.InitializeComponent();
            this.Loaded += PocetnaKorisnikView_Loaded;
           // vozac = 
            mapIcon = new MapIcon();
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/taxiSlobodan.png"));
            mapIcon.Title = "Vaša lokacija";
            mapIcon.NormalizedAnchorPoint = new Point(0, 0.5);
       //     vozacMapa_MapControl.MapElements.Add(mapIcon);
            listaZahtjevaSaPushpinom = new List<ZahtjevZaPrevozSaPushPinom>();
            ponavljanjePetljeLociranja = true;
            raditiUpdateZahtjeva = true;
            
            updateMape();
            //updateZahtjevaNeprestano();
            string vozacUsername = textBlock_vozacKorisnickoIme.Text;
            using (var db = new TaxiServisDbContext())
            {
                foreach(var v in db.Vozači)
                {
                    if (v.korisnickoIme == vozacUsername)
                        this.vozac = v;

                    break;
                }
            }



        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            DataContext = new PocetnaVozacViewModel((MainPageView)e.Parameter);
            string vozacUsername = textBlock_vozacKorisnickoIme.Text;
            using (var db = new TaxiServisDbContext())
            {
                foreach (var v in db.Vozači)
                {
                    if (v.korisnickoIme == vozacUsername)
                        this.vozac = v;

                    break;
                }
            }
        }
        public async void pomocnaNotifikacija()
        {
            var poruka = new MessageDialog("DataContext je ok");
            await poruka.ShowAsync();
        }
        private async void PocetnaKorisnikView_Loaded(object sender, RoutedEventArgs e)
        {
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 5;

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
            geolocator.DesiredAccuracyInMeters = 5;

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

        }

        public async void updateMape()
        {
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 5;
            try
            {
                while (ponavljanjePetljeLociranja)
                {
                   // updateZahtjeva();
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
                    updateZahtjeva();
                    await Task.Delay(1000);
                }
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
                vozacMapa_MapControl.Children.Clear();
                ZahtjevZaPrevozSaPushPinom zahtjevZaSaPushpinom = new ZahtjevZaPrevozSaPushPinom();
                zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe = new ZahtjevZaPrevozZaListe();
                if(db.NarudzbeOdmah!=null)
                    vozacMapa_MapControl.MapElements.Add(mapIcon);
                try {
                    foreach (var zahtjevOdmah in db.NarudzbeOdmah)
                    {
                        if (zahtjevOdmah.statusNarudzbe == StatusNarudzbe.Kreirana)
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

                            pin.NormalizedAnchorPoint = new Point(0, 1);
                            pin.Title = zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.klijent;

                            vozacMapa_MapControl.MapElements.Add(pin);
                            listaZahtjevaSaPushpinom.Add(zahtjevZaSaPushpinom);
                            // var dialog = new MessageDialog("dodanPushpin", vozacMapa_MapControl.MapElements.Count().ToString());
                            //  dialog.ShowAsync();
                        }
                    }
                }
                catch (System.Exception)
                { }
                try
                {
                    foreach (var zahtjevOdmah in db.Rezervacije)
                    {
                        if (zahtjevOdmah.statusNarudzbe == StatusNarudzbe.Kreirana)
                        {
                            zahtjevZaSaPushpinom.idZahtjeva = zahtjevOdmah.id;
                            zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.vrijemeCekanja = DateTime.Now - zahtjevOdmah.vrijemeNarudzbe;
                            zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.tipZahtjeva = TipZahtjevaZaPrevoz.Rezervacija;
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
                            pin.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/klijentRezervacija.png"));

                            pin.NormalizedAnchorPoint = new Point(0, 0.5);
                            pin.Title = zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.klijent;

                            vozacMapa_MapControl.MapElements.Add(pin);
                            listaZahtjevaSaPushpinom.Add(zahtjevZaSaPushpinom);
                            // var dialog = new MessageDialog("dodanPushpin", vozacMapa_MapControl.MapElements.Count().ToString());
                            //  dialog.ShowAsync();
                        }
                    }
                }
                catch(System.Exception) { }
                try {
                    if (db.NarudzbeNeregistrovanihKlijenata != null)
                        foreach (var zahtjevOdmah in db.NarudzbeNeregistrovanihKlijenata)
                        {
                            if (zahtjevOdmah.statusNarudzbe == StatusNarudzbe.Kreirana)
                            {
                                zahtjevZaSaPushpinom.idZahtjeva = zahtjevOdmah.id;
                                zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.vrijemeCekanja = DateTime.Now - zahtjevOdmah.vrijemeNarudzbe;
                                zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.tipZahtjeva = TipZahtjevaZaPrevoz.NarudzbaNeregistrovaniKlijent;
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
                                pin.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/klijentNeregistrovaniZahtjev.png"));

                                pin.NormalizedAnchorPoint = new Point(0, 0.5);
                                pin.Title = zahtjevZaSaPushpinom.zahtjevaZaPrevozZaListe.klijent;

                                vozacMapa_MapControl.MapElements.Add(pin);
                                listaZahtjevaSaPushpinom.Add(zahtjevZaSaPushpinom);
                                // var dialog = new MessageDialog("dodanPushpin", vozacMapa_MapControl.MapElements.Count().ToString());
                                //  dialog.ShowAsync();
                            }
                        }
                }
                catch (System.Exception) { }
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
                                    foreach(var z in db.NarudzbeOdmah)
                                    {
                                        if(z.id == zahtjevSaPushpinom.zahtjevaZaPrevozZaListe.id)
                                        {
                                            z.statusNarudzbe = StatusNarudzbe.Prihvacena;
                                            db.SaveChanges();
                                            z.VozacPrihvatioId = this.vozac.id;
                                            db.SaveChanges();
                                            z.Vozac =(from v in db.Vozači where v.id == vozac.id select v).First();
                                            db.SaveChanges();
                                            //this.vozac.slobodan = false;
                                            //this.vozac.aktivan = true;
                                            foreach (Vozac voz in db.Vozači)
                                            {
                                                if (voz.id == this.vozac.id)
                                                {
                                                    voz.slobodan = false;
                                                    db.SaveChanges();
                                                    voz.aktivan = true;
                                                    db.SaveChanges();
                                                }
                                                break;
                                            }
                                            break;
                                        }
                                        db.SaveChanges();
                                    }
                                     //Vozac vozac = (from z in db.NarudzbeOdmah where zahtjevSaPushpinom.zahtjevaZaPrevozZaListe.id == z.id  select z.Vozac).First();
                                    

                                }
                            }
                        }

                        }
                        break;
                    }
                
            }
        }
    }
}
/*
using MapControl;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.ViewModels;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class PocetnaVozacView : Page
    {


        Geolocator geolocator;
        // Task lociranje;
        Geoposition geoposition;
        MapIcon mapIcon;
        bool ponavljanjePetljeLociranja;
        Vozac vozac { get; set; }
        public List<ZahtjevZaPrevozZaListe> listaZahtjevaPushpin { get; set; }
        public bool raditiUpdateZahtjeva { get; set; }
        public List<Pushpin> pushPin { get; set; }
        public PocetnaVozacView()
        {
            this.InitializeComponent();
            this.Loaded += PocetnaKorisnikView_Loaded;
            mapIcon = new MapIcon();
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/voziloZelena.jpg"));
            mapIcon.Title = "Vaša lokacija";
            mapIcon.NormalizedAnchorPoint = new Point(0.5, 0.5);
            vozacMapa_MapControl.MapElements.Add(mapIcon);
            listaZahtjevaPushpin = new List<ZahtjevZaPrevozZaListe>();
            ponavljanjePetljeLociranja = true;
            raditiUpdateZahtjeva = true;

            locirajMe();
            //updateZahtjevaNeprestano();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = new PocetnaVozacViewModel((MainPageView)e.Parameter);
        }
        public async void pomocnaNotifikacija()
        {
            var poruka = new MessageDialog("DataContext je ok");
            await poruka.ShowAsync();
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

        public async void locirajMe()
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
                    mapIcon.NormalizedAnchorPoint = new Point(0.5, 0.5);
                    vozacMapa_MapControl.ZoomLevel = mySlider.Value;
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
            catch (System.Exception)
            {
                MessageBox("Vaš uređaj trenutno ne podržava uslugu lociranja. Uključite lokaciju i proverite Internet konekciju!");
            }
            await Task.Delay(5000);
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
                ZahtjevZaPrevozZaListe zahtjevZaListe = new ZahtjevZaPrevozZaListe();
                foreach (var zahtjevOdmah in db.NarudzbeOdmah)
                {   

                    zahtjevZaListe.vrijemeCekanja = DateTime.Now - zahtjevOdmah.vrijemeNarudzbe;
                    zahtjevZaListe.id = zahtjevOdmah.id;
                    zahtjevZaListe.tipZahtjeva = TipZahtjevaZaPrevoz.NarudzbaRegistrovaniKlijent;
                    zahtjevZaListe.klijent = (from k in db.RegistrovaniKlijenti where k.id == zahtjevOdmah.klijentId select k.korisnickoIme).First().ToString();
                    zahtjevZaListe.lokacija = (from l in db.Lokacije where l.id == zahtjevOdmah.lokacijaKorisikaId select l.nazivLokacije).First().ToString();
                    listaZahtjevaPushpin.Add(zahtjevZaListe);
                    BasicGeoposition b = new BasicGeoposition();
                    double d = (from l in db.Lokacije where l.id == zahtjevOdmah.lokacijaKorisikaId select l.duzina).First();
                    double s = (from l in db.Lokacije where l.id == zahtjevOdmah.lokacijaKorisikaId select l.sirina).First();
                    b.Latitude = s;
                    b.Longitude = d;
                    Geopoint geoPoint = new Geopoint(b);
                    MapIcon pin = new MapIcon();
                    pin.Location = geoPoint;
                    pin.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/klijentZelena.jpg"));
                    pin.NormalizedAnchorPoint = new Point(0.5, 0.5);
                    pin.Title = zahtjevZaListe.klijent;
                    vozacMapa_MapControl.MapElements.Add(mapIcon);
                    vozacMapa_MapControl.MapElements.Add(pin);

                    var dialog = new MessageDialog("dodanPushpin", vozacMapa_MapControl.MapElements.Count().ToString());
                    dialog.ShowAsync();
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
    }
}

*/
