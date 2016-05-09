using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServiProject;
using TaxiServisApp.TaxiServis.DataSource;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class LogInViewModel
    {
        public INavigationService NavigationService { get; set; }
        public ICommand MainPageCommand { get; set; }
        public ICommand RegistracijaCommand { get; set; }
        public Korisnik korisnik { get; set; }
        public string username { get; set; }
        public string pass { get; set; }

        public LogInViewModel()
        {
            NavigationService = new NavigationService();
            RegistracijaCommand = new RelayCommand<object>(stranicaRegistracije);
            MainPageCommand = new RelayCommand<object>(pocetnaStranica, prijavaOk);
        }

        public void stranicaRegistracije(object parametar)
        {
            NavigationService.Navigate(typeof(PageRegistracija), new RegistracijaPageViewModel(this));
        }

        public void pocetnaStranica(object parametar)
        {
           
            NavigationService.Navigate(typeof(MainPageView),new MainPageViewModel(this));
        }

        public bool prijavaOk(object parametar)
        {
            korisnik = DataSourceMeni.ProvjeraKorisnika(username, pass);
            if (korisnik != null && korisnik.KorisnikId > 0)
            {
                return true;
               //this.Frame.Navigate(typeof(MainPage), korisnik);
            }
            return false;
        }
     /*   private async void button_Prijava(object sender, RoutedEventArgs e)
        {

            var korisnickoIme = textBoxUsername.Text;
            var sifra = textBoxPassword.Password;
            var 
            if (korisnik != null && korisnik.KorisnikId > 0)
            {
                this.Frame.Navigate(typeof(MainPage), korisnik);
            }
            else
            {
                var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");

                await dialog.ShowAsync();
            }
        }*/
    }


}
