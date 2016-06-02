using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.Views;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    public class PocetnaSupervizorViewModel
    {
        public ObservableCollection<Vozac> ListaUposlenika { get; set; }
        //public List<Vozac> ListaUposlenika { get; set; }
        public ObservableCollection<Dispecer> ListaDispecera { get; set; }
        public DelegateCommand<ItemClickEventArgs> ItemClickedCommand { get; set; }

        private void OnItemClicked(ItemClickEventArgs args)
        {
            Vozac item = args.ClickedItem as Vozac;
            
        }
       
        private MainPageView parameter;
        public PocetnaSupervizorViewModel(MainPageView parameter)
        {
            using (var db = new TaxiServisDbContext())
            {
                ListaUposlenika = new ObservableCollection<Vozac>(db.Vozači.ToList());
                ItemClickedCommand = new DelegateCommand<ItemClickEventArgs>(OnItemClicked);
            }

            using (var db = new TaxiServisDbContext())
            {
                ListaDispecera = new ObservableCollection<Dispecer>(db.Dispeceri.ToList());
            }

            this.parameter = parameter;
        }

      

    }
}
