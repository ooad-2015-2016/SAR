using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using System.ServiceModel.Dispatcher;
using TaxiServisApp.TaxiServis.Views;
using Windows.UI.Popups;
using TaxiServisApp.TaxiServis.Models;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class PocetnaVozacViewModel
    {
        private MainPageView parameter;
        List<ZahtjevZaPrevozZaListe> listaZahtjeva { get; set; }
        public bool raditiUpdateZahtjeva { get; set; }

        public PocetnaVozacViewModel(MainPageView parameter)
        {
            {
                var dialog = new MessageDialog("pokrenuto sa MainPageView ");
                 dialog.ShowAsync();
            }
            listaZahtjeva = new List<ZahtjevZaPrevozZaListe>();
            this.parameter = parameter;
            raditiUpdateZahtjeva = true;
            updateZahtjevaNeprestano();
            if (listaZahtjeva == null || listaZahtjeva.Count() == 0)
            {
                var dialog = new MessageDialog("lista je prazna");
                dialog.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("lista nije prazna");
                //await dialog.ShowAsync();
            }
        }

        public void updateZahtjeva()
        {
            
            using (var db = new TaxiServisDbContext())
            {
                listaZahtjeva.Clear();
                foreach(var zahtjevOdmah in db.NarudzbeOdmah.ToList())
                {
                    listaZahtjeva.Add(new ZahtjevZaPrevozZaListe(zahtjevOdmah.id));
                }
            }

        }

        public async void updateZahtjevaNeprestano()
        {
            while (raditiUpdateZahtjeva)
            {
                updateZahtjeva();
                await Task.Delay(500);
                /*if (listaZahtjeva == null || listaZahtjeva.Count() == 0)
                {
                    var dialog = new MessageDialog("lista je prazna");
                    await dialog.ShowAsync();
                }
                else
                {
                    var dialog = new MessageDialog("lista nije prazna, clanova:",Convert.ToString(listaZahtjeva.Count()));
                    await dialog.ShowAsync();
                }*/
            }


        }

        public async void ispisPoruke(string poruka, string naslov)
        {
            {
                var dialog = new MessageDialog(poruka, naslov);
                await dialog.ShowAsync();
            }
        }
    }
}
