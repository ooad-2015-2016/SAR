using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp;
using TaxiServisApp.TaxiServis.Views;
using TaxiServisApp.TaxiServis.DataSource;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.Views;
using Windows.UI.Popups;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class LogInViewModel
    {
        public INavigationService NavigationService { get; set; }
        public ICommand MainPageCommand { get; set; }
        public ICommand RegistracijaCommand { get; set; }
        public Korisnik korisnik { get; set; }
        public RegistrovaniKlijent registrovaniKlijent { get; set; }
        public string username { get; set; }
        public string pass { get; set; }

        public LogInViewModel()
        {
            NavigationService = new NavigationService();
            RegistracijaCommand = new RelayCommand<object>(stranicaRegistracije);
            MainPageCommand = new RelayCommand<object>(pocetnaStranica);
            var inicijalizacija = new DataSourceMeni();
            //username = "Korisničko ime";
            //pass = "Korisnička šifra";

        }

        public void stranicaRegistracije(object parametar)
        {
            NavigationService.Navigate(typeof(TaxiServisApp.TaxiServis.Views.PageRegistracija), new RegistracijaPageViewModel(this));
        }

        public async void pocetnaStranica(object parametar)
        {
            korisnik = new Korisnik();
            korisnik.KorisnickoIme = username;
            korisnik.Sifra = pass;
            {

                //DataSourceMeni.unesiKlijenteUKorisnike(listaRegKlijenata);
                korisnik = DataSourceMeni.ProvjeraKorisnika(username, pass);
                if (korisnik != null && korisnik.KorisnikId > 0)
                {
                    NavigationService.Navigate(typeof(MainPageView), new MainPageViewModel(this));

                    //return true;
                    //this.Frame.Navigate(typeof(MainPage), korisnik);
                }
                else
                {
                    var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");

                    await dialog.ShowAsync();
                    //return false;

                }
            }
            /*           private async void buttonPrijava_Click(object sender, RoutedEventArgs e)
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

               }*/
        }


    }
}
