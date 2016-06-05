using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Views;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class RezervacijaViewModel
    {
        private MainPageView parameter;
        public ICommand kreirajRezervacijuCommand { get; set; }
        public string klijenKorisnickoIme { get; set; }
        public RezervacijaViewModel(MainPageView parameter)
        {
            this.parameter = parameter;
            kreirajRezervacijuCommand = new RelayCommand<object>(kreirajRezervaciju);
            klijenKorisnickoIme = parameter._korisnik.KorisnickoIme;

        }

       public void kreirajRezervaciju(object obj)
        {

        }
    }
}
