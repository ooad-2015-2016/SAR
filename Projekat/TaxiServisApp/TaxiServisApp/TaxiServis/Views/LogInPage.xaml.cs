using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TaxiServisApp;
using TaxiServisApp.TaxiServis.DataSource;
using TaxiServisApp.TaxiServis.ViewModels;
using TaxiServisApp.TaxiServis.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TaxiServisApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 



    public sealed partial class LogInPage : Page
    {
        public object Start { get; private set; }

        public LogInPage()
        {
            this.InitializeComponent();
            var inicijalizacija = new DataSourceMeni();
            DataContext = new LogInViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            //loginVM = (LogInViewModel)e.Parameter;
            //DataContext = new LogInViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;
        }


      /*  private async void buttonPrijava_Click(object sender, RoutedEventArgs e)
         {

             var korisnickoIme = textBoxUsername.Text;
             var sifra = textBoxPassword.Password;
             var korisnik = DataSourceMeni.ProvjeraKorisnika(korisnickoIme, sifra);
             if (korisnik != null && korisnik.KorisnikId > 0)
             {
                MainPageViewModel MPVM = new MainPageViewModel(this);
                MPVM.korisnik = korisnik;
                 this.Frame.Navigate(typeof(MainPageView), MPVM);
             }
             else
             {
                 var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");

                 await dialog.ShowAsync();
             }
         }
         */

    }
}
