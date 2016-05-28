using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class MainPageViewModel
    {
        private LogInPage logInPage;

        //private LogInViewModel logInViewModel;
        public LogInViewModel  parent {get; set;}
        public Korisnik _korisnik { get; set; }
        public string naslovPodstranice { get; set; }

        public List<MeniStavkeViewModel> _stavke { get; set; }

        public INavigationService NavigationService { get; set; }


        public MainPageViewModel(LogInViewModel parent)
        {
            _korisnik = new Korisnik();
            //odabranaStavkaMenija = new RelayCommand<object>(stavkaMenija_SelectionChanged);

            _stavke = new List<MeniStavkeViewModel>();
            this.parent = parent;
            MeniStavkeViewModel meniStavkeViewModel;
            _korisnik = parent.korisnik;
             Korisnik korisnik = null;
            //Dobavljanje korisnika iz parametra budući da je isti sa logina poslan kao parametar
            if (parent != null)
            {
                korisnik = parent.korisnik;//(Korisnik)e.Parameter;
            }
            //var stavke = MeniStavkeListView.ItemsSource as List<MeniStavkeViewModel>;

            //dobavljanje svih meni stavki za koje prijavljeni korisnik ima pravo pristupa
         
            if (_stavke == null && korisnik != null && korisnik.UlogaKorisnika != null)
            {
                _stavke = new List<MeniStavkeViewModel>();
                var ulogeKorisnika = korisnik.UlogaKorisnika.Distinct().ToList();
                foreach(var u in ulogeKorisnika)
                {
                    u.Uloga.UlogaMeniStavke = u.Uloga.UlogaMeniStavke.Distinct().ToList();
                }
                foreach (var uloga in ulogeKorisnika)
                {
                    
                    foreach (var ulogaMeniStavka in uloga.Uloga.UlogaMeniStavke)
                    {
                        
                       _stavke.Add(MeniStavkeViewModel.SaMeniStavke(ulogaMeniStavka.MeniStavka));
                        if (ulogaMeniStavka.MeniStavka.Naziv == "LogOut") break;
                    }
                    break;
                }
                var stavkeFiltriranoOdDuplikata=_stavke.Distinct().ToList();

                //meniStavkeViewModel.ItemsSource = stavkeFiltriranoOdDuplikata;
                

            }
        }
        public void stavkaMenija_SelectionChanged(object parametar)
        {

        }


        public MainPageViewModel(LogInPage logInPage)
        {
            this.logInPage = logInPage;
            this.parent = parent;
            _korisnik = parent.korisnik;
           // korisnik = new Korisnik(logInPage.korisnik);
        }

        public MainPageViewModel()
        {
        }
    }
}
