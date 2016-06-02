using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;
using Windows.UI.Popups;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class RegistracijaPageViewModel
    {
        private LogInViewModel logInViewModel;
        public string ime { get; set; }
        public string prezime { get; set; }
        public string mail { get; set; }
        public string korisnickoIme { get; set; }
        public string sifra { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string ponovljenaSifra;
        public INavigationService NavigationService { get; set; }
        public ICommand NapraviNalog { get; set; }
        public ICommand PonistiRegistraciju { get; set; }

        public RegistracijaPageViewModel()
        {
            //registrovaniKlijent = new RegistrovaniKlijent();
            NapraviNalog = new RelayCommand<object>(napraviNalog, provjeriPravljenjeNaloga);

        }

        public void napraviNalog(object parametar)
        {
            using (var db = new TaxiServisDbContext())
            {
                
            /*    RegistrovaniKlijent noviKlijent = new RegistrovaniKlijent();
                if(noviKlijent.sifra.Length<4)
                {
                    var dialog = new MessageDialog("Uspjesno ste napravili nalog");

                    await dialog.ShowAsync();
                    MessageDialog("Sifra mora imati 4 karaktera");
                }

                db.Klijenti.Add(noviKlijent);
                /*   ime = this.ime,
                    prezime = this.prezime,
                    datumRodjenja = datumRodjenja,
                    brojVoznji = 0,
                    kilometriVoznje = 0,
                    mail = this.mail,
                    korisnickoIme = this.korisnickoIme,
                    sifra = this.sifra,
                    datumRegistracije = DateTime.Now
                   */
                    
                /*
                );
                db.SaveChanges();
                notifikacijaRegistracije();
                //registrovaniKlijent = new RegistrovaniKlijent();
           */ }
        }

        public async void notifikacijaRegistracije()
        {
            {
                
            }
        }
        public bool provjeriPravljenjeNaloga(object parametar)
        {
            
            //Dodati: za kontrolu unosa naloga
            return true;
        }
        public RegistracijaPageViewModel(LogInViewModel logInViewModel)
        {
            this.logInViewModel = logInViewModel;
            //registrovaniKlijent = new RegistrovaniKlijent();
            NapraviNalog = new RelayCommand<object>(napraviNalog, provjeriPravljenjeNaloga);

        }
    }
}
