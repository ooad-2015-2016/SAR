using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class RegistracijaPageViewModel
    {
        private LogInViewModel logInViewModel;

        public RegistracijaPageViewModel(LogInViewModel logInViewModel)
        {
            this.logInViewModel = logInViewModel;
        }
    }
}
