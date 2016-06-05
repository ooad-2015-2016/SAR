using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.Views;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    public class PocetnaSupervizorViewModel
    {
        private MainPageView parameter;

        public PocetnaSupervizorViewModel(MainPageView parameter)
        {
            using (var db = new TaxiServisDbContext())
            {
                ListaUposlenika = db.Vozači.ToList();
            }

            using (var db = new TaxiServisDbContext())
            {
                ListaDispecera = db.Dispeceri.ToList();
            }

            this.parameter = parameter;
        }

        public List<Vozac> ListaUposlenika { get; set; }
        public List<Dispecer> ListaDispecera { get; set; }
    }
}
