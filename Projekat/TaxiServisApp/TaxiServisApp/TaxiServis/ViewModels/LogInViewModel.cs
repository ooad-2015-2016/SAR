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
        public ICommand HelpCommand { get; set; }
        public INavigationService NavigationService { get; set; }
        public ICommand MainPageCommand { get; set; }
        public ICommand RegistracijaCommand { get; set; }
        public Korisnik korisnik { get; set; }
        public RegistrovaniKlijent registrovaniKlijent { get; set; }
        public string username { get; set; }
        public string pass { get; set; }

        public async void metodaZaPomoc(object obj)
        {
            var dialog = new MessageDialog("Klikom na dugme   Registruj se  vršite registraciju unosom Vaših osnovnih podataka, u cilju dodatnih popusta i besplatnih vožnji.Nakon registracije, Vašu prijavu na sistem vršite klikom na dugme  „Prijava“ , unosom korisnickog imena i šifre.Prijavom na sistem, otvori Vam se mapa grada u kojem se nalazite i Vaša trenutačna lokacija.U lijevom uglu nalazi se lista usluga: \n1.NARUDŽBA TAXIA \n2.REZERVACIJA TAXIA\n3.PODACI O KLIJENTU\n4.LOG OUT\nNARUDŽBA TAXIA:\nKlikom na dugme  „Naruči taxi“ , naručujete taxi, koji dolazi na Vašu trenutačnu lokaciju, ili lokaciju koju označite na mapi kao polaznu.Također možete klikom na mapi označiti i Vašu krajnju destinaciju, i tako i dobiti i uvid u cijenu naručene vožnje, koja će Vam biti prikazana u u gornjem lijevom uglu.\nREZERVACIJA TAXIA:\nVrši se na potpuno isti način kao i i uobičajna NARUDŽBA TAXi - a.Imate mogučnost rezervacije taxia za unaprijed dogovoreni period i željenu destinaciju.Imate uvid u cijenu vožnje, kao i mogučnost biranja taxia ili nekih drugih dodatnih zatjeva koje navodite u Vašoj rezervaciji.\nPODACI O KLIJENTU:\nTu se nalaze Vaši osnovni podaci, kao i broj dosadašnjih vožnji i evidencija o popustima.\nLOG OUT:\nIzlazite iz aplikacije ukoliko ste izvršili narudžbi ili ste odustali od nje.", "Pomoć oko korištenja");
            await dialog.ShowAsync();
        }

        public LogInViewModel()
        {
            NavigationService = new NavigationService();
            HelpCommand = new RelayCommand<object>(metodaZaPomoc);
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
        }


    }


}
