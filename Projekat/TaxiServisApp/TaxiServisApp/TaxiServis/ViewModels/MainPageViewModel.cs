using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class MainPageViewModel
    {
        private LogInPage logInPage;

        //private LogInViewModel logInViewModel;
        public LogInViewModel  parent {get; set;}
        public Korisnik korisnik { get; set; }
        public string naslovPodstranice { get; set; }

        public INavigationService NavigationService { get; set; }


        public MainPageViewModel(LogInViewModel parent)
        {

            this.parent = parent;
            korisnik = parent.korisnik;
        }

        public MainPageViewModel(LogInPage logInPage)
        {
            this.logInPage = logInPage;
            this.parent = parent;
            korisnik = parent.korisnik;
           // korisnik = new Korisnik(logInPage.korisnik);
        }

        public MainPageViewModel()
        {
        }
    }
}
