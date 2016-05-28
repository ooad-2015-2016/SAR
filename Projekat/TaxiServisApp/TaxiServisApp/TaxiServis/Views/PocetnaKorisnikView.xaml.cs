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
using Windows.Storage.Streams;
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
       // Task lociranje;
        Geoposition geoposition;
        MapIcon mapIcon;
        bool ponavljanjePetljeLociranja;
        Korisnik _korisnik { get; set; }
        public PocetnaKorisnikView()
        {
            this.InitializeComponent();

            //DataContext = new PocetnaKorisnikViewModel(this);
            this.Loaded += PocetnaKorisnikView_Loaded;
            //lociranje = locirajMe();
            //lociranje.RunSynchronously();
            // lociranje.
            mapIcon = new MapIcon();
            // Locate your MapIcon  
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/my-position.png"));
            // Show above the MapIcon  
            mapIcon.Title = "Vaša lokacija";
            // Setting up MapIcon location    
            korisnickaMapa_MapControl.MapElements.Add(mapIcon);

            ponavljanjePetljeLociranja = true;
            locirajMe();


        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = new PocetnaKorisnikViewModel((MainPageView)e.Parameter);
        }
        public async void pomocnaNotifikacija()
        {
            var poruka = new MessageDialog("DataContext je ok");
            await poruka.ShowAsync();
        }
        private async void PocetnaKorisnikView_Loaded(object sender, RoutedEventArgs e)
        {
            // Map Token for testing purpose,   
            // otherwise you'll get an alart message in Map Control  
            //korisnickaMapa_MapControl.MapServiceToken = "abcdef-abcdefghijklmno";



            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                // Getting Current Location  
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10));


                // Positon of the MapIcon  

                // Showing in the Map  

                // Disable the ProgreesBar  
                //progressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                // Set the Zoom Level of the Slider Control  
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox("Lokacija na uređaju je isključena!");
            }
            // base.OnNavigatedTo(e);
        }
        // Slider Control  
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

        // Locate Me Bottom App Bar  
        private async void LocateMe_Click(object sender, RoutedEventArgs e)
        {
            //progressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10));
                await korisnickaMapa_MapControl.TrySetViewAsync(geoposition.Coordinate.Point, 18D);
                mySlider.Value = korisnickaMapa_MapControl.ZoomLevel;
              //  progressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox("Lokacija na uređaju je isključena!");
            }
            //await(1000);
        }
        public async void locirajMe()
        {
            // progressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;

                //ponavljanjePetljeLociranja = false;
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
                        //Latitude = geoposition.Coordinate.Latitude, [Don't use]  
                        //Longitude = geoposition.Coordinate.Longitude [Don't use]  
                        Latitude = geoposition.Coordinate.Point.Position.Latitude,
                        Longitude = geoposition.Coordinate.Point.Position.Longitude
                    });
                    mapIcon.NormalizedAnchorPoint = new Point(0.5, 0.5);
                    //mySlider.Value = korisnickaMapa_MapControl.ZoomLevel;
                    korisnickaMapa_MapControl.ZoomLevel = mySlider.Value;
                    //mySlider.Value = korisnickaMapa_MapControl.ZoomLevel;
                    // progressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                    //Ovaj dio je zakomentarisan zbog popravki lokacije
                    geoDuzina_TextBlock.Text = Convert.ToString(korisnickaMapa_MapControl.Center.Position.Longitude);
                    geoSirina_TextBlock.Text = Convert.ToString(korisnickaMapa_MapControl.Center.Position.Latitude);
                    
                }  
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox("Lokacija na uređaju je isključena!");
                   // break;
                }
            catch (System.Exception)
            {
                MessageBox("Vaš uređaj trenutno ne podržava uslugu lociranja. Uključite lokaciju i proverite Internet konekciju!");
            }
                await Task.Delay(500);
            
        }

        // Custom Message Dialog Box  
        private async void MessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => await dialog.ShowAsync());
        }

     
    }
    /*
    public sealed partial class PocetnaKorisnikView : Page
    {
        Geolocator geolocator;
        Task lociranje;
        Geoposition geoposition;
        MapIcon mapIcon;

        public PocetnaKorisnikView()
        {
            this.InitializeComponent();
            DataContext = new PocetnaKorisnikViewModel();
            this.Loaded += PocetnaKorisnikView_Loaded;
            //lociranje = locirajMe();
            //lociranje.RunSynchronously();
            // lociranje.
            mapIcon = new MapIcon();
            // Locate your MapIcon  
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/my-position.png"));
            // Show above the MapIcon  
            mapIcon.Title = "Current Location";
            // Setting up MapIcon location    
            korisnickaMapa_MapControl.MapElements.Add(mapIcon);
            locirajMe();


        }
        private async void PocetnaKorisnikView_Loaded(object sender, RoutedEventArgs e)
        {
            // Map Token for testing purpose,   
            // otherwise you'll get an alart message in Map Control  
            //korisnickaMapa_MapControl.MapServiceToken = "abcdef-abcdefghijklmno";

            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                // Getting Current Location  
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10));


                // Positon of the MapIcon  

                // Showing in the Map  

                // Disable the ProgreesBar  
                //progressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                // Set the Zoom Level of the Slider Control  
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox("Location service is turned off!");
            }
            // base.OnNavigatedTo(e);
        }
        // Slider Control  
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

        // Locate Me Bottom App Bar  
        private async void LocateMe_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10));
                await korisnickaMapa_MapControl.TrySetViewAsync(geoposition.Coordinate.Point, 18D);
                mySlider.Value = korisnickaMapa_MapControl.ZoomLevel;
                progressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox("Location service is turned off!");
            }
            //await(1000);
        }
        public async void locirajMe()
        {
            // progressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
            for (;;)
            {
                geolocator = new Geolocator();
                geolocator.DesiredAccuracyInMeters = 50;
                try
                {
                    geoposition = await geolocator.GetGeopositionAsync(
                       maximumAge: TimeSpan.FromMinutes(5),
                       timeout: TimeSpan.FromSeconds(10));
                    await korisnickaMapa_MapControl.TrySetViewAsync(geoposition.Coordinate.Point);

                    mapIcon.Location = new Geopoint(new BasicGeoposition()
                    {
                        //Latitude = geoposition.Coordinate.Latitude, [Don't use]  
                        //Longitude = geoposition.Coordinate.Longitude [Don't use]  
                        Latitude = geoposition.Coordinate.Point.Position.Latitude,
                        Longitude = geoposition.Coordinate.Point.Position.Longitude
                    });
                    mapIcon.NormalizedAnchorPoint = new Point(0.5, 0.5);
                    //mySlider.Value = korisnickaMapa_MapControl.ZoomLevel;
                    korisnickaMapa_MapControl.ZoomLevel = mySlider.Value;
                    //mySlider.Value = korisnickaMapa_MapControl.ZoomLevel;
                    // progressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox("Location service is turned off!");
                }
            }
        }

        // Custom Message Dialog Box  
        private async void MessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => await dialog.ShowAsync());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new TaxiServisDbContext())
            {
                var zahtjev = new NarudzbaOdmah()
                {
                    vrijemeNarudzbe = DateTime.Now,
                    //klijent=


                };


            }
        }
    }
    */
}
