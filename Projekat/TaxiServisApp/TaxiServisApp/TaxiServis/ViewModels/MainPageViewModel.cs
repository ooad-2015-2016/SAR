using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class MainPageViewModel
    {
        private LogInViewModel logInViewModel;
        public LogInViewModel  parent {get; set;}
        public Models.Korisnik korisnik { get; set; }
    public MainPageViewModel(LogInViewModel parent)
        {

            this.parent = parent;
            korisnik = parent.korisnik;
        }
    }
}
