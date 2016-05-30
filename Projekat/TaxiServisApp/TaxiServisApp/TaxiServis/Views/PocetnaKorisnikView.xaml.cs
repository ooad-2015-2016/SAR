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
        Geoposition geoposition;
        MapIcon mapIcon;
        bool ponavljanjePetljeLociranja;
        Korisnik _korisnik { get; set; }
        NavigationEventArgs _e;
        public PocetnaKorisnikView()
        {
            this.InitializeComponent();
            this.Loaded += PocetnaKorisnikView_Loaded;
            mapIcon = new MapIcon();
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/klijentTrenutni.png"));
            mapIcon.Title = "Vaša lokacija";
            mapIcon.NormalizedAnchorPoint = new Point(0.5, 0.5);

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
    }
}
