using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class LogInViewModel
    {
        public INavigationService NavigationService { get; set; }        public ICommand MainPageCommand { get; set; }
        public ICommand RegistracijaCommand { get; set; }

        public LogInViewModel ()
        {
            NavigationService = new NavigationService();

        }
    }


}
